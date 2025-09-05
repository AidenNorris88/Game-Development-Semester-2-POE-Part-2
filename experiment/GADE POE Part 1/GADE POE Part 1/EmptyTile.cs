using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{//extends the Tile class
    internal class EmptyTile: Tile
    {
        //creates a constructor to accept a position parameter
        public EmptyTile(Position position): base ( position)
        {
           
        }

        //overides the get accessor of the Display property to return a '.' character
        public override char Display
        {
            get { return '.'; }
        }
           
    }
}
