using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GADE_POE_Part_1
{
    internal abstract class Tile
    {
        private Position _position;

        // Public property to expose Position
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public int Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        // Constructor
        public Tile(Position beginningPosition)
        {
            _position = beginningPosition;
        }

        // Abstract property for map display
        public abstract char Display { get; }
    }
}