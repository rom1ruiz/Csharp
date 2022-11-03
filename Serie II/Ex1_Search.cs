using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                {

                    
                    return i;
                }


            }
            return -1;
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
            int mid = (tableau.Length / 2);
            int deb = 0;
            int fin = tableau.Length;
            while (deb != fin)
            {
                if (tableau[mid] == valeur)
                {
                    return mid;
                }
                else if (tableau[mid] > valeur)
                {
                    fin = tableau[mid];

                }
                

                
            }
            return -1;
        }
    }
}
