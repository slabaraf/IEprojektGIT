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
    /// Interaction logic for RNZ5Page.xaml
    /// </summary>
    public partial class RNZ5Page : Page
    {
        public RNZ5Page()
        {
            InitializeComponent();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Radnio1.IsChecked == true) //5.1
            {
                WishClass.CatPoints[1] += 1;
                WishClass.SubCatPoints[4] += 3;
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio2.IsChecked == true) //5.2
            {
                WishClass.CatPoints[1] += 1;
                WishClass.SubCatPoints[5] += 3;
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio3.IsChecked == true) //5.3
            {
                WishClass.CatPoints[1] += 1;
                WishClass.SubCatPoints[6] += 3;
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
            if (Radnio4.IsChecked == true) //5.4
            {
                WishClass.CatPoints[1] += 1;
                WishClass.SubCatPoints[7] += 3;
                this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ2Page.xaml", UriKind.Relative));
        }

        
    }
}
