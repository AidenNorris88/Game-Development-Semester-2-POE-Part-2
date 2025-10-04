using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace GADE_POE_Part_1
{
    internal class GameEngineClass
    {
        public class GameEngine
        {
            private List<Level> levels = new List<Level>();
            private int currentLevelIndex;
            private Random rng;
            private int v;
            private const int MIN_SIZE = 10;
            private const int MAX_SIZE = 20;
            private int currentLevelNumber = 1;
            public GameEngine(int numberOfLevels, int numberofEnemies, int currentLevelNumber)
            {
                rng = new Random();
                levels = new List<Level>();

                for (int i = 0; i < numberOfLevels; i++)
                {
                    int width = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                    int height = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                    levels.Add(new Level(width, height, numberofEnemies));
                    currentLevelNumber++;
                }
                currentLevelIndex = 0;

            }

            public GameEngine(int v)
            {
                this.v = v;
            }

            public Level CurrentLevel
            {
                get { return levels[currentLevelIndex]; }
            }

            public bool NextLevel()
            {
                if (currentLevelIndex < levels.Count - 1)
                {
                    currentLevelIndex++;
                    return true;
                }
                else
                {
                    int width = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                    int height = rng.Next(MIN_SIZE, MAX_SIZE + 1);

                    currentLevelNumber++;
                    levels.Add(new Level(width, height, currentLevelNumber));
                    currentLevelIndex++;
                }
                return false;
            }

            public override string ToString()
            {
                return CurrentLevel.ToString();
            }

            public int HeroCounter = 0;
            public bool MoveHero(Direction direction)
            {
                bool moved = CurrentLevel.MoveHero(direction);
                if (moved)
                {
                    HeroCounter++;
                    CurrentLevel.UpdateVision();
                }

                if (HeroCounter == 2)
                {
                    TriggerMovement();
                }

                return moved;
            }

            private void MoveEnemies()
            {
                
                foreach (EnemyTile enemy in CurrentLevel.GetEnemies())
                {
                    if (enemy.IsDead)
                        continue; // Skip dead enemies

                    if (!enemy.GetMove(out Tile targetTile))
                        continue; // Skip if no move available

                    CurrentLevel.SwapTiles(enemy, targetTile); // Move enemy
                    CurrentLevel.UpdateVision(); // Update vision for all
                }
            }

            public void TriggerMovement()
            {
                MoveEnemies();
            }

        }
    }
}