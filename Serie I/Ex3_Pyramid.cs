using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
        
            for (int j = 0; j <= n; j++)
            {
                int left = n - j;
                int right = n + j;

                for (int i = 0; i <= 2 * n - 1; i++)
                {
                    //SI entre gauche et droite
                    if (i >= left && i <= right)
                    {
                        //ALORS + ou -
                        Console.Write("+");
                    }
                    // SINON Espace
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
