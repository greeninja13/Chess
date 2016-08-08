using ConsoleChess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess.Models
{
    public class ChessPiece
    {
        public string Name { get; set; }
        public Colors Color { get; set; }
        public Position[] PossibleMoves { get; private set; }
        

        public override string ToString()
        {
            return Name;
        }
    }
}
