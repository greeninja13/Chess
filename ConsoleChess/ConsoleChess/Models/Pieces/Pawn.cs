using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Models.Pieces
{
    public class Pawn : ChessPiece
    {
        public bool FirstMove { get; private set; } = true;

        public Pawn()
        {
            Type = "P";
        }
    }
}
