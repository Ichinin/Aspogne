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
    /// Interaction logic for Square.xaml
    /// </summary>
    public partial class Square : UserControl
    {
        private bool m_bHasDust = true;
        private bool m_bHasJewels = true;
        private bool m_bHasVacuum = true;

        public Square()
        {
            InitializeComponent();

            //SquareGrid.Children
            //.Cast<UIElement>()
            //.First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);
        }

        public bool HasDust
        {
            get
            {
                return m_bHasDust;
            }
        }

        public bool HasJewels
        {
            get
            {
                return m_bHasJewels;
            }
        }

        public bool HasVacuum
        {
            get
            {
                return m_bHasVacuum;
            }
        }

        public void AddDust()
        {
            this.m_bHasDust = true;
            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
            uieSquare.Visibility = Visibility.Visible;
        }

        public void RemoveDust()
        {
            this.m_bHasDust = false;

            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
            uieSquare.Visibility = Visibility.Hidden;
        }

        public void AddJewels()
        {
            this.m_bHasJewels = true;

            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 1);
            uieSquare.Visibility = Visibility.Visible;
        }

        public void RemoveJewels()
        {
            this.m_bHasJewels = false;

            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 1);
            uieSquare.Visibility = Visibility.Hidden;
        }

        public void AddVacuum()
        {
            this.m_bHasVacuum = true;

            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);
            uieSquare.Visibility = Visibility.Visible;
        }

        public void RemoveVacuum()
        {
            this.m_bHasVacuum = false;

            UIElement uieSquare = SquareGrid.Children
            .Cast<UIElement>()
            .First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);
            uieSquare.Visibility = Visibility.Hidden;
        }
    }
}
