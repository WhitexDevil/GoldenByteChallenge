using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePrototype
{
    class Squad
    {
        public Unit unit;
        public bool BelongToPlayer;
        public Squad target;
        public int amount;
        public int initiative;
        public int x;
        public int y;
        public string name;
        public int DamagedPoints;
        Random r = new Random(DateTime.Now.Millisecond);
        public Squad(Unit unit_, int amount_, string name_, bool belongToPlayer)
        {
            unit = unit_;
            amount = amount_;
            x = 0;
            y = 0;
            initiative = 0;
            name = name_;
            DamagedPoints = 0;
            BelongToPlayer = belongToPlayer;
        }

        public void setPos(int x_, int y_)
        {
            x = x_;
            y = y_;
        }

        public void setTarget(Squad t)
        {
            target = t;
        }

        public void rollInitiative()
        {
            //Random r= new Random();
            initiative = unit.InitiativeMod + r.Next(20);
        }

        bool rangeCheck()
        {
            int a = (target.x - x);
            int b = (target.y - y);
            if (Math.Sqrt(a * a + b * b) <= unit.Range)
                return true;
            else
                return false;
        }
        void doAttack()
        {
            int sum = 0;

            int def = target.unit.Defense;
            int atk = unit.Attack;
            int dmg = unit.Damage;
            int hit = 0;
            for (int i = 0; i < amount; i++)
            {
                hit = utilityAttack();

                if ((hit + atk) >= def)
                {
                    sum += dmg;
                    if (hit >= 20) //critical strike = x2 dmg
                    {
                        sum += dmg;
                        //Console.WriteLine(name+" Scored Critical strike");

                    }
                }
            }
            //Console.WriteLine(name + " damaged " + target.name + " by " + sum);

            target.doDefense(utilityDamage(sum));
        }

        void doDefense(int dmg)
        {
            dmg += DamagedPoints;
            int death = dmg / unit.MaxHitpoints;
            DamagedPoints = dmg % unit.MaxHitpoints;
            amount = amount - death;

            if (amount < 1)
            {
                //  Console.WriteLine( name + " was defeat");
                amount = 0;
                return;
            }

            //Console.WriteLine("In " + name + " lasts " + amount + " members");
        }
        public void fight()
        {
            if (rangeCheck()) doAttack();
            else
            {
                if (moveToTarget())
                    doAttack();

            }
        }

        bool moveToTarget()
        {
            int a = (target.x - x);
            int b = (target.y - y);
            int d = Convert.ToInt32(Math.Sqrt(a * a + b * b));
            int movd = unit.MovementSpead;
            if ((d - unit.Range) <= movd)
            {

                movd = d - unit.Range;
                if (movd < 0) return rangeCheck();
            }

            movd = d - movd; //- unit.Range;  //distanse after move

            x = target.x - Convert.ToInt32(movd * a / d);
            y = target.y - Convert.ToInt32(movd * b / d);

            //Console.WriteLine(name + " now @ (" + x + " , " + y + ')');
            return rangeCheck();
        }


        int utilityAttack()
        {
            int hit = 1 + r.Next(20);
            switch (unit.Race)
            {
                case race.elf:
                    if (hit <= 1)
                        hit = 1 + r.Next(20);
                    break;
                case race.barbarian:
                    if (hit >= 19)
                        hit = 20;
                    break;

            }
            return hit;

        }

        int utilityDamage(int s)
        {
            switch (target.unit.Race)
            {
                case race.undead:
                    if (unit.Range > 3)
                        s = (s / 2);
                    break;
                case race.dwarf:
                    if (unit.magic)
                        s = (s / 4);
                    break;
                case race.daemon:
                    if (unit.Range <= 5)
                        this.doDefense(5);
                    break;

            }
            return s;

        }




    }
}
