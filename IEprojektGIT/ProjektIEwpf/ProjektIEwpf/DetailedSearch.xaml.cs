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
using System.Windows.Shapes;

namespace ProjektIEwpf
{
    /// <summary>
    /// Interaction logic for DetailedSearch.xaml
    /// </summary>
    public partial class DetailedSearch : Window
    {
        
        public DetailedSearch()
        {
            InitializeComponent();
        }

        private void NazwaTxtBx_Focus(object sender, RoutedEventArgs e)
        {
            Nazwa_TxtBx.Text = "";
        }

        private void Cena_TxtBx_Focus(object sender, RoutedEventArgs e)
        {
            Cena_TxtBx.Text = "";
        }

        private void Gluten_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            Rekomendator.CzyGluten = Gluten_ChckBx.IsChecked.Value;
        }

        private void Laktoza_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            Rekomendator.CzyLaktoza = Laktoza_ChckBx.IsChecked.Value;
        }

        private void Orzechy_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            Rekomendator.CzyOrzechy = Orzechy_ChckBx.IsChecked.Value;
        }
        
        private void Naturalny_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            Rekomendator.CzyNaturalny = Naturalny_ChckBx.IsChecked.Value;
        }

        private void Weganski_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            Rekomendator.CzyWegan = Weganski_ChckBx.IsChecked.Value;
        }
        
        private void Producent_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rekomendator.Producent = ((ListBoxItem)Producent_LstBx.SelectedValue).Content.ToString();
        }

        private void Kategoria_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int choice = 0;
            switch (((ListBoxItem)Kategoria_LstBx.SelectedValue).Content.ToString())
            {
                case "Izotoniki":
                    choice = 1;
                    break;
                case "Produkty startowe":
                    choice = 2;
                    break;
                case "Produkty regeneracyjne":
                    choice = 3;
                    break;
                case "Ochronne aparatu ruchu":
                    choice = 4;
                    break;
                case "Białko":
                    choice = 5;
                    break;
                case "Gainery":
                    choice = 6;
                    break;
                case "Spalacze tłuszczu":
                    choice = 7;
                    break;
                case "Na pompę mięśniową":
                    choice = 8;
                    break;
                case "Kompleksy witaminowe":
                    choice = 9;
                    break;
                case "Odporność":
                    choice = 10;
                    break;
                case "Pobudzenie energetyczne":
                    choice = 11;
                    break;
                case "Pobudzenie seksualne":
                    choice = 12;
                    break;
                case "Środek nasenny":
                    choice = 13;
                    break;
                default:
                    choice = 0;
                    break;

                    
            }
            Rekomendator.Kategoria = choice;
        }

        private void Forma_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int choice = 0;
            switch (((ListBoxItem)Forma_LstBx.SelectedValue).Content.ToString())
            {
                case "Tabletki":
                    choice = 1;
                    break;
                case "Tabletki rozpuszczalne":
                    choice = 2;
                    break;
                case "Prochy":
                    choice = 3;
                    break;
                case "Batony":
                    choice = 4;
                    break;
                case "Żele":
                    choice = 5;
                    break;
                case "Napoje":
                    choice = 6;
                    break;
                case "Maści":
                    choice = 7;
                    break;
                
                default:
                    choice = 0;
                    break;
            }
            Rekomendator.Forma = choice;
        }

        private void Nazwa_TxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nazwa_TxtBx.Text!= "Podaj nazwe")
            {
                Rekomendator.Nazwa = Nazwa_TxtBx.Text;
            }
            
        }

        private void Zapisz_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window dgProducts = new DataGridWindow();
            dgProducts.Show();
        }

        private void Cena_TxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = Cena_TxtBx.Text;
            int value;
            int.TryParse(input, out value);
            Rekomendator.Cena = value;
        }
    }
}
