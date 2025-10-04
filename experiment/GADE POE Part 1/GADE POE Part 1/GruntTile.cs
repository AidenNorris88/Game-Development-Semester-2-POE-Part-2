using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GADE_POE_Part_1;

namespace GADE_POE_Part_1
{
    internal class GruntTile : EnemyTile
    {
        new Tile[] vision;

        public GruntTile(Position position) : base(position, 10, 1)
        {
            Pos = position;
            vision = new Tile[0];
        }

        public GruntTile(Position position, int hitPoints, int attackPower, Tile[] vision) : base(position, 10, 1)
        {
            this.vision = vision ?? new Tile[0];

        }




        public override char Display
        {
            get
            {
                return IsDead ? 'x' : 'G';
            }
        }

        public Position Pos { get; }

        public override bool GetMove(out Tile tile)
        {
            List<Tile> emptyTiles = new List<Tile>();
            foreach (Tile visibleTile in vision)
            {
                tile = null;
                if (vision == null || vision.Length == 0)
                    return false;
                if (visibleTile is EmptyTile)
                {
                    emptyTiles.Add(visibleTile);
                }

            }
            if (emptyTiles.Count == 0)
            {
                tile = null;
                return false;

            }

            Random rng = new Random();
            tile = emptyTiles[rng.Next(emptyTiles.Count)];
            return true;

        }

        public override CharacterTile[] GetTargets()
        {
            if (vision == null)
                return new CharacterTile[0];
            foreach (Tile visibleTile in vision)
            {
                if (visibleTile is HeroTile)
                {

                    CharacterTile[] targets = new CharacterTile[1];
                    targets[0] = (CharacterTile)visibleTile;
                    return targets;

                }


            }
            return new CharacterTile[0];

        }


    }

}




