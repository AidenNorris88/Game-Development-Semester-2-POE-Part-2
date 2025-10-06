using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {

        }

        public override void ApplyEffect(CharacterTile hero)
        {
            hero.Heal(10);
        }
        public override char Display => '+';
    }
}
