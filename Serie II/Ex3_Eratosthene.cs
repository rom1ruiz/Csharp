using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Eratosthene
    {
        public static int[] EratosthenesSieve(int n)
        {

            int i = 2;
            int[] result = new int[n + 1];
            for (int a = 2; a < result.Length; a++)
            {
                result[a] = a;
            }


            while (i <= Math.Sqrt(n))
            {
                if (result[i] != -1)
                {
                    for (int j = 2; i * j <= n; j++)
                    {
                        result[i * j] = -1;
                    }
                }
                i++;
            }
            return result;
        }
    }
}
