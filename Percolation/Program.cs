using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {

            // 3.Ouverture d'une case:

            // b. Dans le pire des cas il ne peut y avoir que 2 case ouverte,
            // autour de la case que l'on essaye d'ouvrir, car les case positionnée dans les coins
            // n'ont seulement 2 voisine

            // c. Etant donné que nous travaillons avec un carré, il ne peut y avoir que 4 cas
            int n = 6;
            PercolationSimulation ps = new PercolationSimulation();
            ps.PercolationValue(n);


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
