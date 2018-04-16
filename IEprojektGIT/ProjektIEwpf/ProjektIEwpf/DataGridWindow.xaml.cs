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
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\projekty\Jajebiekolejny\IEprojektGIT\Database5.accdb");
            con.Open();
            
            string queryString = ComputeInput();
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lb_products.Items.Add(reader.GetString(1) + ", " + reader.GetString(2) + ", " + reader.GetValue(3));
            }

            con.Close();

        }

        private void lb_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private string ComputeInput()
        {
            string path = "SELECT * FROM Produkt WHERE";

            if(Rekomendator.Producent!=null && Rekomendator.Producent!="--dowolny--")
            {
                path += (" [Producent] = '" + Rekomendator.Producent + "' ");
            }

            if (Rekomendator.Nazwa!=null)
            {
                if(path.Length==27)
                    path += (" [Nazwa] = '" + Rekomendator.Nazwa + "' ");
                else
                    path += (" AND [Nazwa] = '" + Rekomendator.Nazwa + "' ");
            }

            if (Rekomendator.Kategoria != 0)
            {
                if (path.Length == 27)
                    path += (" [Kategoria] = " + Rekomendator.Kategoria);
                else
                    path += (" AND [Kategoria] = " + Rekomendator.Kategoria);
            }

            if (Rekomendator.Forma != 0)
            {
                if (path.Length == 27)
                    path += (" [Forma] = " + Rekomendator.Forma);
                else
                    path += (" AND [Forma] = " + Rekomendator.Forma);
            }

            if (Rekomendator.CzyWegan)
            {
                if (path.Length == 27)
                    path += (" [Vegan] = " + Rekomendator.CzyWegan);
                else
                    path += (" AND [Vegan] = " + Rekomendator.CzyWegan);
            }

            if (Rekomendator.CzyGluten)
            {
                if (path.Length == 27)
                    path += (" [Gluten] = " + Rekomendator.CzyGluten);
                else
                    path += (" AND [Gluten] = " + Rekomendator.CzyGluten);
            }

            if (Rekomendator.CzyLaktoza)
            {
                if (path.Length == 27)
                    path += (" [Laktoza] = " + Rekomendator.CzyLaktoza);
                else
                    path += (" AND [Laktoza] = " + Rekomendator.CzyLaktoza);
            }
            if (Rekomendator.CzyOrzechy)
            {
                if (path.Length == 27)
                    path += (" [Orzechy] = " + Rekomendator.CzyOrzechy);
                else
                    path += (" AND [Orzechy] = " + Rekomendator.CzyOrzechy);
            }
            if (Rekomendator.CzyNaturalny)
            {
                if (path.Length == 27)
                    path += (" [Produkt naturalny] = " + Rekomendator.CzyNaturalny);
                else
                    path += (" AND [Produkt naturalny] = " + Rekomendator.CzyNaturalny);
            }
            if (Rekomendator.Cena != 0)
            {
                if (path.Length == 27)
                    path += (" [CENA] > " + (Rekomendator.Cena - 20) + " AND [Cena] < " + (Rekomendator.Cena + 20));
                else
                    path += (" AND [Cena] > " + (Rekomendator.Cena-20) + " AND [Cena] < " + (Rekomendator.Cena+20));
            }

            return path;
        }
    }
}
