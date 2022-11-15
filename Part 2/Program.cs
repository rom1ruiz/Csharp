using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Récupération du chemin d'éxecution
            string path = Directory.GetCurrentDirectory();
            for (int p = 0; p < 1; p++)
            {

                #region Initialize
                //Entrées
                string mngrPath = path + $@"\Gestionnaires_{p}.txt";
                string acctPath = path + $@"\Comptes_{p}.txt";
                string trxnPath = path + $@"\Transactions_{p}.txt";

                //Sorties
                string sttsOpePath = path + $@"\StatutOpe_{p}.txt";
                string sttsTrxnPath = path + $@"\StatutTra_{p}.txt";
                string mrtlPath = path + $@"\Metrologie_{p}.txt";
                Bank b = new Bank();
                //Création d'une liste de comptes
                List<Operation> operations = b.ReadOperationsFile(acctPath);

                //Création d'une liste de transactions
                List<Transaction> transactions = b.ReadTransactionsFile(trxnPath);

                //Création d'une liste de gestionnaires
                b.ReadManagersFile(mngrPath);

                #endregion
                using (StreamWriter writerOpe = new StreamWriter(sttsOpePath), writerTrxn = new StreamWriter(sttsTrxnPath), writerMetro = new StreamWriter(mrtlPath))
                {
                    int iOp = 0;
                    int iTr = 0;
                    while (operations.Count > iOp && transactions.Count > iTr)
                    {
                        //SI Operation en premier
                        if (operations[iOp].Date <= transactions[iTr].Date)
                        {
                            //On écrit dans le fichier Operations
                            b.WriteOperation(b.MakeOperation(iOp, operations), writerOpe);
                            iOp++;
                        }
                        else
                        {
                            //On écrit dans le fichier Transactions
                            b.WriteTransaction(b.MakeTransaction(iTr, transactions), writerTrxn);
                            iTr++;
                        }
                    }
                    //SI il reste des operations
                    while (operations.Count > iOp)
                    {
                        //On écrit dans le fichier Operations
                        b.WriteOperation(b.MakeOperation(iOp, operations), writerOpe);
                        iOp++;
                    }
                    //SI il reste des transactions
                    while (transactions.Count > iTr)
                    {
                        //On écrit dans le fichier Transactions
                        b.WriteTransaction(b.MakeTransaction(iTr, transactions), writerTrxn);
                        iTr++;
                    }
                    b.WriteMetrologie(writerMetro);

                }

            }
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}


