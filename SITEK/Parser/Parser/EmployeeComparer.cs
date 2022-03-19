using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser
{
    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if(x == null || y == null)
            {
                return false;
            }

            if(ReferenceEquals(x, y))
            {
                return true;
            }

            return x.Name == y.Name;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            var hash = obj.Name.GetHashCode();
            return hash;
        }
    }
}
