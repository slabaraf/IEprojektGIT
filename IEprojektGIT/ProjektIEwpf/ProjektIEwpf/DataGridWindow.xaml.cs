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
using System.Data;
namespace ProjektIEwpf
{
    /// <summary>
    /// Interaction logic for DataGridWindow.xaml
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public DataGridWindow()
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

        private void lb_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
