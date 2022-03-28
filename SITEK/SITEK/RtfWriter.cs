using DW.RtfWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEK
{
    internal class RtfWriter
    {
        private readonly RtfDocument _document;
        public RtfWriter()
        {
            _document = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.English);
        }

        public void Save(string path, DataGridView dataGridView, DateTime startedTime)
        {
            if(string.IsNullOrEmpty(path))
            {
                throw new InvalidOperationException("Не указан путь сохранения файла");
            }

            WriteHeader();

            var total = GetTotal(dataGridView, dataGridView.Columns.Count - 1);
            var totalAppeals = GetTotal(dataGridView, dataGridView.Columns.Count - 2);
            var totalRkk = GetTotal(dataGridView, dataGridView.Columns.Count - 3);
            var sortType = GetSortType(dataGridView);

            WriteBody(total, totalRkk, totalAppeals, sortType);
            WriteDataToTable(dataGridView, startedTime);

            try
            {
                _document.save(path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteHeader()
        {
            var header = _document.addParagraph();
            header.Alignment = Align.Center;
            header.setText("Справка о неисполненных документах и обращениях граждан");
            header.DefaultCharFormat.FontStyle.addStyle(FontStyleFlag.Bold);
        }

        private void WriteBody(int allDocsCount, int totalRkk, int totalAppeals, SortType sortType)
        {
            var paragraph = _document.addParagraph();
            
            paragraph.setText($"Не исполнено в срок {allDocsCount} документов, из них: \r\n \r\n" +
                $"- количество неисполненных входящих документов: {totalRkk};\r\n \r\n" +
                $"- количество неисполненных письменных обращений граждан: {totalAppeals}.\r\n \r\n" +
                $"{sortType.GetDescription()}");

            var text = paragraph.Text.ToString();

            var start = text.IndexOf(allDocsCount.ToString());
            var end = start + allDocsCount.ToString().Length;
            paragraph.addCharFormat(start, end).FontStyle.addStyle(FontStyleFlag.Bold);

            start = text.IndexOf(totalRkk.ToString());
            end = start + totalRkk.ToString().Length;
            paragraph.addCharFormat(start,end).FontStyle.addStyle(FontStyleFlag.Bold);

            start = text.IndexOf(totalAppeals.ToString());
            end = start + totalAppeals.ToString().Length;
            paragraph.addCharFormat(start, end).FontStyle.addStyle(FontStyleFlag.Bold);
        }

        private void WriteDataToTable(DataGridView dataGridView, DateTime startedTime)
        {
            var table = _document.addTable(dataGridView.RowCount+3, 5, 8);
            table.setColWidth(0, 20);
            table.setColWidth(1, 150);
            table.setColWidth(2, 100);
            table.setColWidth(3, 100);
            table.setColWidth(4, 100);

            var rows = dataGridView.Rows.Count;
            var cols = dataGridView.Columns.Count;

            var topLeftHeader = dataGridView.TopLeftHeaderCell.Value.ToString();
            table.cell(0, 0).addParagraph().setText(topLeftHeader);

            for (var i = 0; i < cols; i++)
            {
                var text = dataGridView.Columns[i].HeaderText;
                var paragraph =  table.cell(0, i + 1).addParagraph();
                paragraph.setText(text);
                paragraph.DefaultCharFormat.FontStyle.addStyle(FontStyleFlag.Bold);
                paragraph.Alignment = Align.Center;
                paragraph.DefaultCharFormat.FontSize = 10;
                table.cell(0, i+1).Alignment = Align.Center;
            }

            for (var i = 0; i < rows - 1; i++)
            {
                var rowNumebr = i + 1;
                table.cell(rowNumebr, 0).addParagraph().setText(rowNumebr.ToString());
                for (var j = 0; j < cols; j++)
                {
                    var text = dataGridView[j,i].Value.ToString();

                    var paragraph = table.cell(i + 1, j + 1).addParagraph();
                    paragraph.setText(text);
                    paragraph.Alignment = Align.Center;
                }
            }

            WriteFooter(table, startedTime);
        }

        private static void WriteFooter(RtfTable table, DateTime startedTime)
        {
            var row = table.RowCount - 3;
            for (var i = 0; i < 3; i++)
            {
                table.merge(row, 0, 1, 2);
                table.merge(row, 2, 1, 3);
                row++;
            }

            table.cell(table.RowCount - 1, 0).addParagraph().setText("Дата составления справки:");
            table.cell(table.RowCount - 1, 2).addParagraph().setText($"{startedTime:d}");
        }

        private static SortType GetSortType(DataGridView dataGridView)
        {
            var sortedCol = dataGridView.SortedColumn?.Index;

            if (sortedCol == null)
            {
                return SortType.None;
            }

            return sortedCol switch
            {
                0 => SortType.Name,
                1 => SortType.Rkk,
                2 => SortType.Appeals,
                3 => SortType.Total,
                _ => throw new InvalidOperationException(message: "Для данного столбца нет реализации типа сортировки"),
            };
        }

        private static int GetTotal(DataGridView dataGridView, int columnIndex)
        {
            var result = 0;
            for (var i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                var cellValue = dataGridView[columnIndex, i].Value.ToString();
                if (int.TryParse(cellValue, out var parseResult))
                {
                    result += parseResult;
                }
                else
                {
                    throw new InvalidOperationException($"Не удалось преобразовать значение из ячейки {i}:{columnIndex} в тип int");
                }
            }
            return result;
        }
    }
}
