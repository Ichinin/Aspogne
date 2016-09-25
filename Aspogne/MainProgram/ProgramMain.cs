using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspogne;
using Environment;
using System.Threading;

namespace MainProgram
{
    class ProgramMain
    {

        static void Main(string[] args)
        {
            ProgramAspogne.Main();
            //Environment.MainWindow window = new MainWindow();
            Thread monthreadAspogne = new Thread(new ThreadStart(ProgramAspogne.Main));
            //Thread monthreadEnvironment = new Thread(new ThreadStart(Environment.MainWindow.Run));

            monthreadAspogne.Start();
            Console.Read();
        }
    }
}
