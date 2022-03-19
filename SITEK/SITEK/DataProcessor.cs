using Parser.Parser;
using SITEK.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEK
{
    internal class DataProcessor
    {
        private static List<Employee> JoinDocuments(List<Employee> rkkData, List<Employee> appealsData)
        {
            var leftOuter = (from x in rkkData
                             join y in appealsData on x.Name equals y.Name into temp
                             from z in temp.DefaultIfEmpty()
                             select new Employee
                             {
                                 Name = x.Name,
                                 RkkCount = x.RkkCount,
                                 AppealsCount = z == null ? 0 : z.AppealsCount
                             }).ToList();

            var rightOuter = (from x in appealsData
                              join y in rkkData on x.Name equals y.Name into temp
                              from z in temp.DefaultIfEmpty()
                              select new Employee
                              { 
                                  Name = x.Name,
                                  RkkCount = z == null ? 0 : z.RkkCount,
                                  AppealsCount = x.AppealsCount
                              }).ToList();

            var fullJoin = leftOuter.Union(rightOuter, new EmployeeComparer()).ToList();

            return fullJoin;
        }

        private static List<Employee> ParseDocument(string path, DocumentType docType)
        {
            try
            {
                var parser = ParserFactory.GetParser(path);
                var result = parser.Parse(docType).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Employee> ProcessData(string rkkPath, string appealsPath)
        {
            var rkkData = ParseDocument(rkkPath, DocumentType.RKK);
            var appealsData = ParseDocument(appealsPath, DocumentType.Appeal);

            var joinedData = JoinDocuments(rkkData, appealsData);

            return joinedData;
        }
    }
}
