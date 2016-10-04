using Environment;
using System;
using System.Threading;
using System.Timers;
using System.Windows;
using VacuumRobot;

namespace MainProgram
{
    class ProgramMain
    {


        [STAThread]
        static void Main(string[] args)
        {

            // Start the environment WPF.
            //CustomApplication app = new CustomApplication();
            //Thread monthreadEnvironnement = new Thread(new ThreadStart(app.Run()));


            Thread monthreadEnvironnement = new Thread(new ThreadStart(ThreadStartingPoint));
            monthreadEnvironnement.SetApartmentState(ApartmentState.STA);
            //monthreadEnvironnement.IsBackground = true;
            monthreadEnvironnement.Start();

            // Start a new thread with a a vacuum.
            /*MainVacuum.Main();
            Thread monthreadVacuum = new Thread(new ThreadStart(MainVacuum.Main));
            monthreadVacuum.Start();*/




        }

        public class EnvTimer : System.Timers.Timer
        {
            private MainWindow m_Windows;

            public EnvTimer(double interval, MainWindow p_Windows) : base(interval)
            {
                m_Windows = p_Windows;
            }

            public MainWindow Windows
            {
                get
                {
                    return m_Windows;
                }
            }
        }


        private static void ThreadStartingPoint()
        {
            MainWindow window = new MainWindow();

            EnvTimer aTimer = new EnvTimer(1000, window);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Start();


            window.Show();
            System.Windows.Threading.Dispatcher.Run();

            /*while (true)
            {

                MainWindow.GenerateObjects(2);

                Thread.Sleep(10000);

            }*/

        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            
            EnvTimer x = source as EnvTimer;
            //x.Enabled = false;
            x.Windows.GenerateObjects(2);
            x.Windows.UpdateLayout();
            x.Enabled = true;


            //MainWindow.GenerateObjects(2);
        }


    }













    /*public class CustomApplication : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
        }
    }*/
}
