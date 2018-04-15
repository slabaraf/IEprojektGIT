using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for SklepOkno.xaml
    /// </summary>
    public partial class SklepOkno : Window
    {
        public SklepOkno()
        {
            InitializeComponent();

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\admin\Desktop\Informatyka Ekonomiczna\Database5.accdb");
            con.Open();
            string queryString = "SELECT * FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lb_products.Items.Add(reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetValue(3));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
