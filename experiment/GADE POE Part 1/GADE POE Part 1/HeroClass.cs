using System;

namespace GADE_POE_Part_1
{
    // Hero inherits from CharacterTile
    internal class Hero : CharacterTile
    {
        public string Name { get; set; }

        public Hero(Position position, int hitPoints, int attackPower)
            : base(position, hitPoints, attackPower)
        {
        }

        // Display character for the map
        public override char Display
        {
            get { return 'H'; }
        }

        // You can add extra Hero-specific logic here later
    }
}