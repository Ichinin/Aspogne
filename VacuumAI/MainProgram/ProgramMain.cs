using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacuumRobot;
using Environment;
using System.Threading;

namespace MainProgram
{
    class ProgramMain
    {

        static void Main(string[] args)
        {
            //VacuumRobot.Main();
            //Environment.MainWindow window = new MainWindow();
            //Thread monthreadAspogne = new Thread(new ThreadStart(MainVacuum.Main));

            MainWindow MainWindow = new MainWindow();

            Thread monthreadEnvironment = new Thread(new ThreadStart(MainWindow.Show));

            monthreadAspogne.Start();
            Console.Read();
        }
    }
}
