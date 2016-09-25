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

            Grid _environnement = new Grid();

            RowDefinition RowGrid0 = new RowDefinition();
            RowDefinition RowGrid1 = new RowDefinition();
            RowDefinition RowGrid2 = new RowDefinition();
            _environnement.RowDefinitions.Add(RowGrid0);
            _environnement.RowDefinitions.Add(RowGrid1);
            _environnement.RowDefinitions.Add(RowGrid2);

            ColumnDefinition ColumnGrid0 = new ColumnDefinition();
            ColumnDefinition ColumnGrid1 = new ColumnDefinition();
            ColumnDefinition ColumnGrid2 = new ColumnDefinition();
            ColumnDefinition ColumnGrid3 = new ColumnDefinition();
            ColumnDefinition ColumnGrid4 = new ColumnDefinition();
            _environnement.ColumnDefinitions.Add(ColumnGrid0);
            _environnement.ColumnDefinitions.Add(ColumnGrid1);
            _environnement.ColumnDefinitions.Add(ColumnGrid2);
            _environnement.ColumnDefinitions.Add(ColumnGrid3);
            _environnement.ColumnDefinitions.Add(ColumnGrid4);
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Image imageCell = new Image();
                    Grid.SetRow(imageCell, i);
                    Grid.SetColumn(imageCell, j);

                    _environnement.Children.Add(imageCell);
                }
            }
        }
    }
}
