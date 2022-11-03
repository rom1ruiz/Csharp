using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            char ope = '+';
            ElementaryOperations.BasicOperation(a, b, ope);
            ElementaryOperations.IntegerDivision(a, b);
            ElementaryOperations.Pow(a, b);

            string date = SpeakingClock.GoodDay(DateTime.Now.Hour);
            Console.WriteLine(date);
            int fact = Factorial.Factorial_(5);
            Console.WriteLine($"Factiorel de 5 : {fact}");
            
            PrimeNumbers.DisplayPrimes();
            Console.WriteLine($" PGCD = {Euclide.Pgcd(6, 7)}");
            Console.WriteLine($" PGCD Recur = {Euclide.PgcdRecursive(7, 9)}");
            Pyramid.PyramidConstruction(10, true);
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
