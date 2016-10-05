using Environment;
using System.Threading;

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
            Thread monthreadEnvironnement = new Thread(new ThreadStart(ThreadEnvStartingPoint));
            monthreadEnvironnement.SetApartmentState(ApartmentState.STA);
            monthreadEnvironnement.Start();

            // Start a new thread with a a vacuum.
            /*MainVacuum.Main();
            Thread monthreadVacuum = new Thread(new ThreadStart(MainVacuum.Main));
            monthreadVacuum.Start();*/
        }

        /// <summary>
        /// Function started with the thread monthreadEnvironnement.
        /// </summary>
        private static void ThreadEnvStartingPoint()
        {
            MainWindow window = new MainWindow();
            window.Show();
            System.Windows.Threading.Dispatcher.Run();
        }
    }

}
