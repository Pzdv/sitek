using Parser.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEK.Parser
{
    public interface IDocumentParser
    {
        IEnumerable<Employee> Parse(DocumentType docType);
    }
}
