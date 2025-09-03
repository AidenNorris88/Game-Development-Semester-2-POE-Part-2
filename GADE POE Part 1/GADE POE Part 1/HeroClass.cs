using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal class HeroClass
    {
        public string Name { get; set; }
    }
        namespace BabyDungeonWinForms
    {
        // === Constructor ===
            public Hero(Position position, int hitPoints, int attackPower)
                : base(position, hitPoints, attackPower)
            {
            }

            // === Display character for the map ===
            public override char Display
            {
                get { return 'H'; }
            }

            // You can add extra Hero-specific logic here later
            // e.g., inventory, abilities, special moves, etc.
        }
    }

