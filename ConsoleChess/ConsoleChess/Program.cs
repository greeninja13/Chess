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
            FileParser fP = new FileParser();

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                filename = args[0];
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + filename;

                Console.WriteLine("Using File: " +path);
                fP.ParseFile(path);

                ChessPiece pawn = new Pawn() { Color = Enums.Colors.Dark, Name="Pd"};
                Position a8 = new Position(0, 0);
                board.AddPiece(pawn, a8);

                Console.WriteLine(board);

                Console.ReadLine();

                Position d5 = new Position(3, 3);

                board.MovePiece(a8, d5);

                Console.WriteLine(board);

                
            }
            else
            {
                Console.WriteLine("Empty file location in args");
            }

        }
    }
}
