using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using ConsoleChess.Enums;
using ConsoleChess.Models;
using ConsoleChess.Models.Pieces;

namespace ConsoleChess.Tools
{
    public class FileParser
    {
        private ChessBoard board;
        
        public FileParser(ChessBoard board)
        {
            this.board = board;
        }

        public void ParseFile(string path)
        {
            Match match;
            string comments = @"//.*";
            string place = @"([BKNPQR])([dl])([abcdefgh][1-8]).*";
            string move2 = @"([abcdefgh][1-8])\s([abcdefgh][1-8])\s([abcdefgh][1-8])\s([abcdefgh][1-8]).*";
            string moveAndTake = @"([abcdefgh][1-8])\s([abcdefgh][1-8])\*.*";
            string move1 = @"([abcdefgh][1-8])\s([abcdefgh][1-8]).*";

            StreamReader file = new StreamReader(path);
            string currentLine = "";
            while ((currentLine = file.ReadLine()) != null)
            {
                match = Regex.Match(currentLine, comments);
                if (!match.Success)
                {
                    match = Regex.Match(currentLine, place);
                    if (match.Success)
                    {
                        char color = ' ';
                        char.TryParse(match.Groups[2].ToString(), out color);
                        char type = ' ';
                        char.TryParse(match.Groups[1].ToString(), out type);

                        Colors col = GetPieceColor(color);
                        string typ = GetPieceType(type);

                        Console.WriteLine(match.Groups[0] +": Place " +col +" " +typ +" at " +match.Groups[3]);

                        ChessPiece newPiece = null;
                        if (typ.Equals("Bishop"))
                        {
                            newPiece = new Bishop();
                        }
                        else if(typ.Equals("King"))
                        {
                            newPiece = new King();
                        }
                        else if (typ.Equals("Knight"))
                        {
                            newPiece = new Knight();
                        }
                        else if (typ.Equals("Pawn"))
                        {
                            newPiece = new Pawn();
                        }
                        else if (typ.Equals("Queen"))
                        {
                            newPiece = new Queen();
                        }
                        else if (typ.Equals("Rook"))
                        {
                            newPiece = new Rook();
                        }

                        newPiece.Color = col;
                        
                        board.AddPiece(newPiece, GetPosition(match.Groups[3].ToString()));
                    }
                    else if ((match = Regex.Match(currentLine, move2)).Success)
                    {
                        Console.WriteLine(match.Groups[0] + ": Move piece from " + match.Groups[1] + " to " + match.Groups[2] + " and piece " + match.Groups[3] +" to " +match.Groups[4]);
                        board.MoveTwo(GetPosition(match.Groups[1].ToString()), GetPosition(match.Groups[2].ToString()), GetPosition(match.Groups[3].ToString()), GetPosition(match.Groups[4].ToString()));
                    }
                    else if ((match = Regex.Match(currentLine, moveAndTake)).Success)
                    {
                        Console.WriteLine(match.Groups[0] + ": Move piece from " + match.Groups[1] + " to " + match.Groups[2] +" and take piece");
                        board.MoveAndTake(GetPosition(match.Groups[1].ToString()), GetPosition(match.Groups[2].ToString()));
                    }
                    else if ((match = Regex.Match(currentLine, move1)).Success)
                    {
                        Console.WriteLine(match.Groups[0] + ": Move piece from " + match.Groups[1] + " to " + match.Groups[2]);
                        board.MovePiece(GetPosition(match.Groups[1].ToString()), GetPosition(match.Groups[2].ToString()));
                    }
                }
            }

            
        }

        private Position GetPosition(string pos)
        {
            int x = 0;
            int y = 0;
            int.TryParse(pos[1].ToString(), out y);

            y = 8 - y;
            x = pos[0] - 97;

            return new Position(x, y);
        }

        private string GetPieceType(char match)
        {
            string ret = "";

            switch (match)
            {
                case 'B':
                    ret = "Bishop";
                    break;
                case 'K':
                    ret = "King";
                    break;
                case 'N':
                    ret = "Knight";
                    break;
                case 'P':
                    ret = "Pawn";
                    break;
                case 'Q':
                    ret = "Queen";
                    break;
                case 'R':
                    ret = "Rook";
                    break;
            }
            return ret;
        }

        private Colors GetPieceColor(char match)
        {
            Colors ret = Colors.Dark;
            if (match.Equals('l'))
            {
                ret = Colors.Light;
            }
            return ret;
        }
    }
}
