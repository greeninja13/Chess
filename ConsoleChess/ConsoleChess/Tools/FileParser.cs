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
        public string[] ParseFile(string path)
        {
            StreamReader file = new StreamReader(path);
            string currentLine = "";
            while ((currentLine = file.ReadLine()) != null)
            {
                Console.WriteLine(currentLine);
            }


            return new string[0];
        }
    }
}
