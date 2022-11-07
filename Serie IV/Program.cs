using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Veuillez saisir un n° de téléphone:");
            //string phoneNumb = Console.ReadLine();
            PhoneBook book = new PhoneBook();
            book.AddPhoneNumber("0612324558", "toto");
            book.PhoneContact("0612324558");
            
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
