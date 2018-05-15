using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjektIEwpf
{
    public class ProductsCheckout
    {
        public static Dictionary<int, ProductsCheckout> Obejrzane = new Dictionary<int, ProductsCheckout>();
        public static Dictionary<int, ProductsCheckout> DoPolecenia = new Dictionary<int, ProductsCheckout>();

        private int id;
        private string producent;
        private string nazwa;
        private string kategoria;
        private string forma;
        private bool czyWegan;
        private bool czyGluten;
        private bool czyLaktoza;
        private bool czyNaturalny;
        private bool czyOrzechy;
        private int cena;
        private string slowaKlucze;
        private string nadkategoria;


        public int Id { get => id; set => id = value; }
        public string Producent { get => producent; set => producent = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Kategoria { get => kategoria; set => kategoria = value; }
        public string Forma { get => forma; set => forma = value; }
        public bool CzyWegan { get => czyWegan; set => czyWegan = value; }
        public bool CzyGluten { get => czyGluten; set => czyGluten = value; }
        public bool CzyLaktoza { get => czyLaktoza; set => czyLaktoza = value; }
        public bool CzyNaturalny { get => czyNaturalny; set => czyNaturalny = value; }
        public bool CzyOrzechy { get => czyOrzechy; set => czyOrzechy = value; }
        public int Cena { get => cena; set => cena = value; }
        public string SlowaKlucze { get => slowaKlucze; set => slowaKlucze = value; }
        public string Nadkategoria { get => nadkategoria; set => nadkategoria = value; }


        public ProductsCheckout()
        {

        }

        public ProductsCheckout(int Id, string Producent, string Nazwa, string Kategoria, string Forma, bool CzyWegan, bool CzyGluten, bool CzyLaktoza, bool CzyNaturalny, bool CzyOrzechy, int Cena, string SlowaKlucze, string Nadkategoria)
        {
            this.Id = Id;
            this.Producent = Producent;
            this.Nazwa = Nazwa;
            this.Kategoria = Kategoria;
            this.Forma = Forma;
            this.CzyWegan = CzyWegan;
            this.CzyGluten = CzyGluten;
            this.CzyLaktoza = CzyLaktoza;
            this.CzyNaturalny = CzyNaturalny;
            this.CzyOrzechy = CzyOrzechy;
            this.Cena = Cena;
            this.SlowaKlucze = SlowaKlucze;
            this.Nadkategoria = Nadkategoria;
        }




        public void GetItem(bool isAdded)
        {
            string fileName = "Database5.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();
            //potrzebujemy calosci info o produkcie, ale musimy polaczyc te 3 tabele, zeby zamiast np Kategoria=3 bylo Kategoria=produkty regenracyjne (a to info jest w tabeli Kategoria)
            string queryString = "SELECT Produkt.Nazwa, Produkt.Producent, Kategoria.Przeznaczenie, Forma.Forma, Produkt.Vegan, Produkt.Gluten, Produkt.Laktoza, Produkt.Orzechy, [Produkt naturalny], Produkt.Cena, [Słowa klucze] FROM Produkt, Kategoria, Forma WHERE Produkt.Id = " + id + " AND Produkt.Kategoria = Kategoria.Id AND Produkt.Forma = Forma.Id";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())//przypisujemy cale to info do zmiennych 
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
                SlowaKlucze = reader.GetValue(10).ToString();

                //sprawdzamy do jakiej nadkategorii nalezy kategoria
                switch (Kategoria)
                {
                    case "izotoniki":
                    case "produkty startowe":
                    case "produkty regeneracyjne":
                    case "ochronne aparatu ruchu":
                        Nadkategoria = "sporty wytrzymalosciowe";
                        break;

                    case "białko":
                    case "gainery":
                    case "spalacze tłuszczu":
                    case "na pompę mięśniową":
                        Nadkategoria = "sporty silowe";
                        break;

                    case "kompleksy witaminowe":
                    case "na odporność i powrót do zdrowia":
                    case "na pobudzenie energetyczne":
                    case "na pobudzenie seksualne":
                    case "na sen":
                        Nadkategoria = "suplementy niesportowe";
                        break;
                    default:
                        break;
                }
            }

            con.Close();
            //polecarka produktow opiera sie na trzech elementach: podkategorii (Kategoria), tagach (SlowaKlucze) i nadkategorii (Nadkategoria)
            //to je przekazujemy do funkcji ustalajacej punkty
            if (isAdded)
            {
                PolecaneProdukty.AddPoints(Kategoria, SlowaKlucze, Nadkategoria);
                return;
            }
            else
            {
                PolecaneProdukty.DeletePoints(Kategoria, SlowaKlucze, Nadkategoria);
            }
            
        }
    }
}
