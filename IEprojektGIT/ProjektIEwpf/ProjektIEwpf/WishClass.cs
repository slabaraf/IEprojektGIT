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
        static double[] nad = new double[3];//punkty w 3 nadkategoriach

        static int[] pod1 = new int[4];//punkty podkategorii w podziale na 3 nadkategorie
        static int[] pod2 = new int[4];
        static int[] pod3 = new int[5];

        static double nk;// sumy punktów w nad- i podkategoriach
        static int p1;
        static int p2;
        static int p3;

        static double[] NKx = new double[3]; // kryterium kolejności
        static double[] PKx1 = new double[4];
        static double[] PKx2 = new double[4];
        static double[] PKx3 = new double[5];

        public static string StringRNZ6;
        
        public static string StringRNZ7;
        public static int nav = 0;// zmienna służąca do cofania ze strony szóstej 
        public static double n = 10;// na razie sztywne 10

        static int[] lenghts = new int[3];

        public static StringBuilder sb = new StringBuilder();
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
                if (i < 3 && p1 > 0)
                {
                    PKx1[i] = pod1[i] / p1;
                }
                else if(i < 3 && p1 == 0)
                {
                    PKx1[i] = 0;
                }

                if (i < 3 && p2 > 0)
                {
                    PKx2[i] = pod2[i] / p2;
                }
                else if (i < 3 && p2 == 0)
                {
                    PKx2[i] = 0;
                }

                if (p3 >0)
                {
                    PKx3[i] = pod3[i] / p3;
                }
                else if (p3 == 0)
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
            queryString += StringRNZ6 /*+ "AND"*/ +StringRNZ7;
            string queryString0 = queryString + " OR ";
            string queryString1 = queryString + " OR ";
            string queryString2 = queryString + " OR ";

            if (NKx[0] >= NKx[1] && NKx[0] >= NKx[2])
            {
                queryString0 += "Kategoria.Przeznaczenie = 1 OR Kategoria.Przeznaczenie = 2 OR Kategoria.Przeznaczenie = 3 " +
                    "OR Kategoria.Przeznaczenie = 4 LIMIT " + Math.Floor(NKx[0] * n) + ";";
                help[0] = helper++;
                if (NKx[1] > NKx[2]) 
                {
                    queryString1 += "Kategoria.Przeznaczenie = 5 AND Kategoria.Przeznaczenie = 6 AND Kategoria.Przeznaczenie = 7 " +
                        "AND Kategoria.Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                    help[1] = helper++;
                }
                else
                {
                    queryString2 += "Kategoria.Przeznaczenie = 9 AND Kategoria.Przeznaczenie = 10 AND Kategoria.Przeznaczenie = 11 " +
                        "AND Kategoria.Przeznaczenie = 12 AND Kategoria.Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                    help[2] = helper++;
                }
            }
            else if (NKx[1] > NKx[0] && NKx[1] >= NKx[2])
            {
                queryString1 += "Kategoria.Przeznaczenie = 5 AND Kategoria.Przeznaczenie = 6 AND Kategoria.Przeznaczenie = 7 " +
                    "AND Kategoria.Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                help[1] = helper++;
                if (NKx[0] > NKx[2])
                {
                    queryString0 += "Kategoria.Przeznaczenie = 1 AND Kategoria.Przeznaczenie = 2 AND Kategoria.Przeznaczenie = 3 " +
                        "AND Kategoria.Przeznaczenie = 4 LIMIT " + Math.Floor(NKx[0] * n);
                    help[0] = helper++;
                }
                else
                {
                    queryString2 += "Kategoria.Przeznaczenie = 9 AND Kategoria.Przeznaczenie = 10 AND Kategoria.Przeznaczenie = 11" +
                        " AND Kategoria.Przeznaczenie = 12 AND Kategoria.Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                    help[2] = helper++;
                }
            }
            else/* if (NKx[2] > NKx[0] && NKx[2] > NKx[1])*/
            {
                queryString2 += "Kategoria.Przeznaczenie = 9 AND Kategoria.Przeznaczenie = 10 AND Kategoria.Przeznaczenie = 11 " +
                    "AND Kategoria.Przeznaczenie = 12 AND Kategoria.Przeznaczenie = 13 LIMIT " + NKx[2] * n;
                help[2] = helper++;
                if (NKx[0] > NKx[1])
                {
                    queryString0 += "Kategoria.Przeznaczenie = 1 AND Kategoria.Przeznaczenie = 2 AND Kategoria.Przeznaczenie = 3 " +
                        "AND Kategoria.Przeznaczenie = 4 LIMIT " + +Math.Floor(NKx[0] * n);
                    help[0] = helper++;
                    queryString1 += "Kategoria.Przeznaczenie = 5 AND Kategoria.Przeznaczenie = 6 AND Kategoria.Przeznaczenie = 7" +
                        " AND Kategoria.Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                    help[1] = helper++;
                }
                else
                {
                    queryString1 += "Kategoria.Przeznaczenie = 5 AND Kategoria.Przeznaczenie = 6 AND Kategoria.Przeznaczenie = 7 AND " +
                        "Kategoria.Przeznaczenie = 8 LIMIT " + NKx[1] * n;
                    help[1] = helper++;
                    queryString0 += "Kategoria.Przeznaczenie = 1 AND Kategoria.Przeznaczenie = 2 AND Kategoria.Przeznaczenie = 3 AND" +
                        " Kategoria.Przeznaczenie = 4 LIMIT " + Math.Floor(NKx[0] * n);
                    help[0] = helper++;
                }
            }

            OleDbCommand cmd0 = new OleDbCommand(queryString0, con);
            OleDbDataReader reader0 = cmd0.ExecuteReader();

            OleDbCommand cmd1 = new OleDbCommand(queryString1, con);
            OleDbDataReader reader1 = cmd1.ExecuteReader();

            OleDbCommand cmd2 = new OleDbCommand(queryString2, con);
            OleDbDataReader reader2 = cmd2.ExecuteReader();

            

            if (help[0] == 1)
            {
                while (reader0.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sb.Append(reader0.GetValue(i));
                    }
                    sb.Append("\n");
                }
                if (help[1] < help[2])
                {
                    while (reader1.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader1.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                    while (reader2.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader2.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                }
                else
                {
                    while (reader2.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader2.GetValue(i));
                        }
                        sb.Append("\n");
                        while (reader1.Read())
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                sb.Append(reader1.GetValue(i));
                            }
                            sb.Append("\n");
                        }
                    }

                }
            }

            else if (help[1] == 1)
            {
                while (reader1.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sb.Append(reader1.GetValue(i));
                    }
                    sb.Append("\n");
                }
                if (help[0] < help[2])
                {
                    while (reader0.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader0.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                    while (reader2.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader2.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                }
                else
                {
                    while (reader2.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader2.GetValue(i));
                        }
                        sb.Append("\n");
                        while (reader0.Read())
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                sb.Append(reader0.GetValue(i));
                            }
                            sb.Append("\n");
                        }
                    }

                }
            }

            else if (help[2] == 1)
            {
                while (reader2.Read())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        sb.Append(reader2.GetValue(i));
                    }
                    sb.Append("\n");
                }
                if (help[0] < help[1])
                {
                    while (reader0.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader0.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                    while (reader1.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader1.GetValue(i));
                        }
                        sb.Append("\n");
                    }
                }
                else
                {
                    while (reader1.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            sb.Append(reader1.GetValue(i));
                        }
                        sb.Append("\n");
                        while (reader0.Read())
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                sb.Append(reader0.GetValue(i));
                            }
                            sb.Append("\n");
                        }
                    }

                }
            }


        }
    }
}
