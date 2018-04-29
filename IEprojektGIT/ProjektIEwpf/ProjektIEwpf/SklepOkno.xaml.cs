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
            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();
            string queryString = "SELECT * FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < 10; i++)
                {
                    sb.Append(reader.GetValue(i) + ", ");
                    
                }
                sb.Append(reader.GetValue(10));
                lb_products.Items.Add(sb);
                //lb_products.Items.Add(reader.GetValue(1) + ", " + reader.GetValue(2) + ", " + reader.GetValue(3));
            }

            reader.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\admin\Desktop\Informatyka Ekonomiczna\Database5.accdb");
            //con.Open();
            //string queryString = "SELECT * FROM Produkt";
            //OleDbCommand cmd = new OleDbCommand(queryString, con);
            //OleDbDataReader reader = cmd.ExecuteReader();

            //while (reader.Read())
            //{
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 1; i < 10; i++)
            //    {
            //        sb.Append(reader.GetValue(i) + ", ");

            //    }
            //    sb.Append(reader.GetValue(10));
            //    lb_products.Items.Add(sb);
            //    //lb_products.Items.Add(reader.GetValue(1) + ", " + reader.GetValue(2) + ", " + reader.GetValue(3));
            //}
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
