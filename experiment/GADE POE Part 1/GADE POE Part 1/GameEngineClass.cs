using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GADE_POE_Part_1
{
    internal class GameEngineClass
    {
        public class GameEngine
        {
            private List<Level> levels;
            private int currentLevelIndex;
            private Random rng;

            private const int MIN_SIZE = 10;
            private const int MAX_SIZE = 20;

            public GameEngine(int numberOfLevels)
            {
                rng = new Random();
                levels = new List<Level>();

                for (int i = 0; i < numberOfLevels; i++)
                {
                    int width = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                    int height = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                    levels.Add(new Level(width, height));
                }
                currentLevelIndex = 0;
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
                return false;
            }

            public override string ToString()
            {
                return CurrentLevel.ToString();
            }

            public bool MoveHero(Direction direction)
            {
                return CurrentLevel.MoveHero(direction);
            }
        }
    }
}