using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Environment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Grid m_gEnvironnement = new Grid();

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

            List<Square> m_lGameSquare = new List<Square>();
            for (int i = 0; i < 15; i++)
            {
                Square m_sGameSquare = new Square();
                m_lGameSquare.Add(m_sGameSquare); 
            }

            int k = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Grid.SetRow(m_lGameSquare[k], i);
                    Grid.SetColumn(m_lGameSquare[k], j);

                    m_gEnvironnement.Children.Add(m_lGameSquare[k]);

                    if ((k == 3 || k == 4 || k == 13 || k == 14))
                    {
                        m_lGameSquare[k].RemoveJewels();
                        m_lGameSquare[k].RemoveDust();
                        m_lGameSquare[k].RemoveVacuum();
                    }
                    k++;
                }
            }

            Content = m_gEnvironnement;
           
        }
    }
}
