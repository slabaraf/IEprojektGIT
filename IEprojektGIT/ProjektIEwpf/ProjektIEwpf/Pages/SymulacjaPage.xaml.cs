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
            if (LiczbaProduktowLstbx.SelectedItem is null)
            {
                PolecaneProdukty.LiczbaItemow = 8;
            }
            else
            {
                PolecaneProdukty.LiczbaItemow = Convert.ToInt32(LiczbaProduktowLstbx.SelectedValue.ToString().Substring(LiczbaProduktowLstbx.SelectedValue.ToString().Length - 2, 2));
            }
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

            int k = PolecaneProdukty.LiczbaItemow;

            for (int i = 1; i <= k; i++)
            {

                if (i <= Math.Ceiling(k*0.4))
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i-1].Text = ProductsCheckout.DoPolecenia[i].Nazwa + ", produced by " + ProductsCheckout.DoPolecenia[i].Producent + ", total cost: " + ProductsCheckout.DoPolecenia[i].Cena;
                    
                }
                else if (i <= Math.Ceiling(k*0.7)) //Convert.ToInt32(LiczbaProduktowLstbx.SelectedItem.ToString().Substring(LiczbaProduktowLstbx.SelectedItem.ToString().Length-1, 1)) / (10/4))
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i-1].Text = ProductsCheckout.DoPolecenia[i].Nazwa + ", produced by " + ProductsCheckout.DoPolecenia[i].Producent + ", total cost: " + ProductsCheckout.DoPolecenia[i].Cena;
                }
                else
                {
                    Itemy.Add(new TextBlock());
                    Itemy[i - 1].Text = ProductsCheckout.DoPolecenia[i].Nazwa + ", produced by " + ProductsCheckout.DoPolecenia[i].Producent + ", total cost: " + ProductsCheckout.DoPolecenia[i].Cena;
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
