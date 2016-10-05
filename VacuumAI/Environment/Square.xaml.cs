using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Environment
{
    /// <summary>
    /// Interaction logic for Square.xaml
    /// </summary>
    public partial class Square : UserControl
    {
        /// <summary>
        /// Boolean to notify the presence or absence of dust.
        /// </summary>
        private bool m_bHasDust;
        /// <summary>
        /// Boolean to notify the presence or absence of jewel.
        /// </summary>
        private bool m_bHasJewel;
        /// <summary>
        /// Boolean to notify the presence or absence of vacuum.
        /// </summary>
        private bool m_bHasVacuum;

        /// <summary>
        /// Get / set the presence or absence of the vacuum on the square.
        /// </summary>
        public bool HasVacuum
        {
            get
            {
                return m_bHasVacuum;
            }
            set
            {
                m_bHasVacuum = value;
                vacuum.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        /// <summary>
        /// Get / set the presence or absence of jewels on the square.
        /// </summary>
        public bool HasJewel
        {
            get
            {
                return m_bHasJewel;
            }
            set
            {
                m_bHasJewel = value;
                jewel.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        /// <summary>
        /// Get / set the presence or absence of dust on the square.
        /// </summary>
        public bool HasDust
        {
            get
            {
                return m_bHasDust;
            }
            set
            {
                m_bHasDust = value;
                dust.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }

        /// <summary>
        /// Create a new square with no dust, jewel or vacuum.
        /// </summary>
        public Square()
        {
            InitializeComponent();
            HasDust = false;
            HasJewel = false;
            HasVacuum = false;
        }

    }
}
