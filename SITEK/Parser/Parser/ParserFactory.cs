using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEK.Parser
{
    public static class ParserFactory
    {
        public static IDocumentParser GetParser(string path)
        {
            var fileExtension = Path.GetExtension(path);

            return fileExtension switch
            {
                ".txt" => new TxtParser(path),
                _ => throw new NotImplementedException(message: $"Format {fileExtension} is not supported"),
            };
        }
    }
}
