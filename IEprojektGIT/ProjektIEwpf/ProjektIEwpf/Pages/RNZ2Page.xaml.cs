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
    /// Interaction logic for RNZ2Page.xaml
    /// </summary>
    public partial class RNZ2Page : Page
    {
        public RNZ2Page()
        {
            InitializeComponent();
        }
        
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Radnio1.IsChecked == true)
            {
                WishClass.AddPointsAbove(1, 2);
                this.NavigationService.Navigate(new Uri("Pages/RNZ4Page.xaml", UriKind.Relative));
            }
            else if (Radnio2.IsChecked == true)
            {
                WishClass.AddPointsAbove(2, 2);
                this.NavigationService.Navigate(new Uri("Pages/RNZ5Page.xaml", UriKind.Relative));
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ1Page.xaml", UriKind.Relative));
        }
    }
}
