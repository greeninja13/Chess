using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleChess.Tools
{
    public class FileParser
    {
        public string[] ParseFile(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), filename);
            StreamReader file = new StreamReader(path);

            return new string[0];
        }
    }
}
