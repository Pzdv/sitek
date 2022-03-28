using Parser.Parser;
using SITEK.Parser;
using System.ComponentModel;
using System.Diagnostics;

namespace SITEK
{
    public partial class Form1 : Form
    {
        private string rkkPath = null!;
        private string appealsPath = null!;
        private readonly DateTime startedTime;

        public Form1()
        {
            InitializeComponent();
            startedTime = DateTime.Now;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (sender is Button button)
            {
                var filePath = openFileDialog1.FileName;
                SetSelectButtonLabelText(button, openFileDialog1.SafeFileName, filePath);
            }
        }

        private void SetSelectButtonLabelText(Button button, string text, string path)
        {
            switch (button.Name)
            {
                case "rkkButton":
                    selectedRkkFile.Text = text;
                    rkkPath = path;
                    break;
                case "appealButton":
                    selectedAppealFile.Text = text;
                    appealsPath = path;
                    break;
                default:
                    throw new NotImplementedException(message: $"There is no method implementation for this button.{Environment.NewLine}" +
                        $"Method: {nameof(SetSelectButtonLabelText)}{Environment.NewLine}" +
                        $"Button: {button.Name}");
            }
        }

        private void FillDataGrid(List<Employee> joinedData)
        {
            dataGridView1.Rows.Clear();

            foreach (var emp in joinedData)
            {
                dataGridView1.Rows.Add(emp.Name, emp.RkkCount, emp.AppealsCount, emp.RkkCount + emp.AppealsCount);
            }
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(rkkPath))
                {
                    MessageBox.Show("Select a rkk document");
                }
                else if (string.IsNullOrEmpty(appealsPath))
                {
                    MessageBox.Show("Select a appeals document");
                }
                else
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    var data = DataProcessor.ProcessData(rkkPath, appealsPath);
                    sw.Stop();
                    var workTimeSeconds = (double)sw.ElapsedMilliseconds / 1000;
                    workTimeValue.Text = Math.Round(workTimeSeconds, 4).ToString(); 
                    FillDataGrid(data);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name != "Name")
            {
                switch (e.Column.Name)
                {
                    case "RKK":
                        SortByRKK(e);
                        break;
                    case "Appeals":
                        SortByAppeals(e);
                        break;
                    case "Total":
                        SortByTotal(e);
                        break;
                    default:
                        throw new NotImplementedException(message: "There is no implementation for this type of sorting");

                }
            }
        }

        private void SortByTotal(DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = ((int)e.CellValue1).CompareTo((int)e.CellValue2);

            if (e.SortResult == 0)
            {
                var row1 = (int)dataGridView1.Rows[e.RowIndex1].Cells["RKK"].Value;
                var row2 = (int)dataGridView1.Rows[e.RowIndex2].Cells["RKK"].Value;
                e.SortResult = row1.CompareTo(row2);
            }
            e.Handled = true;
        }

        private void SortByAppeals(DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = ((int)e.CellValue1).CompareTo((int)e.CellValue2);

            if (e.SortResult == 0)
            {
                var row1 = (int)dataGridView1.Rows[e.RowIndex1].Cells["RKK"].Value;
                var row2 = (int)dataGridView1.Rows[e.RowIndex2].Cells["RKK"].Value;
                e.SortResult = row1.CompareTo(row2);
            }
            e.Handled = true;
        }

        private void SortByRKK(DataGridViewSortCompareEventArgs e)
        {
            e.SortResult = ((int)e.CellValue1).CompareTo((int)e.CellValue2);

            if (e.SortResult == 0)
            {
                var row1 = (int)dataGridView1.Rows[e.RowIndex1].Cells["Appeals"].Value;
                var row2 = (int)dataGridView1.Rows[e.RowIndex2].Cells["Appeals"].Value;

                e.SortResult = row1.CompareTo(row2);
            }
            e.Handled = true;
        }

        private void SaveAsRtfButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            saveFileDialog1.ShowDialog();
            var path = saveFileDialog1.FileName;

            var extension = Path.GetExtension(path);

            if(extension != ".rtf")
            {
                path += ".rtf";
            }

            var rtfWriter = new RtfWriter();

            rtfWriter.Save(path, dataGridView1, startedTime);
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].HeaderCell.Value = (dataGridView1.Rows.Count - 1).ToString();
        }
    }
}