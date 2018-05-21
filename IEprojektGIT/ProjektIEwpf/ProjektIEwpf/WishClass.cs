using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektIEwpf
{
    static class WishClass
    {
        public static int Ilosc;

        //0 - sporty wytrzymalosciowe; 1 -sporty silowe; 2 - suplementy niesportowe
        public static int[] CatPoints = new int[3];

        //to mam w notatniku, kolejnosc taka jak w bazie -1, zeby sie indeks zgadzal (produkty startowe to 1 zamiast 2)
        public static int[] SubCatPoints = new int[13];

        public static int[] IleZKategorii = new int[13];

        public static string queryString = "Select Produkt.Nazwa, Produkt.Producent, Produkt.Kategoria FROM Produkt WHERE ";
        public static int initialLength = queryString.Length;

    }
}
