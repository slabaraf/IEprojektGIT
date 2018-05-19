using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ProjektIEwpf
{
    public static class PolecaneProdukty //no tu to sie dopiero dzieje
    {
        
        //jak jakis uzyszkodnik (iksde) bedzie przegladal produkt i wybierze bialko mass attack, to do tego dictionary ponizej
        //doda sie tag Mass Attack, wanilia i proszek (bo takie sa w bazie) i kazde z nich dostanie od razu po punkciku (po to ten int)
        //wiec potem mozna tutaj znalezc ktory tag uzbieral najwiecej punktow, bo jak potem znowu kliknie cos waniliowego, to juz sie nie doda nowy
        //tag wanilia, tylko po prostu dodamy punkt (if wanilia jest w tym slowniku, to dodaj punkt, a jak nie to stworz tag wanilia z jednym punktem)
        private static Dictionary<string, int> tagi = new Dictionary<string, int>();

        //podobnie tylko ze z "nadkategoria" i "podkategoria"
        private static Dictionary<string, int> nadkategorie = new Dictionary<string, int>();
        private static Dictionary<string, int> podkategorie = new Dictionary<string, int>();

        public static Dictionary<int, int> punktyProduktuTag = new Dictionary<int, int>();
        public static Dictionary<int, int> punktyProduktuPodkat = new Dictionary<int, int>();
        public static Dictionary<int, int> punktyProduktuNadkat = new Dictionary<int, int>();

        public static int LiczbaItemow;
        //                              string Kategoria, string slowaKlucze, string nadkategoria z ProductsCheckout
        public static void AddPoints(string podkategoria, string tagiZBazy, string nadkategoria)
        {
            string[] tag; //tu przechowamy tagi produktu pojedynczo

            //uzytkownik zaczal ogladac produkt (wiemy to, bo od razu po nacisnieciu przycisku "ogladaj" wywoluje sie metoda zapisujaca co obejrzal (a ta metoda wywoluje te ktora teraz czytasz)
            //wiec od razu pizgamy podkategorie tego produktu i dopisujemy punkcik (albo tylko dodajemy punkcik, jesli podkategoria juz istnieje w slowniku (bo np. to juz trzeci produkt ogladany))
            if (podkategorie.ContainsKey(podkategoria))
            {
                //podkategorie z podkategorii o okreslonej podkategorii na miejscu podkategoria gdzie sa skladowane odpowiednie podkategorie w slowniku podkategorie z kluczem podkategoria
                //podkategoria
                podkategorie[podkategoria] += 1;
            }
            else
            {
                podkategorie.Add(podkategoria, 1);
            }


            //to samo z nadkategoria
            if (nadkategorie.ContainsKey(nadkategoria))
            {
                nadkategorie[nadkategoria] += 1;
            }
            else
            {
                nadkategorie.Add(nadkategoria, 1);
            }

            //zostaly do zapunktowania tagi, ale najpierw trzeba rozbic tagi z bazy (w postaci tag1;tag2;tag3) na pojedyncze
            tag = tagiZBazy.Split(';');
            //teraz w tablicy tag mamy elegancko wszystkie tagi
            //no to sprawdzamy czy w slowniku juz takie sa a jak ich nie ma to blabla to samo co wyzej
            foreach (string item in tag)
            {
                if (tagi.ContainsKey(item))
                {
                    tagi[item] += 1;
                }
                else
                {
                    tagi.Add(item, 1);
                }
            }
           // CountTagPoints();
        }

        public static void DeletePoints(string podkategoria, string tagiZBazy, string nadkategoria)
        {
            string[] tag = tagiZBazy.Split(';');

            if (podkategorie.ContainsKey(podkategoria))
            {
                podkategorie[podkategoria] /= 2;
            }
            if (nadkategorie.ContainsKey(nadkategoria))
            {
                nadkategorie[nadkategoria] = (int)Math.Ceiling(nadkategorie[nadkategoria] * 1.25);
            }

            foreach (string item in tag)
            {
                if (tagi.ContainsKey(item))
                {
                    tagi[item] /= 2;
                }
            }
            //CountTagPoints();
        }


        public static void CountTagPoints()
        {
            //obliczanie punktow dla tagow (wedlug tego pdfa z grupy na fb) to jest nieporozumienie i niech sie ciesza, ze jest w bazie tylko 5 itemow xd

            //pierwszy int to id, drugi int to punkty
            
            int id;
            int pkt=0;
            string[] tagi;

            //otwieramy baze zeby przejrzec tagi kazdego produktu i wysumowac ile ktory ma pkt
            string fileName = "Database555.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();
            //Id + tagi, zeby wiedziec ile uzbieral produkt na danej pozycji (i potem latwo go znalezc w bazie/slowniku Obejrzane zeby wyswietlic)


            string queryString = "SELECT Id, [Słowa klucze] FROM Produkt";
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            

            while (reader.Read())
            {
                id = (int)reader.GetValue(0);
                tagi = reader.GetValue(1).ToString().Split(';'); //tablica przechowujaca tagi pojedynczo

                //lecimy po wszystkich itemach w slowniku tagi (gromadzacym, well, tagi [i ile maja punktow]) i obczajamy czy aktualnie otwarty
                //z bazy produkt tez ma takie tagi (tagi.Contains)
                foreach (KeyValuePair<string, int> item in PolecaneProdukty.tagi)
                {
                    if (tagi.Contains(item.Key))
                    {
                        pkt += item.Value; //a jak ma to do zmiennej pkt dodajemy tyle pkt, ile podczas przegladania uzbieral dany tag
                    }
                }

                if (punktyProduktuTag.ContainsKey(id))
                {
                    punktyProduktuTag[id] += pkt;
                }
                else
                {
                    punktyProduktuTag.Add(id, pkt); //i cyk mamy id produktu i jego liczbe punktow za tagi ktore ma
                }
                
                pkt = 0; //jak juz to zapisalismy to trzeba wyzerowac pkt zeby sie nie dodawaly w nieskonczonosc, wiadomo
            }
            con.Close();

        }

        public static void CountCategoryPoints() //dla kategorii dokladnie analogicznie tylko x2, bo mamy i nad- i podkategorie
        {

            //pierwszy int to id, drugi int to punkty
            
            int id;
            int pkt=0;
            string nadkategoria = "";
            string podkategoria = "";


            //otwieramy baze zeby przejrzec te wszystkie tagi
            string fileName = "Database555.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString2 = "SELECT Produkt.Id, Kategoria.Przeznaczenie FROM Produkt, Kategoria WHERE Produkt.Kategoria = Kategoria.Id";
            
            OleDbCommand cmd = new OleDbCommand(queryString2, con);
            OleDbDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                id = (int)reader.GetValue(0);
                nadkategoria = SprawdzNadkategorie(reader.GetValue(1).ToString());
                podkategoria = reader.GetValue(1).ToString();

                foreach (KeyValuePair<string, int> item in PolecaneProdukty.nadkategorie)
                {
                    if (nadkategoria==item.Key)
                    {
                        pkt += item.Value;
                    }
                }
                if (punktyProduktuNadkat.ContainsKey(id))
                {
                    punktyProduktuNadkat[id] += pkt;
                }
                else
                {
                    punktyProduktuNadkat.Add(id, pkt); //i cyk mamy id produktu i jego liczbe punktow za tagi ktore ma
                }//i cyk mamy id produktu i jego liczbe punktow za tagi ktore ma
                pkt = 0;

                foreach (KeyValuePair<string, int> item in PolecaneProdukty.podkategorie)
                {
                    if (podkategoria == item.Key)
                    {
                        pkt += item.Value;
                    }
                }

                if (punktyProduktuPodkat.ContainsKey(id))
                {
                    punktyProduktuPodkat[id] += pkt;
                }
                else
                {
                    punktyProduktuPodkat.Add(id, pkt); //i cyk mamy id produktu i jego liczbe punktow za tagi ktore ma
                }
                pkt = 0;
            }
            con.Close();
        }

        private static string SprawdzNadkategorie(string kategoria) //pomocnicza zebym mial nadkategorie tutaj
        {
            string Nadkategoria="";

            switch (kategoria)
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

            return Nadkategoria;
        }

        public static void DodawarkaPolecanych()
        {
            string fileName = "Database555.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();


            ProductsCheckout.DoPolecenia.Clear();
            for (int i = 1; i <= LiczbaItemow; i++)
            {
                string queryString = "";
                ProductsCheckout.DoPolecenia.Add(i, new ProductsCheckout());
                if (i<=Math.Ceiling(LiczbaItemow*0.4))
                {
                    queryString = "SELECT Produkt.Id, Nazwa, Producent, Kategoria.Przeznaczenie, Forma.Forma, Vegan, Gluten, Laktoza, Orzechy, [Produkt naturalny], Cena FROM Produkt, Kategoria, Forma WHERE Produkt.Kategoria = Kategoria.Id AND Produkt.Forma = Forma.Id AND Produkt.Id = " + punktyProduktuTag.FirstOrDefault(x => x.Value == punktyProduktuTag.Values.Max()).Key;       //punktyProduktuTag.ElementAt(i-1).Key;
                    ProductsCheckout.DoPolecenia[i].Id = punktyProduktuTag.FirstOrDefault(x => x.Value == punktyProduktuTag.Values.Max()).Key;
                    punktyProduktuTag[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuNadkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuPodkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                }
                else if (i <= Math.Ceiling(LiczbaItemow * 0.7))
                {
                    queryString = "SELECT Produkt.Id, Nazwa, Producent, Kategoria.Przeznaczenie, Forma.Forma, Vegan, Gluten, Laktoza, Orzechy, [Produkt naturalny], Cena FROM Produkt, Kategoria, Forma WHERE Produkt.Kategoria = Kategoria.Id AND Produkt.Forma = Forma.Id AND Produkt.Id = " + punktyProduktuNadkat.FirstOrDefault(x => x.Value == punktyProduktuNadkat.Values.Max()).Key;
                    ProductsCheckout.DoPolecenia[i].Id = punktyProduktuNadkat.FirstOrDefault(x => x.Value == punktyProduktuNadkat.Values.Max()).Key;
                    punktyProduktuTag[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuNadkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuPodkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                }
                else
                {
                    queryString = "SELECT Produkt.Id, Nazwa, Producent, Kategoria.Przeznaczenie, Forma.Forma, Vegan, Gluten, Laktoza, Orzechy, [Produkt naturalny], Cena FROM Produkt, Kategoria, Forma WHERE Produkt.Kategoria = Kategoria.Id AND Produkt.Forma = Forma.Id AND Produkt.Id = " + punktyProduktuPodkat.FirstOrDefault(x => x.Value == punktyProduktuPodkat.Values.Max()).Key;
                    ProductsCheckout.DoPolecenia[i].Id = punktyProduktuPodkat.FirstOrDefault(x => x.Value == punktyProduktuPodkat.Values.Max()).Key;
                    punktyProduktuTag[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuNadkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                    punktyProduktuPodkat[ProductsCheckout.DoPolecenia[i].Id] = -1;
                }


                OleDbCommand cmd = new OleDbCommand(queryString, con);
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductsCheckout.DoPolecenia[i].Nazwa = reader.GetValue(1).ToString();
                    ProductsCheckout.DoPolecenia[i].Producent = reader.GetValue(2).ToString();
                    ProductsCheckout.DoPolecenia[i].Kategoria = reader.GetValue(3).ToString();
                    ProductsCheckout.DoPolecenia[i].Forma = reader.GetValue(4).ToString();
                    ProductsCheckout.DoPolecenia[i].CzyWegan = (bool)reader.GetValue(5);
                    ProductsCheckout.DoPolecenia[i].CzyGluten = (bool)reader.GetValue(6);
                    ProductsCheckout.DoPolecenia[i].CzyLaktoza = (bool)reader.GetValue(7);
                    ProductsCheckout.DoPolecenia[i].CzyOrzechy = (bool)reader.GetValue(8);
                    ProductsCheckout.DoPolecenia[i].CzyNaturalny = (bool)reader.GetValue(9);
                    ProductsCheckout.DoPolecenia[i].Cena = Convert.ToInt32(reader.GetValue(10));
                }
            }
        }
    }
}
