using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Models
{
    public class Position
    {
        private int[] _indexVals = new int[] { 0, 0 };

        public int[] Indexes { get { return _indexVals; } }

        public ChessPiece Piece { get; set; }
       

        public Position(int x, int y)
        {
            _indexVals[0] = x;
            _indexVals[1] = y;

        }

        public override string ToString()
        {
            if (Piece != null)
            {
                return Piece.ToString();
            }
            else
            {
                return "  ";
            }
        }
    }
}
