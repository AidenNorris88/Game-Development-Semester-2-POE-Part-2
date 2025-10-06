using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GADE_POE_Part_1.GameEngineClass;

namespace GADE_POE_Part_1
{
    internal class HeroTile : CharacterTile
    {
        public HeroTile(Position position)
            : base(position, 40, 5) // 40 HP, 5 attack
        {
        }

        public override char Display
        {
            get
            {
                return IsDead ? 'X' : 'H';
            }
        }

     

    }
}
