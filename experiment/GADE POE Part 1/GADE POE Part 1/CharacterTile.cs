using System;
using System.Runtime.Remoting.Messaging;

namespace GADE_POE_Part_1
{
    internal class CharacterTile : Tile
    {
        protected int hitPoints;
        protected int maxHitPoints;
        protected int attackPower;
        protected Tile[] vision;  // stores surrounding tiles (0-3)

        public int HitPoints { get => hitPoints; set => hitPoints = value; }
        public int MaxHitPoints { get => maxHitPoints; }
        public int AttackPower { get => attackPower; }
        public bool IsDead { get => hitPoints <= 0; }

        public CharacterTile(Position position, int hitPoints, int attackPower)
            : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            vision = new Tile[4];
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints < 0)
                hitPoints = 0;
        }

        public void Attack(CharacterTile target)
        {
            target.TakeDamage(this.attackPower);
        }

        public void UpdateVision(Level level)
        {
            Tile[,] map = level.Tiles;
            int x = this.X;
            int y = this.Y;

            // 0 = Up
            vision[0] = (y > 0) ? map[x, y - 1] : null;
            // 1 = Right
            vision[1] = (x < level.Width - 1) ? map[x + 1, y] : null;
            // 2 = Down
            vision[2] = (y < level.Height - 1) ? map[x, y + 1] : null;
            // 3 = Left
            vision[3] = (x > 0) ? map[x - 1, y] : null;
        }

        public int Heal(int amount)
        {
            hitPoints += amount;
            if (hitPoints > maxHitPoints)
            {
                hitPoints = maxHitPoints;
            }

            return hitPoints;
        }
       
        // Required because Tile is abstract
        public override char Display => '?'; // Or choose a suitable default
    }
}