﻿using System;
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
            //Dictionary<string, List<string>> dico = new Dictionary<string, List<string>>();
            //List<string> moyennes = new List<string>();


            //string ligne;
            //int cptLigne = 0;

            //using (StreamReader reader = new StreamReader(inputfilepath))
            //{
            //    while (!reader.EndOfStream)
            //    {
            //        ligne = reader.ReadLine();
            //        string[] split = ligne.Split(';');
            //        string matiere = split[1];
            //        string note = split[2];
            //        if (!dico.ContainsKey(matiere))
            //        {
            //            dico.Add(matiere, new List<string>());
            //        }
            //        dico[matiere].Add(note);
            //    }
            //    Console.WriteLine($"Nombre de ligne: {cptLigne}");
            //}

            //using (StreamWriter writer = new StreamWriter(outputfilepath))
            //{
            //    foreach (KeyValuePair<string, List<string>> item in dico)
            //    {
            //        double cpt = 0;
            //        float moyenne = 0;
            //        Console.WriteLine(item.Key);

            //        //foreach (string s in item.Value)
            //        foreach (string s in dico[item.Key])
            //        {
            //            string r = s.Replace('.', ',');
            //            moyenne += float.Parse(r);
            //            cpt++;
            //        }
            //        Console.WriteLine(cpt);
            //        Console.WriteLine(moyenne / cpt);
            //        writer.WriteLine($"{item.Key};{moyenne / cpt}");
            //    }
            //}


            //SortingPerformance.UseQuickSort(array);
            //SortingPerformance.UseInsertionSort(array);
            List<int> size = new List<int> { 10000, 20000, 50000 };
            SortingPerformance.PerformancesTest(size, 10);


            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
