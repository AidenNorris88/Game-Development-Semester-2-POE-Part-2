using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal class CharacterTile : Tile
    {
        // === Fields ===
            protected int hitPoints;
            protected int maxHitPoints;
            protected int attackPower;
            protected Tile[] vision;  // stores surrounding tiles (0-4)

            // === Properties ===
            public int HitPoints { get => hitPoints; set => hitPoints = value; }
            public int MaxHitPoints { get => maxHitPoints; }
            public int AttackPower { get => attackPower; }
            public bool IsDead { get => hitPoints <= 0; }

        public override char Display => '?'; // Or any default character you want for CharacterTile
                                             // === Constructor ===
        public CharacterTile(Position position, int hitPoints, int attackPower)
                : base(position)
            {
                this.hitPoints = hitPoints;
                this.maxHitPoints = hitPoints;
                this.attackPower = attackPower;

                // Vision array has 4 slots for surrounding tiles
                vision = new Tile[4];
            }

            // === Methods ===
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

            int X = 0;
            int x = X;
            int Y = 0;
            int y = Y;

                // 0 = Up
                if (y > 0) vision[0] = map[y - 1, x];
                // 1 = Right
                if (x < level.Width - 1) vision[1] = map[y, x + 1];
                // 2 = Down
                if (y < level.Height - 1) vision[2] = map[y + 1, x];
                // 3 = Left
                if (x > 0) vision[3] = map[y, x - 1];
            }
        }
    }
