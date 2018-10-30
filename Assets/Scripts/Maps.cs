using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class Maps
    {
        private Tile[,] tileMap;
        private int size;
        private Random r;
        public Tile[,] TileMap
        {
            get { return tileMap; }
            set { tileMap = value; }
        }

        public Maps(int size)
        {
            r = new Random();
            size = size;
            tileMap = new Tile[size, size];

            //Create an empty ocean
            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    Tile t = new Tile();
                    t.TileType = UnitType.RangedUnit;
                    tileMap[x, z] = t;
                }
            }

            //Create and place the ships
            for (int i = 0; i < 5; i++)
            {
                int buffer = i + 1;
                int x = r.Next(buffer, size - buffer);
                int y = r.Next(buffer, size - buffer);
                int d = r.Next(0, 100);
                if (d >= 50) //vertical
                {
                    for (int j = 0; j <= i; j++)
                    {
                        tileMap[x, y + j].TileType = UnitType.MeleeUnit;
                        tileMap[x, y + j].Orientation = Orientation.Vertical;

                    }
                }
                else //horiztional
                {
                    for (int j = 0; j <= i; j++)
                    {
                        tileMap[x + j, y].TileType = UnitType.MeleeUnit;
                        tileMap[x, y + j].Orientation = Orientation.Horizational;
                    }

                }
            }
        }
    }
}
