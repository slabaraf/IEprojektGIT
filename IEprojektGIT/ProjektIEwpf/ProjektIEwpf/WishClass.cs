using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektIEwpf
{
    class WishClass
    {
        static int[] nad = new int[3];//punkty w 3 nadkategoriach

        static int[] pod1 = new int[4];//punkty podkategorii w podziale na 3 nadkategorie
        static int[] pod2 = new int[4];
        static int[] pod3 = new int[5];

        static int nk;// sumy punktów w nad- i podkategoriach
        static int p1;
        static int p2;
        static int p3;

        static int[] NKx = new int[3]; // kryterium kolejności
        static int[] PKx1 = new int[4];
        static int[] PKx2 = new int[4];
        static int[] PKx3 = new int[5];

        public static string StringRNZ6;
        public static string StringRNZ7;
        public static int nav = 0;// zmienna służąca do cofania ze strony szóstej 
        public static int n = 10;// na razie sztywne 10

        static int[] lenghts = new int[3];
        public static void Points()
        {
            nk = nad.Sum();
            p1 = pod1.Sum();
            p2 = pod2.Sum();
            p3 = pod3.Sum();
            for (int i = 0; i < 3; i++)
            {
               if(nk > 0)
               {
                    NKx[i] = nad[i] / nk;
               }
               else if(nk == 0)
               {
                    NKx[i] = 0;
               }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i <= 3 && p1 > 0)
                {
                    PKx1[i] = pod1[i] / p1;
                }
                else if(p1 == 0)
                {
                    PKx1[i] = 0;
                }

                if (i <= 3 && p2 > 0)
                {
                    PKx2[i] = pod2[i] / p2;
                }
                else if (p1 == 0)
                {
                    PKx2[i] = 0;
                }

                if (p3 >0)
                {
                    PKx3[i] = pod3[i] / p3;
                }
                else if (p1 == 0)
                {
                    PKx3[i] = 0;
                }
            }
        }
        public static void AddPointsAbove(int index, int points)
        {
            nad[index-1] += points;
        }
        public static void AddPointsUnder(int podNumber, int index, int points)
        {
            if(podNumber == 1)
            {
                pod1[index-1] += points;
            }
            if (podNumber == 2)
            {
                pod2[index-1] += points;
            }
            if (podNumber == 3)
            {
                pod3[index-1] += points;
            }
            
        }
        static int helper = 0;// te dwie zmienne pozwalają na wyświetlenie danych w odpowiedniej kolejności 
        static int[] help = new int[3];
        public static void ShowProducts()
        {
            string fileName = "Database555.accdb";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, fileName);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path);
            con.Open();

            string queryString;
            queryString = "SELECT Nazwa, Producent, Kategoria.Przeznaczenie, Forma.Forma, Cena FROM Produkt, Kategoria, Forma WHERE ";
            queryString += StringRNZ6 + "AND" +StringRNZ7;
            string queryString0 = queryString;
            string queryString1 = queryString;
            string queryString2 = queryString;

            if (NKx[0] > NKx[1] && NKx[0] > NKx[2])
            {
                queryString0 += "Przeznaczenie = 1 AND Przeznaczenie = 2 AND Przeznaczenie = 3 AND Przeznaczenie = 4 LIMIT " + NKx[0] * n;
                help[0] = helper++;
                if (NKx[1] > NKx[2]) 
                {
                    queryString1 += "Przeznaczenie = 5 AND Przeznaczenie = 6 AND Przeznaczenie = 7 AND Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                    help[1] = helper++;
                }
                else
                {
                    queryString2 += "Przeznaczenie = 9 AND Przeznaczenie = 10 AND Przeznaczenie = 11 AND Przeznaczenie = 12 AND Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                    help[2] = helper++;
                }
            }
            else if (NKx[1] > NKx[0] && NKx[1] > NKx[2])
            {
                queryString1 += "Przeznaczenie = 5 AND Przeznaczenie = 6 AND Przeznaczenie = 7 AND Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                help[1] = helper++;
                if (NKx[0] > NKx[2])
                {
                    queryString0 += "Przeznaczenie = 1 AND Przeznaczenie = 2 AND Przeznaczenie = 3 AND Przeznaczenie = 4 LIMIT " + NKx[0] * n;
                    help[0] = helper++;
                }
                else
                {
                    queryString2 += "Przeznaczenie = 9 AND Przeznaczenie = 10 AND Przeznaczenie = 11 AND Przeznaczenie = 12 AND Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                    help[2] = helper++;
                }
            }
            else if (NKx[2] > NKx[0] && NKx[2] > NKx[1])
            {
                queryString2 += "Przeznaczenie = 9 AND Przeznaczenie = 10 AND Przeznaczenie = 11 AND Przeznaczenie = 12 AND Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                help[2] = helper++;
                if (NKx[0] > NKx[1])
                {
                    queryString0 += "Przeznaczenie = 1 AND Przeznaczenie = 2 AND Przeznaczenie = 3 AND Przeznaczenie = 4 LIMIT " + NKx[0] * n;
                    help[0] = helper++;
                }
                else
                {
                    queryString1 += "Przeznaczenie = 5 AND Przeznaczenie = 6 AND Przeznaczenie = 7 AND Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                    help[1] = helper++;
                }
            }

        }
    }
}
