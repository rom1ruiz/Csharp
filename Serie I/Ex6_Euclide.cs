using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Euclide
    {
        public static int Pgcd(int a, int b)
        {
            //int q = a / b;
            int r = a % b;
            while (r!=0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        public static int PgcdRecursive(int a, int b)
        {
            int r = a % b;
            if (r == 0)
            {
                return r;
            }
            else
            {
                //a = b;
                //b = r;
                return Pgcd(b, r);
            }
        }
    }
}
