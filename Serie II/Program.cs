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
            Console.WriteLine("Questionnaire:");
            string[] q1 = new string[] { "Tombé dans la neige avant le 31 décembre \r", "Un frizby comestible \r", "Une Kipa surgelée \r", "La réponse D" };
            Qcm qcm1 = new Qcm("Lorsqu'un pancake tombe dans la neige avant le 31 décembre,\non dit qu'il est:", q1, 2, 1);

            string[] q2 = new string[] { "Qu'il n'est pas arrivé à Toronto\r", "Qu'il était supposé arriver à Toronto...\r", "Qu'est-ce qu'il fout ce maudit pancake, tabernacle?\r", "La réponse D" };
            Qcm qcm2 = new Qcm("Lorsqu'un pancake prend l'avion a destination de Toronto \net qu'il fait une escale technique à St Claude, on dit:", q2, 2, 1);

            string[] q3 = new string[] { "l'inciter à boire à l'Open Barmitzva\r", "lui présenter Raymond Barmitzva\r", "lui offrir des Malabarmitzva\r", "La réponse D" };
            Qcm qcm3 = new Qcm("Lorsqu'on invite un pancake à un Barmitzva \nles convives doivent :", q3, 0, 1);

            string[] q4 = new string[] { "En 1618, pendant la guerre des croissant au beurre\r", "En 1702, pendant la massacre du Saint Panini\r", "En 112, avant Céline Dion pendant la crise de la brioche\r", "La réponse D" };
            Qcm qcm4 = new Qcm("Au cours de quel évènement historique fut crée la pancake?", q4, 1, 1);

            Qcm[] questionnaire = { qcm1, qcm2, qcm3, qcm4 };
            //Quiz.AskQuestions(questionnaire);


            //Matrix
            /***   Première matrice   ***/
            int[] tab1 = new int[] { 5, 4, 3, 2, 1 };
            int[] tab2 = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine("Première matrice:");
            //Matrix.DisplayMatrix(Matrix.BuildingMatrix(tab1, tab2));
            //int[][] matrix1 = Matrix.BuildingMatrix(tab1, tab2);
            int[][] matrix1 =
            {
                new int[]{1,2},
                new int[]{4,6},
                new int[]{-1,8},
            };

            /***   Seconde matrice   ***/
            int[] tab3 = new int[] { 6, 7, 8, 9, 0 };
            int[] tab4 = new int[] { 0, 9, 8, 7, 6 };
            Console.WriteLine("Seconde matrice:");
            //Matrix.DisplayMatrix(Matrix.BuildingMatrix(tab3, tab4));
            //int[][] matrix2 = Matrix.BuildingMatrix(tab3, tab4);
            int[][] matrix2 =
            {
                new int[]{-1,5 },
                new int[]{ -4,0},
                new int[]{ 0,2},
            };

            /***   Addition     ***/
            Console.WriteLine("Addition :");
            Matrix.DisplayMatrix(Matrix.Addition(matrix1, matrix2));
            /***  Soustraction  ***/
            Console.WriteLine("Soustraction :");
            Matrix.DisplayMatrix(Matrix.Substraction(matrix1, matrix2));
            /*** Multiplication ***/
            Console.WriteLine("Multiplication :");
            Matrix.DisplayMatrix(Matrix.Multiplication(matrix1, matrix2));
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
