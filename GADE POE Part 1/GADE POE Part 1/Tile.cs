using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal abstract class Tile
    {
        private Position Position;
        public int X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

        public int Y
        {
            get { return Position.Y; } 
            set { Position.Y = value; }
        }

        public Tile(Position beginningPosition)
        {
            Position = beginningPosition;
        }

        public abstract char Display { get; }
    }
}
