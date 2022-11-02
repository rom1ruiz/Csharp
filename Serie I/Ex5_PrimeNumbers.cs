using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class PrimeNumbers
    {
        static bool IsPrime(int valeur)
        {

            //pour tout nombre allant de 2 à racine de valeur
            for (int i = 2; i <= Math.Sqrt(valeur); i++)
            {
                // si valeur est divisible par ce nombre alors valeur n'est pas premier
                if (valeur % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void DisplayPrimes()
        {
            for (int i = 2; i <= 100; i++)
            {
                //if (IsPrime(i))
                if (IsPrime(i) == true)
                {
                    Console.WriteLine(i);
                }
                
            }

        }
    }
}
