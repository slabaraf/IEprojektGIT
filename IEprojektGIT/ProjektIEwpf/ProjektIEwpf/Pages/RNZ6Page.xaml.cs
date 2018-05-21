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
            this.NavigationService.GoBack();

        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/RNZ7Page.xaml", UriKind.Relative));

            if(Łykanie.IsChecked == true)
            {
                WishClass.queryString += "Produkt.Forma = 1";
            }

            if (Rozpuszanie.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 2";
            }
            else if (Rozpuszanie.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 2";
            }

            if (Proszki.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 3";
            }
            else if (Proszki.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 3";
            }

            if (Batony.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 4";
            }
            else if (Batony.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 4";
            }

            if (Żele.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 5";
            }
            else if (Żele.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 6";
            }

            if (Napoje.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 6";
            }
            else if (Napoje.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 6";
            }

            if (Maści.IsChecked == true && WishClass.queryString.Length == WishClass.initialLength)
            {
                WishClass.queryString += "Produkt.Forma = 7";
            }
            else if (Maści.IsChecked == true)
            {
                WishClass.queryString += " OR Produkt.Forma = 7";
            }

            WishClass.queryString = WishClass.queryString.Insert(WishClass.initialLength, "(");
            WishClass.queryString = WishClass.queryString.Insert(WishClass.queryString.Length, ")");
        }
    }
}
