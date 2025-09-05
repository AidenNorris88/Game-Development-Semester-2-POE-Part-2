using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal class Position
    {
        // integer fields storing x and y coordinates
        private int x;
        private int y;

        //constructor to accept the x and y values
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //properties to allows accesibility and modifiability of the x and y fields
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}
