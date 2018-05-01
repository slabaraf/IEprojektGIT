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
            //wszystkie te guziczki labelki i checkboxy musza miec info odnosnie wszystkiego (jak sie nazywa produkt, czy weganski, blablabla)
            //mamy to info w w ostatnim przegladnietym produkcie (wiec na ostatnim miejscu w slowniku Obejrzane = obejrzane.Count)
            ProductTitleLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Nazwa;
            IdLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Id;
            NazwaLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Nazwa;
            ProducentLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Producent;
            CenaLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Cena;
            KategoriaLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Kategoria;
            FormaLbl.Content = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].Forma;
            WeganChckbx.IsChecked = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].CzyWegan;
            GlutenChckbx.IsChecked = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].CzyGluten;
            LaktozaChckbx.IsChecked = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].CzyLaktoza;
            OrzechyChckbx.IsChecked = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].CzyOrzechy;
            NaturalChckbx.IsChecked = ProductsCheckout.Obejrzane[ProductsCheckout.Obejrzane.Count].CzyNaturalny;
        }
    }
}
