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
        private bool m_bHasDust = false;
        private bool m_bHasJewels = false;
        private bool m_bHasVacuum = false;

        public bool HasDust
        {
            get
            {
                return m_bHasDust;
            }
        }
            

        public Square()
        {
            InitializeComponent();
        }

        private void AddDust()
        {
            this.m_bHasDust = true;
        }

        private void RemoveDust()
        {
            this.m_bHasDust = false;
        }

        private void AddJewels()
        {
            this.m_bHasJewels = true;
        }

        private void RemoveJewels()
        {
            this.m_bHasJewels = false;
        }

        private void AddVacuum()
        {
            this.m_bHasVacuum = true;
        }

        private void RemoveVacuum()
        {
            this.m_bHasVacuum = false;
        }
    }
}
