using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Environment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Contains the 15 squares of the game, labeled 0 to 14.
        /// </summary>
        public static List<Square> m_lsGameSquare = new List<Square>();
        /// <summary>
        /// Creation of a grid to act as the game set.
        /// </summary>
        private static Grid m_gEnvironnement = new Grid();
        /// <summary>
        /// Store the number of dust on the environment.
        /// </summary>
        private static int m_iDustNumber = 0;
        /// <summary>
        /// Store the number of jewel on the environment.
        /// </summary>
        private static int m_iJewelNumber = 0;
        /// <summary>
        /// Ration between the dust and jewel.
        /// </summary>
        private int m_iDustJewelRatio = 3;
        /// <summary>
        /// Timer usef for the environment generation.
        /// </summary>
        private DispatcherTimer m_dtTimer;

        /// <summary>
        /// Build an new WPF Mainwindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            RowDefinition m_rRowGrid0 = new RowDefinition();
            RowDefinition m_rRowGrid1 = new RowDefinition();
            RowDefinition m_rRowGrid2 = new RowDefinition();
            m_gEnvironnement.RowDefinitions.Add(m_rRowGrid0);
            m_gEnvironnement.RowDefinitions.Add(m_rRowGrid1);
            m_gEnvironnement.RowDefinitions.Add(m_rRowGrid2);

            ColumnDefinition m_cColumnGrid0 = new ColumnDefinition();
            ColumnDefinition m_cColumnGrid1 = new ColumnDefinition();
            ColumnDefinition m_cColumnGrid2 = new ColumnDefinition();
            ColumnDefinition m_cColumnGrid3 = new ColumnDefinition();
            ColumnDefinition m_cColumnGrid4 = new ColumnDefinition();
            m_gEnvironnement.ColumnDefinitions.Add(m_cColumnGrid0);
            m_gEnvironnement.ColumnDefinitions.Add(m_cColumnGrid1);
            m_gEnvironnement.ColumnDefinitions.Add(m_cColumnGrid2);
            m_gEnvironnement.ColumnDefinitions.Add(m_cColumnGrid3);
            m_gEnvironnement.ColumnDefinitions.Add(m_cColumnGrid4);

            PopulateSquare();

            Content = m_gEnvironnement;

            m_dtTimer = new DispatcherTimer();
            m_dtTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            m_dtTimer.Interval = new TimeSpan(0, 0, 1);
            m_dtTimer.Start();
        }

        /// <summary>
        /// The following method handle each tick of the DispatchedTimer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GenerateObjects(m_iDustJewelRatio);
        }

        /// <summary>
        /// Creates a list of 15 Squares, and address one to each cell of the environnement (0 -> 14).
        /// </summary>
        private void PopulateSquare()
        {
            // Adds 15 Square instances in the list
            for (int i = 0; i < 15; i++)
            {
                Square m_sGameSquare = new Square(i);
                m_lsGameSquare.Add(m_sGameSquare);
            }

            /* Creates a UserControl "Square" in each cell of the environnement
             * We increment k to address a different index of m_lGameSquare to each cell */
            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    // Adds a Square in the cell (i,j)
                    Grid.SetRow(m_lsGameSquare[k], i);
                    Grid.SetColumn(m_lsGameSquare[k], j);

                    m_gEnvironnement.Children.Add(m_lsGameSquare[k]);

                    // Remove everything from the 4 squares that aren't part of the environnement
                    if ((k == 3 || k == 4 || k == 13 || k == 14))
                    {
                        m_lsGameSquare[k].BorderThickness = new Thickness(1000);
                    }
                    k++;
                }
            }
        }

        /// <summary>
        /// Add dust on the square number DustLocation.
        /// </summary>
        /// <param name="p_iDustLocation"> Case location to add some dust. </param>
        private static void AddDust(int p_iDustLocation)
        {
            if (!(m_lsGameSquare[p_iDustLocation].HasVacuum))
            {
                m_lsGameSquare[p_iDustLocation].HasDust = true;
                m_iDustNumber++;
            }
        }

        /// <summary>
        /// Add a jewel on the square number JewelLocation.
        /// </summary>
        /// <param name="p_iJewelLocation"> Square location to add some jewel. </param>
        private static void AddJewel(int p_iJewelLocation)
        {
            if (!(m_lsGameSquare[p_iJewelLocation].HasVacuum))
            {
                m_lsGameSquare[p_iJewelLocation].HasJewel = true;
                m_iJewelNumber++;
            }
            m_lsGameSquare[p_iJewelLocation].HasJewel = true;
            m_iJewelNumber++;
        }

        /// <summary>
        /// Generate dust or jewel with a specified ratio.
        /// </summary>
        /// <param name="p_iDustJewelRatio"> Ratio between dust and jewel. A ration of two means we'll have 2 times more dust than jewel. </param>
        private void GenerateObjects(int p_iDustJewelRatio)
        {
            Random rand = new Random();
            int index = rand.Next(0, 13);

            if ((index != 3) && (index != 4))
            {
                if ((m_iDustNumber / (m_iJewelNumber + 1)) <= p_iDustJewelRatio)
                {
                    AddDust(index);
                }
                else
                {
                    AddJewel(index);
                }
            }
            else
            {
                index = rand.Next(0, 13);
            }
        }

    }
}
