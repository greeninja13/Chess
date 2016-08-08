using ConsoleChess.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = "";
            FileParser fP = new FileParser();

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                location = args[0];
                Console.WriteLine("Using File: " +location);
                fP.ParseFile(location);
            }
            else
            {
                Console.WriteLine("Empty file location in args");
            }

        }
    }
}
