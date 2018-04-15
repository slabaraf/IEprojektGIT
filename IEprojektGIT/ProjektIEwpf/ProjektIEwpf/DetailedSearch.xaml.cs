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
        bool czyGluten;
        private void Gluten_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            czyGluten = Gluten_ChckBx.IsChecked.Value;
        }
        bool czyLaktoza;
        private void Laktoza_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            czyLaktoza = Laktoza_ChckBx.IsChecked.Value;
        }
        bool czyOrzechy;
        private void Orzechy_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            czyOrzechy = Orzechy_ChckBx.IsChecked.Value;
        }
        bool czyNaturalny;
        private void Naturalny_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            czyNaturalny = Naturalny_ChckBx.IsChecked.Value;
        }
        bool czyWeganski;
        private void Weganski_ChckBx_Checked(object sender, RoutedEventArgs e)
        {
            czyWeganski = Weganski_ChckBx.IsChecked.Value;
        }
        string jakProducent;
        private void Producent_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jakProducent = Producent_LstBx.SelectedValue.ToString();
        }
        string jakKategoria;
        private void Kategoria_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            jakKategoria = Kategoria_LstBx.SelectedValue.ToString();
        }

        private void Forma_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string jakForma = Forma_LstBx.SelectedValue.ToString();
        }

        private void Nazwa_TxtBx_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Zapisz_Btn_Click(object sender, RoutedEventArgs e)
        {
            Window dgProducts = new DataGridWindow();
            dgProducts.Show();
        }

        private void Gluten_ChckBx_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
