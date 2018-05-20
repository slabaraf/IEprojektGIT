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
    /// Interaction logic for RNZ7Page.xaml
    /// </summary>
    public partial class RNZ7Page : Page
    {
        public RNZ7Page()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ6Page.xaml", UriKind.Relative));
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            WishClass.StringRNZ7 = " Gluten != " + Gluten.IsChecked + 
                " AND Vegan != " +Wegan.IsChecked + 
                " AND Produkt Naturalny != " + Naturalne.IsChecked;

            WishClass.ShowProducts();

            this.NavigationService.Navigate(new Uri("Pages/RNZLastPage.xaml", UriKind.Relative));
        }
    }
}
