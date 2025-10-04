using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{



    internal abstract class EnemyTile : CharacterTile
    {

        private EnemyTile[] Grunt
        {
            get { return Grunt; }
            set { Grunt = value; }
        }
        public EnemyTile(Position position, int hitPoints, int attackPower) : base(position, hitPoints, attackPower)
        {

        }



        public abstract bool GetMove(out Tile tile);

        public abstract CharacterTile[] GetTargets();


    }
}