using Environment;
using System;
using System.Threading;
using System.Windows;
using VacuumRobot;

namespace MainProgram
{
    class ProgramMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Start a new thread with a a vacuum.
            MainVacuum.Main();
            Thread monthreadVacuum = new Thread(new ThreadStart(MainVacuum.Main));

            // Start the environment WPF.
            CustomApplication app = new CustomApplication();
            app.Run();
        }
    }

    public class CustomApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
