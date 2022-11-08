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
            #region Exo3
            //PhoneBook book = new PhoneBook();
            //book.AddPhoneNumber("0612324558", "toto");
            //book.AddPhoneNumber("0612324559", "titi");
            //book.AddPhoneNumber("0612324558", "toto");
            //try
            //{
            //    book.PhoneContact("0612354558");
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e.Message);

            //}

            //book.DisplayPhoneBook();
            //book.DeletePhoneNumber("0612324559");
            //book.DisplayPhoneBook(); 
            #endregion

            BusinessSchedule bs = new BusinessSchedule();
            try
            {
                bs.SetRangeOfDates(DateTime.Today, DateTime.Now.AddHours(6));
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }
            bs.DisplayMeetings();
            Console.WriteLine("Premier ajout");
            bs.AddBusinessMeeting(DateTime.Now, TimeSpan.FromMinutes(30));
            bs.DisplayMeetings();
            Console.WriteLine("Second ajout");
            bs.AddBusinessMeeting(DateTime.Now.AddMinutes(40), TimeSpan.FromMinutes(30));
            bs.DisplayMeetings();
            Console.WriteLine("Premiere suppression");
            bs.DeleteBusinessMeeting(DateTime.Now, TimeSpan.FromMinutes(30));
            bs.DisplayMeetings();
            bs.AddBusinessMeeting(DateTime.Now, TimeSpan.FromMinutes(30));
            bs.DisplayMeetings();
            Console.WriteLine("Clear schedule");
            bs.ClearMeetingPeriod(DateTime.Today, DateTime.Now.AddHours(6));
            bs.DisplayMeetings();

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
