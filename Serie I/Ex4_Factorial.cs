using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            //3! = 1 x 2 x 3 = 6
            //0! = 1! = 1
            int r = 1;         
                for (int i = 2; i <= n; i++)
                {
                    r *= i;
                }
            
           
            return n;
        }

        public static int FactorialRecursive(int n)
        {
           int r;    
                if (n > 1)
                {
                  r  = n * FactorialRecursive(n - 1);
                } 

            return 1;
        }
    }
}
