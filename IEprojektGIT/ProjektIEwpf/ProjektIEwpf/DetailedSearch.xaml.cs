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
    }
}
