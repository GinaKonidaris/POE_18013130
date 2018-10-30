using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public abstract class Building
    {
        public enum BuildingType { Dead, MeleeUnit, Hit, RangedUnit }
        public enum Orientation { Horizational, Vertical }

        protected int xpos;
        protected int ypos;
        protected int attack;
        protected int speed;
        protected int range;
        protected int team;
        protected int health;
        protected string symbol;



        abstract public void Combat(Building b);
        abstract public bool Inranged(Building b);
        abstract public Building Closest(Building[] buildings);
        abstract public bool Isdead();
        abstract public string Tostring();
        public class Tile
        {
            public BuildingType TileType { get; set; }
            public Orientation Orientation { get; set; }
        }

    }
}
