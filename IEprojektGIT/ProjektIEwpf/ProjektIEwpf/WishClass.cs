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
        static int[] nad = new int[3];

        static int[] pod1 = new int[4];
        static int[] pod2 = new int[4];
        static int[] pod3 = new int[5];
        public static void Zeruj()
        {
            nad[0] = 0;
            nad[1] = 0;
            nad[2] = 0;
        }
        public static void AddPointsAbove(int index, int points)
        {
            nad[index] += points;
        }
        public static void AddPointsUnder(int podNumber, int index, int points)
        {
            if(podNumber == 1)
            {
                pod1[index] += points;
            }
            if (podNumber == 2)
            {
                pod2[index] += points;
            }
            if (podNumber == 3)
            {
                pod3[index] += points;
            }
            
        }
    }
}
