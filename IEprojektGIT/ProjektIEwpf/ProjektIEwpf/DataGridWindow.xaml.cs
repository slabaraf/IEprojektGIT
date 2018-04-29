using System;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.IO;

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

            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+path);
            con.Open();
            
            string queryString = ComputeInput();
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {                                                                      
                lb_products.Items.Add(reader.GetString(0) + ", " + reader.GetString(1) + ", " + reader.GetValue(2));
            }

            con.Close();

        }

        private void lb_products_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private string ComputeInput()
        {
            string path = "SELECT [Nazwa], [Producent], Kategoria.Przeznaczenie FROM Produkt, Kategoria";
            int initialLength = path.Length;

            if(Rekomendator.Producent!=null && Rekomendator.Producent!="--dowolny--")
            {
                path += (" [Producent] = '" + Rekomendator.Producent + "' ");
            }

            if (Rekomendator.Nazwa!=null)
            {
                if(path.Length == initialLength)
                    path += (" [Nazwa] = '" + Rekomendator.Nazwa + "' ");
                else
                    path += (" AND [Nazwa] = '" + Rekomendator.Nazwa + "' ");
            }

            if (Rekomendator.Kategoria != 0)
            {
                if (path.Length == initialLength)
                    path += (" WHERE [Kategoria] = "+Rekomendator.Kategoria+" AND Kategoria.Id = "+Rekomendator.Kategoria);
                else
                    path += (" AND [Kategoria] = " + Rekomendator.Kategoria);
            }

            if (Rekomendator.Forma != 0)
            {
                if (path.Length == initialLength)
                    path += (" WHERE [Forma] = " + Rekomendator.Forma);
                else
                    path += (" AND [Forma] = " + Rekomendator.Forma);
            }

            if (Rekomendator.CzyWegan)
            {
                if (path.Length == initialLength)
                    path += (" WHERE [Vegan] = " + Rekomendator.CzyWegan);
                else
                    path += (" AND [Vegan] = " + Rekomendator.CzyWegan);
            }

            if (Rekomendator.CzyGluten)
            {
                if (path.Length == initialLength)
                    path += (" WHERE [Gluten] = " + Rekomendator.CzyGluten);
                else
                    path += (" AND [Gluten] = " + Rekomendator.CzyGluten);
            }

            if (Rekomendator.CzyLaktoza)
            {
                if (path.Length == initialLength)
                    path += (" WHERE [Laktoza] = " + Rekomendator.CzyLaktoza);
                else
                    path += (" AND [Laktoza] = " + Rekomendator.CzyLaktoza);
            }
            if (Rekomendator.CzyOrzechy)
            {
                if (path.Length == initialLength)
                    path += (" [Orzechy] = " + Rekomendator.CzyOrzechy);
                else
                    path += (" AND [Orzechy] = " + Rekomendator.CzyOrzechy);
            }
            if (Rekomendator.CzyNaturalny)
            {
                if (path.Length == initialLength)
                    path += (" [Produkt naturalny] = " + Rekomendator.CzyNaturalny);
                else
                    path += (" AND [Produkt naturalny] = " + Rekomendator.CzyNaturalny);
            }
            if (Rekomendator.Cena != 0)
            {
                if (path.Length == initialLength)
                    path += (" [CENA] > " + (Rekomendator.Cena - 20) + " AND [Cena] < " + (Rekomendator.Cena + 20));
                else
                    path += (" AND [Cena] > " + (Rekomendator.Cena-20) + " AND [Cena] < " + (Rekomendator.Cena+20));
            }

            return path;
        }
    }
}
