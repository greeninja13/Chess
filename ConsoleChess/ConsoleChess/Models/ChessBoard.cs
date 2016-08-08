using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Models
{
    public class ChessBoard
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        Position[,] board = new Position[BOARD_WIDTH, BOARD_HEIGHT];

        public ChessBoard()
        {
            for(int x = 0; x < BOARD_WIDTH; x++)
            {
                for(int y = 0; y < BOARD_HEIGHT; y++)
                {
                    board[x, y] = new Position(x, y);
                }
            }
        }

        public bool AddPiece(ChessPiece piece, Position position)
        {
            int[] xy = position.Indexes;
            board[xy[0], xy[1]].Piece = piece;
            return true;
        }

        public bool MovePiece(Position initial, Position final)
        {
            int[] first = initial.Indexes;
            int[] second = final.Indexes;
            board[second[0], second[1]].Piece = board[first[0], first[1]].Piece;
            board[first[0], first[1]].Piece = null;
            return true;
        }

        public bool MoveAndTake(Position initial, Position final)
        {
            int[] second = final.Indexes;
            board[second[0], second[1]].Piece = null;
            MovePiece(initial, final);
            return true;
        }

        public bool MoveTwo(Position initial1, Position final1, Position initial2, Position final2)
        {
            MovePiece(initial1, final1);
            MovePiece(initial2, final2);
            return true;
        }

        public override string ToString()
        {
            string boardString = "-------------------------\n";

            int position = 8;
            for (int y = 0; y < BOARD_HEIGHT; y++)
            {
                for (int x = 0; x < BOARD_WIDTH; x++)
                {
                    boardString += "|" +board[x, y];
                }
                boardString += "|" +position-- +"\n-------------------------\n";
            }
            boardString += " A  B  C  D  E  F  G  H";

            return boardString;
        }
    }
}
