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
    /// Interaction logic for Symulacja.xaml
    /// </summary>
    public partial class Symulacja : Page
    {
        public Symulacja()
        {
            InitializeComponent();
        }

        private void Symuluj_Click(object sender, RoutedEventArgs e)
        {
            List<ProductsCheckout> DoWyswietlenia = new List<ProductsCheckout>();

            PolecaneProdukty.CountTagPoints();
            PolecaneProdukty.CountCategoryPoints();
            PolecaneProdukty.DodawarkaPolecanych();

            List<TextBlock> ListadoStckPanelu = new List<TextBlock>(ListaItemowDoStackPanelu());
            foreach (TextBlock item in ListadoStckPanelu)
            {
                PoleconeStckpnl.Children.Add(item);
            }
        }

        private List<TextBlock> ListaItemowDoStackPanelu()
        {
            List<TextBlock> Itemy = new List<TextBlock>();
            if (LiczbaProduktowLstbx.SelectedItem == null)
            {
                LiczbaProduktowLstbx.SelectedItem = 4;

            }


            int j = 3;
            string mystring = LiczbaProduktowLstbx.SelectedValue.ToString().Substring(LiczbaProduktowLstbx.SelectedValue.ToString().Length - 1, 1);
            int k = Convert.ToInt32(mystring);

            for (int i = 1; i < k; i++)
            {

                if (i < k / 2.5)
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i-1].Text = ProductsCheckout.DoPolecenia[i].Nazwa + ProductsCheckout.DoPolecenia[i].Producent + ProductsCheckout.DoPolecenia[i].Cena;
                }
                else if (i < Convert.ToInt32(LiczbaProduktowLstbx.SelectedItem.ToString().Substring(LiczbaProduktowLstbx.SelectedItem.ToString().Length-1, 1)) / (10/4))
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i-1].Text = ProductsCheckout.DoPolecenia[j].Nazwa + ProductsCheckout.DoPolecenia[j].Producent + ProductsCheckout.DoPolecenia[j].Cena;
                    j++;
                }
                else
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i - 1].Text = ProductsCheckout.DoPolecenia[5].Nazwa + ProductsCheckout.DoPolecenia[5].Producent + ProductsCheckout.DoPolecenia[5].Cena;
                }

            }

            return Itemy;
        }

        private void btn_back(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/StartPage.xaml", UriKind.Relative));
        }
    }
}
