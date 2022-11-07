using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    class Program
    {
        static void Main(string[] args)
        {
            //string currentpath = Directory.GetCurrentDirectory();
            //string inputfilepath = (currentpath + @"\entrée.txt");
            //string outputfilepath = (currentpath + @"\sortie.txt");
            //ClassCouncil.SchoolMeans(inputfilepath, outputfilepath);

            //SortingPerformance.UseQuickSort(array);
            //SortingPerformance.UseInsertionSort(array);


            List<int> size = new List<int> { 1000, 2000, 5000, 10000, 20000, 50000, 100000, 200000, 300000};
            //SortingPerformance.PerformancesTest(size, 10);
            SortingPerformance.DisplayPerformances(size,50);


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
