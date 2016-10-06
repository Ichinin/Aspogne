using Environment;
using System.Threading;
using VacuumRobot;

namespace MainProgram
{
    /// <summary>
    /// program used to start both the Environment and the RobotAI.
    /// </summary>
    public class ProgramMain
    {
        /// <summary>
        /// Main which starts both the Environment and the RobotAI.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Start a new thread Environment.
            Thread tMyThreadEnvironnement = new Thread(new ThreadStart(ThreadEnvironmentStartingPoint));
            tMyThreadEnvironnement.SetApartmentState(ApartmentState.STA);
            tMyThreadEnvironnement.Start();
        }

        /// <summary>
        /// Function started with the thread tMyThreadEnvironnement.
        /// </summary>
        private static void ThreadEnvironmentStartingPoint()
        {
            MainWindow mwWindow = new MainWindow();
            mwWindow.Show();

            Thread tMyThreadRobotAI = new Thread(new ThreadStart(ThreadRobotStartingPoint));
            tMyThreadRobotAI.SetApartmentState(ApartmentState.STA);
            tMyThreadRobotAI.Start();

            System.Windows.Threading.Dispatcher.Run();
        }

        /// <summary>
        /// Function started with the thread tMyThreadRobotAI.
        /// </summary>
        private static void ThreadRobotStartingPoint()
        {
            MainVacuum.Main();
        }

    }
}
