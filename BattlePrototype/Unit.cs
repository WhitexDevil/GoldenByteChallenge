using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePrototype
{
    public enum race
    {
        human, elf, dwarf,
        undead, daemon, barbarian
    };



    public class Unit
    {
        public int MaxHitpoints;
        public int MovementSpead;
        public race Race;
        public int Defense;
        public int Attack;
        public int Range;
        public int Damage;
        public int MaxAmount;
        public int InitiativeMod;
        public bool magic;


        public Unit(int initiative, int maxHitpoints, int defense, int attack, int damage, int movSpeed, int maxAmount, int range, race Race_)
        {
            MaxHitpoints = maxHitpoints;
            Defense = defense;
            Attack = attack;
            Range = range;
            Damage = damage;
            InitiativeMod = initiative;
            MovementSpead = movSpeed;
            MaxAmount = maxAmount;
            Race = Race_;
            magic = false;

        }


    }
}
