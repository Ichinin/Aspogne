using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumRobot;
using Environment;
using System.Threading;
using System.Diagnostics;

namespace MainProgram
{
    class ProgramMain
    {
        [STAThread]
        static void Main(string[] args)
        {
            MainVacuum.Main();
            //Environment.MainWindow window = new MainWindow();
            Thread monthreadAspogne = new Thread(new ThreadStart(MainVacuum.Main));

            //MainWindow mWin = new MainWindow();
            //mWin.Show();

            //Thread monthreadEnvironment = new Thread(new ThreadStart(MainWindow.Show));
            //monthreadEnvironment.SetApartmentState(ApartmentState.STA);
            //monthreadEnvironment.IsBackground = true;
            //monthreadEnvironment.Start();
            //monthreadAspogne.Start();
            //Console.Read();

            CustomApplication app = new CustomApplication();
            app.Run();

            //Process myProc;
            //myProc = Process.Start(@"L:\UQAC\Intelligence Artificielle\ProjetAgentIntelligent\VacuumAI\Environment\bin\Debug\Environment.exe");
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
