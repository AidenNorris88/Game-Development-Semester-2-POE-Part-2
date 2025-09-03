using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    // creates the abstract class Tile
    internal abstract class Tile
    {
        //private field of type Position
        private Position Position;

        // this exposes the x value in the Position field
        public int X
        {
            get { return Position.X; }
            set { Position.X = value; }
        }

         //this exposes the y value in the position field
        public int Y
        {
            get { return Position.Y; } 
            set { Position.Y = value; }
        }

        //a constructor accept the position type as a parameter
        public Tile(Position beginningPosition)
        {
            Position = beginningPosition;
        }

        //an abstract property of type char named Display
        public abstract char Display { get; }
    }
}
