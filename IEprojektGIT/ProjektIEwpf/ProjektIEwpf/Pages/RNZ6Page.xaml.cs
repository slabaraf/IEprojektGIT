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
    /// Interaction logic for RNZ6Page.xaml
    /// </summary>
    public partial class RNZ6Page : Page
    {
        public RNZ6Page()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            switch(WishClass.nav)
            {
                case 3:
                    this.NavigationService.Navigate(new Uri("Pages/RNZ3Page.xaml", UriKind.Relative));
                    break;
                case 4:
                    this.NavigationService.Navigate(new Uri("Pages/RNZ4Page.xaml", UriKind.Relative));
                    break;
                case 5:
                    this.NavigationService.Navigate(new Uri("Pages/RNZ5Page.xaml", UriKind.Relative));
                    break;
            }

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ7Page.xaml", UriKind.Relative));
        }
    }
}
