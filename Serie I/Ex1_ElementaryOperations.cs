using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            switch(operation)
            {
                case '+':
                    Console.WriteLine($"{a}+{b} = { (a + b)} ");
                    break;
                case '-':
                    Console.WriteLine($"{a}+{b} = { (a - b)} ");
                    break;
                case '/':
                    Console.WriteLine($"{a}+{b} = { (a / b)} ");
                    break;
                case '*':
                    Console.WriteLine($"{a}+{b} = { (a * b)} ");
                    break;
                


            }
                
        }

        public static void IntegerDivision(int a, int b)
        {
            int q = (a / b);
            int r = (a % b);
            if (a % b == 0)
            {
                Console.WriteLine($"{a}= {q} * {b}");
            }
            else if (a == 0 || b == 0)
            {
                Console.WriteLine("Opération invalide");
            }
            else
            {
                Console.WriteLine($"{a}= {q} * {b} + {r}");
            }
        }

        public static void Pow(int a, int b)
        {
            int resultat = 1;
            if (b >= 0)
            {
                for (int i = 1; i <= b; i++)
                {

                    resultat *= a;

                }
                Console.WriteLine($"{a} ^ {b} = {resultat}");
            } 
            else
            {
                Console.WriteLine("Opération invalide");
            }

            
            
        }
    }
}
