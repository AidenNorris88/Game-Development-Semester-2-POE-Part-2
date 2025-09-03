using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_1
{
    internal class Level
    {
        // Enum for tile types
        public enum TileType
        {
            Empty,
            Wall
            // More values will be added later
        }

        private Tile[,] tiles;
        private int width;
        private int height;

        public int Width => width;
        public int Height => height;

        public Level(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
        }

        // Private CreateTile method
        private Tile CreateTile(TileType type, Position position)
        {
            Tile tile = null;

            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;
                    // More cases will be added as new tile types are introduced
            }

            // Place the tile in the 2D array using its position
            if (tile != null)
            {
                tiles[position.X, position.Y] = tile;
            }

            return tile;
        }

        // Optional: Overload for convenience
        private Tile CreateTile(TileType type, int x, int y)
        {
            return CreateTile(type, new Position(x, y));
        }

        // Example public method to expose tile creation (optional)
        public Tile PlaceTile(TileType type, int x, int y)
        {
            return CreateTile(type, x, y);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tile tile = tiles[x, y];
                    // If the tile is null, you can choose a default character (e.g., space or '.')
                    sb.Append(tile != null ? tile.Display : ' ');
                }
                sb.Append('\n'); // New line at the end of each row
            }

            return sb.ToString();
        }
    }
}
