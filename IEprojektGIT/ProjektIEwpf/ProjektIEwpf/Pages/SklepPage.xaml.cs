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
using System.Data.OleDb;

namespace ProjektIEwpf
{
    /// <summary>
    /// Interaction logic for SklepPage.xaml
    /// </summary>
    public partial class SklepPage : Page
    {

        public SklepPage()
        {
            InitializeComponent();
            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString = "SELECT [Nazwa], [Producent] FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

           

            while (reader.Read())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(reader.GetValue(0) + ", " + reader.GetValue(1));
                lb_products.Items.Add(sb);
            }

            reader.Close();
        }

        private void Obejrzyj_Click(object sender, RoutedEventArgs e)
        {
            if (!(lb_products.SelectedItem is null))
            {
                //Dictionary Obejrzane<int,Productscheckout> sluzy do gromadzenia info o tym, jakie produkty ktos ogladal
                //Add(ProductsCheckout.Obejrzane.Count+1,...) - na poczatku nie ma nic, wiec Obejrzane.Count zwraca zero, dodajemy 1 zeby sie dodalo cos
                //na "nastepnej pozycji", potem count zwroci 1 wiec dodamy na miejscu 2 etc.
                ProductsCheckout.Obejrzane.Add(ProductsCheckout.Obejrzane.Count + 1, new ProductsCheckout());
                //stworzylismy pusty obiekt ProductsCheckout (ktory zawiera cale info o produkcie (id,kategoria,nazwa,blabla)
                //wiec przypisujemy temu produktowi id takie jak w listboksie, zeby sie zgadzalo (produkt 3 w listboksie=produkt 3 w bazie)
                ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Id = lb_products.SelectedIndex + 1;
                //GetItem() wg tego podanego Id wbija sie na pelnej w baze danych i wyciaga info spod tego Id
                ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].GetItem();
                //jak juz mamy wyciagniete info to otwieramy strone z przegladem tego info
                this.NavigationService.Navigate(new Uri("Pages/OgladanieProduktuPage.xaml", UriKind.Relative));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

