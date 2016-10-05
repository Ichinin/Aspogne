using System;
using System.Collections.Generic;
using System.Threading;

namespace VacuumRobot
{
    public class MainVacuum
    {
        public static void Main()
        {
            List<Environment.Square> table = Environment.MainWindow.m_lsGameSquare;
            Environment.Square[] path = { table [9], table[8], table[7], table[6], table[5], table[10],table[11],
                table[12], table[7], table[2], table[1], table[0], table[5], table[6], table[7], table[8] };
            RobotAI Nono = new RobotAI("Jojo3000", 200, path);
            path[0].HasVacuum = true;
            Console.Write("Jojo3000 initialisation over\n");

            while (Nono.AmIAlive())
            {
                Thread.Sleep(1000);
                //Nono.GetEnvironmentState();
                // Nono.DetermineActionUponMyGoal(Nono.GetEnvironmentState(), 0);
                Nono.DoAction(Nono.DetermineActionUponMyGoal(Nono.GetEnvironmentState(), 0));
            }
        }

    }
}
