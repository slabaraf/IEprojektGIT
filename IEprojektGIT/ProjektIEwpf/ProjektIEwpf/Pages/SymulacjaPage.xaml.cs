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

namespace ProjektIEwpf.Pages
{
    /// <summary>
    /// Interaction logic for Symulacja.xaml
    /// </summary>
    public partial class Symulacja : Page
    {
        public Symulacja()
        {
            InitializeComponent();
        }

        private void Symuluj_Click(object sender, RoutedEventArgs e)
        {
            PolecaneProdukty.CountTagPoints();
            PolecaneProdukty.CountCategoryPoints();
        }
    }
}
