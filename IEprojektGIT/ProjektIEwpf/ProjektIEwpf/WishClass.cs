using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektIEwpf
{
    class WishClass
    {
        //Dictionary<string, int> nadkategoria = new Dictionary<string, int>();
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

        public static int nav = 0;
        public static void Points()
        {
            nk = nad.Sum();
            p1 = pod1.Sum();
            p2 = pod2.Sum();
            p3 = pod3.Sum();
            for (int i = 0; i < 3; i++)
            {
                NKx[i] = nad[i] / nk;
            }
            for (int i = 0; i < 5; i++)
            {
                if (i <= 3)
                {
                    PKx1[i] = pod1[i] / p1;
                    PKx2[i] = pod2[i] / p2;
                }
                PKx3[i] = pod3[i] / p3;
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
    }
}
