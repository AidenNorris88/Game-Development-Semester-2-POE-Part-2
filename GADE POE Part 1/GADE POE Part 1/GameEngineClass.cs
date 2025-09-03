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
            // === Fields ===
            private Level currentLevel;
            private int numLevels;
            private Random rng;

            private const int MIN_SIZE = 10;   // constants
            private const int MAX_SIZE = 20;

            public GameEngine(int numberOfLevels)  //constructor
            {
                numLevels = numberOfLevels;
                rng = new Random();

                // Randomize size of the level
                int width = rng.Next(MIN_SIZE, MAX_SIZE + 1);
                int height = rng.Next(MIN_SIZE, MAX_SIZE + 1);

                currentLevel = new Level(width, height);    // Create the level
            }

            // ToString override
            public override string ToString()
            {
                return currentLevel.RenderToString();
            }

            public Level CurrentLevel
            {
                get { return currentLevel; }
            }
        }
    }

}
