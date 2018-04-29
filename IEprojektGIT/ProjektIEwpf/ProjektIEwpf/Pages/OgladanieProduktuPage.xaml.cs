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

namespace ProjektIEwpf
{
    /// <summary>
    /// Interaction logic for OgladanieProduktuPage.xaml
    /// </summary>
    public partial class OgladanieProduktuPage : Page
    {
        public OgladanieProduktuPage()
        {
            InitializeComponent();

            ProductsCheckout.GetItem();
            ProductTitleLbl.Content = ProductsCheckout.Nazwa;
            IdLbl.Content = ProductsCheckout.Id;
            NazwaLbl.Content = ProductsCheckout.Nazwa;
            ProducentLbl.Content = ProductsCheckout.Producent;
            CenaLbl.Content = ProductsCheckout.Cena;
            KategoriaLbl.Content = ProductsCheckout.Kategoria;
            FormaLbl.Content = ProductsCheckout.Forma;
            WeganChckbx.IsChecked = ProductsCheckout.CzyWegan;
            GlutenChckbx.IsChecked = ProductsCheckout.CzyGluten;
            LaktozaChckbx.IsChecked = ProductsCheckout.CzyLaktoza;
            OrzechyChckbx.IsChecked = ProductsCheckout.CzyOrzechy;
            NaturalChckbx.IsChecked = ProductsCheckout.CzyNaturalny;
        }
    }
}
