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
        private bool m_bHasJewel = true;
        private bool m_bHasVacuum = true;

        /// <summary>
        /// 
        /// </summary>
        public bool HasVacuum
        {
            get
            {
                return m_bHasVacuum;
            }
            set
            {
                UIElement uieSquare = SquareGrid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);
                uieSquare.Visibility = value ? Visibility.Visible : Visibility.Hidden;
                m_bHasVacuum = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasJewel
        {
            get
            {
                return m_bHasJewel;
            }
            set
            {
                UIElement uieSquare = SquareGrid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 1);
                uieSquare.Visibility = value ? Visibility.Visible : Visibility.Hidden;
                m_bHasJewel = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasDust
        {
            get
            {
                return m_bHasDust;
            }
            set
            {
                UIElement uieSquare = SquareGrid.Children.Cast<UIElement>().First(e => Grid.GetRow(e) == 1 && Grid.GetColumn(e) == 0);
                uieSquare.Visibility = value ? Visibility.Visible : Visibility.Hidden;
                m_bHasDust = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Square()
        {
            InitializeComponent();

            //SquareGrid.Children
            //.Cast<UIElement>()
            //.First(e => Grid.GetRow(e) == 0 && Grid.GetColumn(e) == 0);
        }

        public void AddDust()
        {
            HasDust = true;
        }

        public void RemoveDust()
        {
            HasDust = false;
        }

        public void AddJewel()
        {
            HasJewel = true;
        }

        public void RemoveJewel()
        {
            HasJewel = false;
        }

        public void AddVacuum()
        {
            HasVacuum = true;
        }

        public void RemoveVacuum()
        {
            HasVacuum = false;
        }
    }
}
