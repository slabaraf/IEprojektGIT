using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjektIEwpf
{
    public static class ProductsCheckout
    {
        private static int id;
        private static string producent;
        private static string nazwa;
        private static string kategoria;
        private static string forma;
        private static bool czyWegan;
        private static bool czyGluten;
        private static bool czyLaktoza;
        private static bool czyNaturalny;
        private static bool czyOrzechy;
        private static int cena;


        public static int Id { get => id; set => id = value; }
        public static string Producent { get => producent; set => producent = value; }
        public static string Nazwa { get => nazwa; set => nazwa = value; }
        public static string Kategoria { get => kategoria; set => kategoria = value; }
        public static string Forma { get => forma; set => forma = value; }
        public static bool CzyWegan { get => czyWegan; set => czyWegan = value; }
        public static bool CzyGluten { get => czyGluten; set => czyGluten = value; }
        public static bool CzyLaktoza { get => czyLaktoza; set => czyLaktoza = value; }
        public static bool CzyNaturalny { get => czyNaturalny; set => czyNaturalny = value; }
        public static bool CzyOrzechy { get => czyOrzechy; set => czyOrzechy = value; }
        public static int Cena { get => cena; set => cena = value; }


        public static void GetItem()
        {
            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString = "SELECT Produkt.Nazwa, Produkt.Producent, Kategoria.Przeznaczenie, Forma.Forma, Produkt.Vegan, Produkt.Gluten, Produkt.Laktoza, Produkt.Orzechy, [Produkt naturalny], Produkt.Cena FROM Produkt, Kategoria, Forma WHERE Produkt.Id = " + id + " AND Produkt.Kategoria = Kategoria.Id AND Produkt.Forma = Forma.Id";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Nazwa = reader.GetValue(0).ToString();
                Producent = reader.GetValue(1).ToString();
                Kategoria = reader.GetValue(2).ToString();
                Forma = reader.GetValue(3).ToString();
                CzyWegan = Convert.ToBoolean(reader.GetValue(4));
                CzyGluten = Convert.ToBoolean(reader.GetValue(5));
                CzyLaktoza = Convert.ToBoolean(reader.GetValue(6));
                CzyNaturalny = Convert.ToBoolean(reader.GetValue(7));
                CzyOrzechy = Convert.ToBoolean(reader.GetValue(8));
                Cena = Convert.ToInt32(reader.GetValue(9));
            }

            con.Close();
        }
    }
}
