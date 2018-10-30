﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class MeleeUnit : Unit
    {
        //The name of the Melee Unit
        private new string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        private int Xpos;

        public int xpos
        {
            get { return Xpos; }
            set { Xpos = value; }
        }

        private int Ypos;

        public int ypos
        {
            get { return Ypos; }
            set { Ypos = value; }
        }

        private int Health;

        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        private int Speed;

        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        private int Attack;

        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }

        private int InRanged;

        public int inranged
        {
            get { return InRanged; }
            set { InRanged = value; }
        }

        private int Faction;

        public int faction
        {
            get { return Faction; }
            set { Faction = value; }
        }
        private string Symbol;

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public int Team { get; internal set; }
        
        public MeleeUnit(int x, int y, int speed, int Range, int Health, int Team, string symbol, int attack, string name)
        {

            Xpos -= x;
            Ypos = y;
            Health = health;
            Speed = speed;
            Range = range;
            Team = team;
            Symbol = symbol;
            Attack = attack;
            Name = name;
        }

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                int d = (Xpos - n.Xpos) + Math.Abs(Ypos - n.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
       
        public override void Combat(Unit u)//the state of meleeunit during combat
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                health -= ((MeleeUnit)u).Attack;

            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                health -= ((RangedUnit)u).attack;
                health -= ((RangedUnit)u).attack;

            }
            else if ((u.GetType() == typeof(TwoHandedUnits)))
            {
                health -= ((TwoHandedUnits)u).attack;
                health -= ((TwoHandedUnits)u).attack;

            }
            else if (u.GetType() == typeof(ProphetsUnit))
            {
                health -= ((ProphetsUnit)u).attack;
                health -= ((ProphetsUnit)u).attack;

            }
            else if (u.GetType() == typeof(DoctorsUnit))
            {
                health -= ((DoctorsUnit)u).attack;
                health -= ((DoctorsUnit)u).attack;

            }
            else if (u.GetType() == typeof(AssasinUnit))
            {
                health -= ((AssasinUnit)u).attack;
                health -= ((AssasinUnit)u).attack;

            }

        }
        public override bool Inranged(Unit u)//This checks if meleeunit is inrange of other units on the field.
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                MeleeUnit n = (MeleeUnit)u;
                if (DistanceTo(u) <= range)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override Unit Closest(Unit[] units)
        {
            Unit closest = this;
            int closestDistance = 50;

            foreach (Unit u in units)
            {
                //if (u.GetType() == typeof(MeleeUnit))
                //{
                if (((MeleeUnit)u).team == team)
                {
                    if (DistanceTo(u) < closestDistance)
                    {
                        closest = u;
                        closestDistance = DistanceTo((MeleeUnit)u);
                    }
                }
                //}
                //else if(u.GetType() == typeof(RangedUnit))
                //{
                //    if (DistanceTo(u) < closestDistance)
                //    {
                //        closest = u;
                //        closestDistance = DistanceTo((RangedUnit)u);
                //    }
                //}
            }
            return closest;
        }
        public override bool Isdead()// checks to see if MeleeUnit is dead.
        {
            if (health < +0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string Tostring()// to display MeleeUnit information to users
        {
            return "MU" + Xpos + "," + Ypos + "," + health + "," + Name;
        }
    }
}
