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
    /// Interaction logic for RNZ4Page.xaml
    /// </summary>
    public partial class RNZ4Page : Page
    {
        public RNZ4Page()
        {
            InitializeComponent();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Radnio1.IsChecked == true)
            {
                WishClass.AddPointsAbove(1, 1);
                WishClass.AddPointsUnder(1, 1, 3);
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio2.IsChecked == true)
            {
                WishClass.AddPointsAbove(1, 1);
                WishClass.AddPointsUnder(1, 2, 3);
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio3.IsChecked == true)
            {
                WishClass.AddPointsAbove(1, 1);
                WishClass.AddPointsUnder(1, 3, 3);
                WishClass.AddPointsUnder(3, 2, 1);
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio4.IsChecked == true)
            {
                WishClass.AddPointsAbove(1, 1);
                WishClass.AddPointsUnder(1, 4, 3);
                WishClass.AddPointsUnder(3, 2, 1);
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            WishClass.nav = 4;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ2Page.xaml", UriKind.Relative));

        }
    }
}
