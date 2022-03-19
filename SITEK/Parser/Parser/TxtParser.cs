using Parser.Parser;
using System.Text;

namespace SITEK.Parser
{
    public class TxtParser : IDocumentParser
    {
        private readonly string filePath;

        public TxtParser(string path)
        {
            filePath = path;
        }

        public IEnumerable<Employee> Parse(DocumentType docType)
        {
            string fileData;

            using (var sr = new StreamReader(filePath))
            {
                fileData = sr.ReadToEnd();
            }

            var lines = fileData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            var result = ParseLines(lines, docType);

            return result;
        }

        private static string FindName(string shortlyName, IEnumerable<string> lines)
        {
            var result = string.Empty;
            foreach (var line in lines)
            {
                var lastName = shortlyName.Split(" ")[0];

                var fullName = line.Split("\t")[0];
                if (fullName.StartsWith(lastName))
                {
                    result = fullName;
                    break;
                }
            }
            return string.IsNullOrEmpty(result) ? shortlyName : result;
        }

        private static IEnumerable<Employee> ParseLines(IEnumerable<string> lines, DocumentType docType)
        {
            var result = new List<Employee>();

            foreach (var line in lines)
            {
                var splitResult = line.Split("\t", StringSplitOptions.RemoveEmptyEntries);

                if (splitResult[0] == "Климов Сергей Александрович")
                {
                    var shortlyName = splitResult[1].Split(";")[0].Replace("(Отв.)", "").Trim();
                    var name = FindName(shortlyName, lines);
                    var employee = new Employee { Name =  name};
                    result.Add(employee);
                }
                else
                {
                    var employee = new Employee { Name = splitResult[0] };
                    result.Add(employee);
                }
            }

            var employees = GroupListEmployees(result, docType);
               
            return employees;
        }

        private static List<Employee> GroupListEmployees(List<Employee> employees, DocumentType docType)
        {
            var result = docType == DocumentType.RKK ?
                employees.GroupBy(x => x.Name).Select(x => new Employee { Name = x.Key, RkkCount = x.Count() }).ToList() :
                employees.GroupBy(x => x.Name).Select(x => new Employee { Name = x.Key, AppealsCount = x.Count() }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            return result;
        }
    }
}