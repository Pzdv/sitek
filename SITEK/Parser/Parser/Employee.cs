using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parser
{
    public class Employee : IEquatable<Employee>
    {
        public string Name { get; set; }
        public int RkkCount { get; set; }
        public int AppealsCount { get; set; }

        public bool Equals(Employee? other)
        {
            if (other == null)
                return false;

            return Name.Split(" ")[0] == other.Name.Split(" ")[0];
        }
    }
}
