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
using System.Data.OleDb;

namespace ProjektIEwpf.Pages
{
    /// <summary>
    /// Interaction logic for RNZLastPage.xaml
    /// </summary>
    public partial class RNZLastPage : Page
    {
        Random rnd = new Random();
        public RNZLastPage()
        {
            InitializeComponent();
            

        }

        private void ShowResults_Click(object sender, RoutedEventArgs e)
        {
            WishClass.Ilosc = Int32.Parse(IloscTxtBx.Text);
            int ileZostalo = WishClass.Ilosc;

            for (int i = 0; i < 13; i++)
            {
                if (i<4)
                {
                    if (WishClass.SubCatPoints[i]!=0)
                    {
                        WishClass.IleZKategorii[i] = Convert.ToInt32((WishClass.CatPoints[0]*1.0 / (WishClass.CatPoints[0] + WishClass.CatPoints[1] + WishClass.CatPoints[2])) * (WishClass.SubCatPoints[i]*1.0 / (WishClass.SubCatPoints[0] + WishClass.SubCatPoints[1] + WishClass.SubCatPoints[2] + WishClass.SubCatPoints[3])) * WishClass.Ilosc * 1.0);
                    }
                }
                else if (i<8)
                {
                    if (WishClass.SubCatPoints[i] != 0)
                    {
                        WishClass.IleZKategorii[i] = Convert.ToInt32((WishClass.CatPoints[1]*1.0 / (WishClass.CatPoints[1] + WishClass.CatPoints[1] + WishClass.CatPoints[2])) * (WishClass.SubCatPoints[i] * 1.0 / (WishClass.SubCatPoints[4] + WishClass.SubCatPoints[5] + WishClass.SubCatPoints[6] + WishClass.SubCatPoints[7])) * WishClass.Ilosc);
                    }
                }
                else
                {
                    if (WishClass.SubCatPoints[i] != 0)
                    {
                        WishClass.IleZKategorii[i] = Convert.ToInt32((WishClass.CatPoints[2] * 1.0 / (WishClass.CatPoints[0] + WishClass.CatPoints[1] + WishClass.CatPoints[2])) * (WishClass.SubCatPoints[i] * 1.0 / (WishClass.SubCatPoints[8] + WishClass.SubCatPoints[9] + WishClass.SubCatPoints[10] + WishClass.SubCatPoints[11] + WishClass.SubCatPoints[12])) * WishClass.Ilosc);
                    }
                }
            }

            string fileName = "Database555-1.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString = WishClass.queryString;
            OleDbCommand cmd = new OleDbCommand(queryString, con);
            OleDbDataReader reader = cmd.ExecuteReader();

            int doQuit = 0, j=0, maxIndex=0, maxValue=0;
            for (int i = 0; i < 13; i++) //13 kategorii
            {
                if (WishClass.IleZKategorii[i]>maxValue)
                {
                    maxValue = WishClass.IleZKategorii[i];
                    maxIndex = i; //jak nie zapelnimy tyloma itemami ile zazyczy sobie uzytkownik (zmienna Ilosc i ileZostalo) to tego maxa potrzebujemy zeby wiedziec z ktorej podkategorii potem losowac
                }

                if (WishClass.IleZKategorii[i]>0) //jesli ktoras nadkategoria ma wystpic (np 4 produkty z niej, 4>0)
                {
                    while (reader.Read() && doQuit==0) //to otwieramy baze i wyszukujemy PIERWSZEGO (po to doQuit) pasujacego rekordu
                    {
                        if (Convert.ToInt32(reader.GetValue(2).ToString()) == i+1) //jesli znalezlismy, tzn kategoria rekordu zgadza sie z numerkiem kategorii ktora jest wieksza od 0
                        {
                            StringBuilder sb = new StringBuilder(); //dodajemy ten produkt w pizdu
                            sb.Append(reader.GetValue(0).ToString());
                            sb.Append(", by ");
                            sb.Append(reader.GetValue(1).ToString());
                            sb.Append("; ");
                            sb.Append("                          ");
                            TextBlock txtBlock = new TextBlock();
                            txtBlock.Text = sb.ToString();
                            ResultsWrpPnl.Children.Add(txtBlock);
                            doQuit = 1; j = i; ileZostalo--; //do quit wychodzi z petli, zeby sie nie dodaly od razu wszystkie (bo w bazie moze byc ich 60, a wysiwetlic mamy tylko 4); ilezostalo sie zmniejsza, bo juz jeden item wyswietlilismy wiec zostaje o 1 mniej
                        }
                        
                    }
                    WishClass.IleZKategorii[i]--; //zmniejszamy liczbe itemow do wyswietlenia z tej podkategorii o dokladnie 1 (bo 1 wyswietlilismy albo nie ma pasujacego)
                    i--; //zmniejszamy i, bo wiemy ze ta podkategoria jest wieksza od 0, ale moze byc 4, wiec jak dodamy 1 to mamy jeszcze 3 do wyswietlenia, wiec trzeba zaczac z tego samego miejsca (szukac po tej samej kategorii)
                    doQuit = 0; //zmieniamy doquit, zeby dalej szukalo rekordow od miejsca, w ktorym wyszlismy (pierwszego znalezionego)
                }

                if (j == i) //w linii doquit = 1; j=i; j przyjmie wartosc i jeszcze przed zmniejszeniem (np i=j=6), zaraz potem zmniejszamy i JESLI sa jeszcze do wyswietlenia rekordy z tej samej kategorii - jak nie ma to i!=j (bo sie nie zmniejszy) i szukamy od nowa po nowej kategorii
                {
                    reader.Close();
                    reader = cmd.ExecuteReader();
                }
            }

            reader.Close();

            while(ileZostalo>0)
            {

                queryString = "SELECT Nazwa, Producent FROM Produkt WHERE (Produkt.Id = " + rnd.Next(1, 31) + ")"; //losujemy po prostu bo produktow w podkategoriach i tak jest za malo
                cmd = new OleDbCommand(queryString, con);
                reader = cmd.ExecuteReader();
                reader.Read();
                TextBlock randomtxtblock = new TextBlock();
                randomtxtblock.Text = reader.GetValue(0) + ", " + reader.GetValue(1) + "; ";
                ResultsWrpPnl.Children.Add(randomtxtblock);
                ileZostalo--;
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/StartPage.xaml", UriKind.Relative));
        }
    }
}
