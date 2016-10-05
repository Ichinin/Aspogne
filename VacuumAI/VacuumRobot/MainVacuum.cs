using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace VacuumRobot
{
    public class MainVacuum
    {
        public static void Main()
        {
            List<Environment.Square> table = Environment.MainWindow.m_lsGameSquare;
            Environment.Square[] path = { table [9], table[8], table[7], table[6], table[5], table[10],table[11],
                table[12], table[7], table[2], table[1], table[0], table[5], table[6], table[7], table[8] };
            RobotAI Nono = new RobotAI("Jojo", 200, path);
            path[0].HasVacuum = true;
            Console.Write("Jojo3000 initialisation over\n");

            /* Set the goal to be reached by the robot.
                 * The possible options are :
                 * 0 : The robot will focus on cleaning the room and picking up the jewels without caring for time or energy wasted.
                 * 1 : The robot will go as fast as possible, hoovering both dust and jewels.
                 * 2 : The robot will save as much energy as possible, staying on the same spot as a result.
                 */
            int iGoal = 0;

            while (Nono.AmIAlive())
            {
                Thread.Sleep(1000);
                /*
                 * 
                 * 
                 */
                Nono.DoAction(Nono.DetermineActionUponMyGoal(Nono.GetEnvironmentState(), iGoal));
            }

            MessageBox.Show("The robot doesn't have any points left", "Robot died...", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

    }
}
