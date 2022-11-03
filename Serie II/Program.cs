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

            int valeur = 12;
            int[] tab = new int[] { -3, 2, 3, 4, 5, 8, 9, 12 };
            //Console.WriteLine($"LinearSearch : {Search.LinearSearch(tab, valeur)}");
            Array.Sort(tab);
            //Console.WriteLine($"BinarySearch : {Search.BinarySearch(tab, valeur)}");

            Eratosthene.EratosthenesSieve(100);
            // 
            string[] q1 = new string[] { "42", "45", "54", "49" };
            Qcm qcm1 = new Qcm("Combien font 7x7?", q1, 3, 1);

            string[] q2 = new string[] { "476", "800", "1066", "1789" };
            Qcm qcm2 = new Qcm("Quelle est l'année du sacre de Charlemagne?", q2, 1, 1);

            string[] q3 = new string[] { "Macron", "De Gaulle", "Chirac" };
            Qcm qcm3 = new Qcm("Quel est le nom du président de la République en 2022 ?", q3, 0, 1);

            string[] q4 = new string[] { "1", "10", "1 000", "D" };
            Qcm qcm4 = new Qcm("Quelle est la durée de vie moyenne d'une naine jaune (en milliard d'année) ?", q4, 0, 1);

            Qcm[] questionnaire = { qcm1, qcm2, qcm3, qcm4 };
            Quiz.AskQuestions(questionnaire);
            //Console.WriteLine(Quiz.AskQuestion(qcm1));




            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
