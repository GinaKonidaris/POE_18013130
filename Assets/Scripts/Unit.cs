using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public enum UnitType { Dead, MeleeUnit, Hit,RangedUnit}
    public enum Orientation { Horizational, Vertical }

    public class Tile
    {
        public UnitType TileType { get; set; }
        public Orientation Orientation { get; set; }
    }
    public abstract class Unit
    {
        // All other classes inherit from this class.
        protected int xpos;
        protected int ypos;
        protected int attack;
        protected int speed;
        protected int range;
        protected int team;
        protected int health;
        protected string symbol;
        protected string Name;

        abstract public void Combat(Unit u);
        abstract public bool Inranged(Unit u);
        abstract public Unit Closest(Unit[] units);
        abstract public bool Isdead();
        abstract public string Tostring();
    }
}
