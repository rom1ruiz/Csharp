using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {

            int valeur = 7;
            int[] tab = new int[] { -3, 2, 3, 7, 5, 8, 9, 12 };
            Console.WriteLine($"LinearSearch : { Search.LinearSearch(tab, valeur)}");
            Array.Sort(tab);
            Console.WriteLine($"BinarySearch : {Search.BinarySearch(tab,valeur)}");
            Console.WriteLine($"BinarySearch : {Search.BinarySearch(tab,-4)}");
            Console.WriteLine($"BinarySearch : {Search.BinarySearch(tab,11)}");
            Search.BinarySearch(tab, valeur);
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
