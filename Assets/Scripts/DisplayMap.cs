using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DisplayMap : MonoBehaviour
    {

        public GameObject GroundTile;
        public GameObject hitTile;
        public GameObject DeadTile;
        public int size;
        private Maps map;

       
        // Use this for initialization
        void Start()
        {

            CreateMap();
            Display();

        }

        // Update is called once per frame
        void Update()
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("tile");

            foreach (GameObject g in gameObjects)
            {
                Destroy(g);
            }

            Display();
        }

        void CreateMap()
        {
            map = new Maps(size);
        }

        void Display()
        {
            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    switch (map.TileMap[x, z].TileType)
                    {
                        case UnitType.Dead:
                            Instantiate(GroundTile, new Vector3(x, 0, z), Quaternion.identity);
                            break;
                        case UnitType.MeleeUnit:
                            {
                                Instantiate(GroundTile, new Vector3(x, 0, z), Quaternion.identity);
                                break;
                            }
                        case UnitType.Hit:
                            if (map.TileMap[x, z].Orientation == Orientation.Vertical)
                            {
                                Instantiate(hitTile, new Vector3(x, 0, z), Quaternion.identity);
                                break;
                            }
                            else
                            {
                                Instantiate(hitTile, new Vector3(x, 0, z), Quaternion.Euler(0, 90, 0));
                                break;
                            }
                        case UnitType.RangedUnit:
                            Instantiate(DeadTile, new Vector3(x, 0, z), Quaternion.identity);
                            break;
                    }
                }
            }
        }

        public void Hit(int x, int y)
        {
            if (map.TileMap[x, y].TileType == UnitType.MeleeUnit)
            {
                map.TileMap[x, y].TileType = UnitType.Hit;
            }
            else
            {
                map.TileMap[x, y].TileType = UnitType.Dead;
            }
        }

    }
}
