using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlePrototype
{
    class sandbox
    {
        public sandbox()
        {

        }

        bool fight(Squad firstS, Squad secondS)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            bool result = false;
            firstS.setPos(10, 10 + r.Next(30));
            firstS.setTarget(secondS);
            secondS.setPos(10, 100);
            secondS.setTarget(firstS);
            List<Squad> squads = new List<Squad>();
            squads.Add(firstS);
            squads.Add(secondS);
            bool fight = true;
            int round = 0;
            while (fight)
            {
                foreach (var squad in squads)
                {

                    round++;
                    squad.fight();
                    if (squad.target.amount < 1)
                    {
                        fight = false;
                        // Console.WriteLine(squad.name + " win " + squad.target.name + " in " + round + " rounds!");
                        break;
                    }
                }


            }
            if (secondS.amount < 1)
                result = true;

            firstS.amount = firstS.unit.MaxAmount;
            secondS.amount = secondS.unit.MaxAmount;

            return result;
        }

        public void StartDuelSimulation(List<Squad> a, List<Squad> b, int number)
        {
            List<Squad> Firstlist = a;
            List<Squad> Secondlist = b;
            int sum = 0;
            foreach (var first in Firstlist)
            {
                foreach (var second in Secondlist)
                {

                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine(first.name + " VS " + second.name);
                    Console.WriteLine("============================================");
                    //Console.WriteLine("============================================");
                    // Console.WriteLine( first.name + " start first");
                    // Console.WriteLine("============================================");
                    for (int i = 1; i <= number; i++)
                    {
                        if (fight(first, second))
                            sum++;
                    }
                    Console.WriteLine(first.name + " win(s) " + second.name + " in " + sum + " of " + number + " fights");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    //Console.WriteLine("============================================");
                    // Console.WriteLine(second.name + " start first");
                    // Console.WriteLine("============================================");
                    sum = 0;
                    for (int i = 1; i <= number; i++)
                    {
                        if (fight(second, first))
                            sum++;
                    }
                    Console.WriteLine(second.name + " win(s) " + first.name + " in " + sum + " of " + number + " fights");
                    sum = 0;
                }

            }

        }


    }
}
