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
        int[] nad = new int[3];

        int[] pod1 = new int[4];
        int[] pod2 = new int[4];
        int[] pod3 = new int[5];
        public void Zeruj()
        {
            nad[0] = 0;
            nad[1] = 0;
            nad[2] = 0;
        }
        public void AddPointsAbove(int index, int points)
        {
            nad[index] += points;
        }
        public void AddPointsUnder(int pod, int index, int points)
        {
            switch(pod)
            {
                case 1:
                    pod1[index] += points;
                    break;
                case 2:
                    pod2[index] += points;
                    break;
                case 3:
                    pod3[index] += points;
                    break;
            }
        }









    }
}
