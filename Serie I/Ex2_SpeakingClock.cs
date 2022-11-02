using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string nuit = "Merveilleuse nuit !";
            string matin = "Bonne matinée !";
            string midi = "Bon appétit !";
            string apresMidi = "Profitez de votre après-midi !";
            string finJournee = "Passez une bonne soirée!";

            switch (heure)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return nuit;
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                    return matin;
                case 12:
                    return midi;
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    return apresMidi;
                    
                


            }
            return finJournee;



        }
    }
}
