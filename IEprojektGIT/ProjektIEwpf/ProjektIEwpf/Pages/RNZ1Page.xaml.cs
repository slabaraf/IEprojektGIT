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
    /// Interaction logic for RNZ1Page.xaml
    /// </summary>
    public partial class RNZ1Page : Page
    {
        public RNZ1Page()
        {
            InitializeComponent();
        }
        WishClass x = new WishClass();

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Radnio1.IsChecked == true)
            {
                x.AddPointsAbove(0, 1);
            }
            else if (Radnio2.IsChecked == true)
            {
                x.AddPointsAbove(1, 1);
            }
            else if(Radnio3.IsChecked == true)
            {
                x.AddPointsAbove(2, 1);
            }
        }
    }
}
