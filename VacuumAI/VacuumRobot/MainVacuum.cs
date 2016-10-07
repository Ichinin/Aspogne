using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace VacuumRobot
{
    /// <summary>
    /// Main program.
    /// </summary>
    public class MainVacuum
    {
        /// <summary>
        /// Get the manor plan.
        /// </summary>
        private static List<Environment.Square> lsManor = Environment.MainWindow.SquareList;
        /// <summary>
        /// Create a new path for the robot to follow.
        /// </summary>
        private static Environment.Square[] asPath = { lsManor [9], lsManor[8], lsManor[7], lsManor[6], lsManor[5], lsManor[10],lsManor[11],
                lsManor[12], lsManor[7], lsManor[2], lsManor[1], lsManor[0], lsManor[5], lsManor[6], lsManor[7], lsManor[8] };
        /// <summary>
        /// Create a new robotAI Jojo with 100 points.
        /// </summary>
        private static RobotAI raiJojo = new RobotAI("Aspirobot T-0.1", 25, asPath);

        /// <summary>
        /// Run the RobotAI
        /// </summary>
        public static void Main()
        {
            asPath[0].HasVacuum = true;
            Console.Write("Aspirobot T-0.1 initialisation over\n");

            Thread tMyThreadRobotLife = new Thread(new ThreadStart(ThreadRobotStartingPoint));
            tMyThreadRobotLife.SetApartmentState(ApartmentState.STA);
            tMyThreadRobotLife.Start();

            raiJojo.Show();
            System.Windows.Forms.Application.Run();
        }

        /// <summary>
        /// Thread to run the robot through the manor.
        /// </summary>
        private static void ThreadRobotStartingPoint()
        {
            while (raiJojo.AmIAlive())
            {
                Thread.Sleep(1000);
                /* The function call execute the BDI model.
                 * - First we call GetEnvironmentState() which return the state of the environment.
                 * - The we call DetermineActionUponMyGoal() which determines which action will bring 
                 * the robot to its goal.
                 * Finally we call DoAction() which executes the action which has been chose,.
                 */
                raiJojo.GetEnvironmentState();
                raiJojo.DoAction(raiJojo.DetermineActionUponMyGoal(raiJojo.UpdateMyState()));
            }

            MessageBox.Show("The robot doesn't have any points left", "Robot died...", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }

    }
}

