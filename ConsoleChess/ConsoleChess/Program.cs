using ConsoleChess.Models;
using ConsoleChess.Models.Pieces;
using ConsoleChess.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    class Program
    {
        static ChessBoard board = new ChessBoard();
        static void Main(string[] args)
        {
            string filename = "";
            FileParser fP = new FileParser(board);

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                filename = args[0];
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + filename;

                Console.WriteLine("Using File: " +path);
                fP.ParseFile(path);

                Console.WriteLine(board);

            }
            else
            {
                Console.WriteLine("Empty file location in args");
            }

        }
    }
}
