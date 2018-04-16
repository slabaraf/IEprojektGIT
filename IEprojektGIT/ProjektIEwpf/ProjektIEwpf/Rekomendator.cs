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

namespace ProjektIEwpf
{
    public struct Rekomendator
    {
        private static string producent;
        private static string nazwa;
        private static int kategoria;
        private static int forma;
        private static bool czyWegan;
        private static bool czyGluten;
        private static bool czyLaktoza;
        private static bool czyNaturalny;
        private static bool czyOrzechy;
        private static int cena;

        private static List<>

        public static string Producent { get => producent; set => producent = value; }
        public static string Nazwa { get => nazwa; set => nazwa = value; }
        public static int Kategoria { get => kategoria; set => kategoria = value; }
        public static int Forma { get => forma; set => forma = value; }
        public static bool CzyWegan { get => czyWegan; set => czyWegan = value; }
        public static bool CzyGluten { get => czyGluten; set => czyGluten = value; }
        public static bool CzyLaktoza { get => czyLaktoza; set => czyLaktoza = value; }
        public static bool CzyNaturalny { get => czyNaturalny; set => czyNaturalny = value; }
        public static bool CzyOrzechy { get => czyOrzechy; set => czyOrzechy = value; }
        public static int Cena { get => cena; set => cena = value; }



    }
}
