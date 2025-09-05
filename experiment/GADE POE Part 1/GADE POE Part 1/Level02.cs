using GADE_POE_Part_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GADE_POE_Part_1
{
    internal class Level
    {
        // --- Fields ---
        private Tile[,] tiles;             // 2D map grid
        private HeroTile hero;             // reference to hero
        private ExitTile exit;             // reference to exit

        private static Random rng = new Random();

        // --- Properties ---
        public HeroTile Hero => hero;      // expose hero
        public ExitTile Exit => exit;      // expose exit
        public Tile[,] Tiles => tiles;     // expose whole grid

        public int Width { get; internal set; }
        public int Height { get; internal set; }

        // Enum that defines tile types
        public enum TileType
        {
            Empty,
            Wall,
            Hero,
            Exit
        }

        // --- Constructor ---
        public Level(int width, int height, HeroTile existingHero = null)
        {
            tiles = new Tile[width, height];
            InitializeTiles(width, height);

            // Place hero
            Position heroPos = GetRandomEmptyPosition();
            if (existingHero == null)
            {
                hero = (HeroTile)CreateTile(TileType.Hero, heroPos);
            }
            else
            {
                existingHero.Position = heroPos;
                tiles[heroPos.X, heroPos.Y] = existingHero;
                hero = existingHero;
            }

            // Place exit
            Position exitPos = GetRandomEmptyPosition();
            exit = (ExitTile)CreateTile(TileType.Exit, exitPos);
        }

        // --- CreateTile Method ---
        private Tile CreateTile(TileType type, Position pos)
        {
            switch (type)
            {
                case TileType.Empty:
                    tiles[pos.X, pos.Y] = new EmptyTile(pos);
                    break;
                case TileType.Wall:
                    tiles[pos.X, pos.Y] = new WallTile(pos);
                    break;
                case TileType.Hero:
                    tiles[pos.X, pos.Y] = new HeroTile(pos);
                    break;
                case TileType.Exit:
                    tiles[pos.X, pos.Y] = new ExitTile(pos);
                    break;
            }
            return tiles[pos.X, pos.Y];
        }

        // --- Fill map with walls and empty spaces ---
        private void InitializeTiles(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Position pos = new Position(x, y);

                    // Borders = walls
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        tiles[x, y] = new WallTile(pos);
                    else
                        tiles[x, y] = new EmptyTile(pos);
                }
            }
        }

        // --- Find random empty position ---
        private Position GetRandomEmptyPosition()
        {
            Position pos;
            do
            {
                int x = rng.Next(1, tiles.GetLength(0) - 1);
                int y = rng.Next(1, tiles.GetLength(1) - 1);
                pos = new Position(x, y);
            }
            while (!(tiles[pos.X, pos.Y] is EmptyTile));

            return pos;
        }

        // --- For drawing the map ---
        public override string ToString()
        {
            string map = "";

            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    map += tiles[x, y].Display;
                }
                map += "\n";
            }

            return map;
        }
    }
}
