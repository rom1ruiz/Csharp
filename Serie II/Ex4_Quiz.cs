using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public struct Qcm
    {
        public string Question;
        public string[] Answers;
        public int Solution;
        public int Point;

        public Qcm(string question, string[] answers, int solution, int point)
        {
            Question = question;
            Answers = answers;
            Solution = solution;
            Point = point;
        }
    }

    public static class Quiz
    {
        public static void AskQuestions(Qcm[] qcms)
        {
            
            int nbTotPts = 0;
            for (int i = 0; i < qcms.Length; i++)
            {
                nbTotPts += AskQuestion(qcms[i]);
                
            }
            Console.WriteLine($"Résultat du questionnaire :{nbTotPts} / {qcms.Length}");
        }

        public static int AskQuestion(Qcm qcm)
        {
            string reponse;
            int answer = 0;
            bool isCorrect = false;
            int nbPoint = 0;
            //if (QcmValidity(qcm)) 
            if (QcmValidity(qcm) == true)
            {
                // Affiche la question
                Console.WriteLine(qcm.Question);
                // Affiche les réponses
                for (int i = 0; i < qcm.Answers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {qcm.Answers[i]}");
                }
                //while (!isCorrect)
                while (isCorrect != true)
                {
                    Console.WriteLine("Réponse : ");
                    // J'attend une réponse utilisateur
                    reponse = Console.ReadLine();

                    isCorrect = int.TryParse(reponse, out answer) && answer > 0 && answer <= qcm.Answers.Length;
                    // vérifie si réponse est "valide" (dans l'intervalle de question)
                    //if (!isCorrect)
                    if (isCorrect == false)
                    {
                        Console.WriteLine("Veuillez saisir une réponse valide !");
                    }

                }

                if (answer - 1 == qcm.Solution)
                {
                    // si correcte attribution des points sinon 0 pt
                    nbPoint = qcm.Point;
                }

            }
            return nbPoint;
        }

        public static bool QcmValidity(Qcm qcm)
        {
            //Si la solution est comprise dans la nombre de réponse,
            //et si la solution est supérieur à 0
            //et si le nombre de point > 0
            if (qcm.Solution < qcm.Answers.Length && qcm.Solution >= 0 && qcm.Point > 0)
            {
                return true;
            }


            return false;
        }
    }
}
