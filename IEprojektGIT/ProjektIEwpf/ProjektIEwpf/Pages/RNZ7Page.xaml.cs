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
            this.NavigationService.Navigate(new Uri("Pages/RNZLastPage.xaml", UriKind.Relative));

            WishClass.queryString += " AND ";
            WishClass.initialLength = WishClass.queryString.Length;

            if (Vegan.IsChecked == true)
            {
                WishClass.queryString += "Produkt.Vegan = true";
            }

            if (Gluten.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Gluten = false";
            }
            else if (Gluten.IsChecked == true)
            {
                WishClass.queryString += " AND Produkt.Gluten = false";
            }

            if (Laktoza.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Laktoza = false";
            }
            else if (Laktoza.IsChecked == true)
            {
                WishClass.queryString += " AND Produkt.Laktoza = false";
            }

            if (Orzechy.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Orzechy = false";
            }
            else if (Orzechy.IsChecked == true)
            {
                WishClass.queryString += " AND Produkt.Orzechy = false";
            }

            if (ProduktNaturalny.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "[Produkt.Produkt naturalny] = true";
            }
            else if (ProduktNaturalny.IsChecked == true)
            {
                WishClass.queryString += " AND [Produkt.Produkt naturalny] = true";
            }

            WishClass.queryString = WishClass.queryString.Insert(WishClass.initialLength, "(");
            WishClass.queryString = WishClass.queryString.Insert(WishClass.queryString.Length, ")");

        }
    }
}
