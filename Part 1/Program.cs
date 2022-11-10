using Serie_I;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialize
            //Récupération du chemin d'éxecution
            string path = Directory.GetCurrentDirectory();
            //Création du chemin d'accès vers le fichier accounts
            string acctPath = path + @"\Comptes_1.txt";
            //Création du chemin d'accès vers le fichier transactions
            string trxnPath = path + @"\Transactions_1.txt";
            //Création du chemin d'accès vers le fichier de sortie
            string sttsPath = path + @"\Statut_1.txt";

            //Création d'une liste de comptes
            List<Account> accounts = new List<Account>();

            //Création d'une liste de transactions
            List<Transaction> transactions = new List<Transaction>();

            List<int> duplicates = new List<int>();

            //accounts variables
            int account;
            double intialBalance;

            //transactions variables
            int id;
            int sender;
            int receiver;
            double amount;
            #endregion

            int WhereIsThis(int number)
            {
                //Account acc = accounts.Find(a => a.AccountNumber == number);
                //return acc!= null ? acc.AccountNumber : -1;

                for (int n = 0; n < accounts.Count; n++)
                {
                    //Si le numéro est égal a un numéro de compte
                    if (number == accounts[n].AccountNumber)
                    {
                        //Le compte existe
                        //alors on retourne l'indice du compte
                        return n;
                    }
                }
                return -1;
            }
            bool IsThisADuplicate(int nid)
            {
                //Si le n°Id est égal a un id
                if (duplicates.Contains(nid))
                {
                    //L'Id existe
                    return true;
                }

                return false;
            }


            #region Treaments_files
            //Lecture du fichier accounts
            using (StreamReader sr = new StreamReader(acctPath))
            {
                while (!sr.EndOfStream)
                {
                    var s = sr.ReadLine();
                    string[] split = s.Split(';');
                    int.TryParse(split[0], out account);
                    double.TryParse(split[1].Replace('.', ','), out intialBalance);
                    if (intialBalance >= 0)
                    {
                        accounts.Add(new Account(account, intialBalance));
                    }
                }
                for (int i = 0; i < accounts.Count; i++)
                {
                    Debug.WriteLine($"Compte {i} : N°{accounts[i].AccountNumber} ; {accounts[i].Balance}");
                }
            }
            //Lecture du fichier transactions
            using (StreamReader sr = new StreamReader(trxnPath))
            {
                while (!sr.EndOfStream)
                {
                    //Lire une ligne
                    var s = sr.ReadLine();
                    //Split de la ligne lu en tableau de string
                    string[] split = s.Split(';');
                    int.TryParse(split[0], out id);
                    double.TryParse(split[1], out amount);
                    int.TryParse(split[2], out sender);
                    int.TryParse(split[3], out receiver);
                    transactions.Add(new Transaction(id, amount, sender, receiver));
                }
            }
            using (StreamWriter writer = new StreamWriter(sttsPath))
            {
                for (int i = 0; i < transactions.Count; i++)
                {
                    int nid = transactions[i].Id;
                    double amnt = transactions[i].Amount;
                    int sndr = transactions[i].Sender;
                    int rcvr = transactions[i].Receiver;
                    int s = WhereIsThis(sndr);
                    int r = WhereIsThis(rcvr);
                    //Si le n°id a un doublon
                    if (!IsThisADuplicate(nid))
                    {
                        duplicates.Add(nid);
                        if (sndr == 0 && rcvr == 0)
                        {
                            //Alors cas d'erreur transaction impossible
                            writer.WriteLine($"{nid};KO");
                            Debug.WriteLine($"{nid};KO");
                        }

                        //Dépôt 
                        else if (sndr == 0)
                        {
                            if (r != -1 && accounts[r].MakeDeposit(amnt))
                            {
                                //Alors on effectue un dépôt sur le compte receiver
                                //On crédite l'amount à receiver
                                writer.WriteLine($"{nid};OK");
                                accounts[r].AddTransaction(nid, amnt, sndr, rcvr);
                                Debug.WriteLine($"{nid};OK");
                            }
                            else
                            {
                                writer.WriteLine($"{nid};KO");
                                Debug.WriteLine($"{nid};KO");
                            }
                        }

                        //Retrait
                        else if (rcvr == 0)
                        {
                            if (s != -1 && accounts[s].MakeWithdraw(amnt))
                            {
                                //Alors on effectue un retrait sur le compte sender
                                //On retire l'amount à sender
                                writer.WriteLine($"{nid};OK");
                                accounts[s].AddTransaction(nid, amnt, sndr, rcvr);
                                Debug.WriteLine($"{nid};OK");
                            }
                            else
                            {
                                writer.WriteLine($"{nid};KO");
                                Debug.WriteLine($"{nid};KO");
                            }

                        }
                        //Virement
                        else
                        {
                            //Alors on effectue un virement de sender vers receiver
                            // On retire l'amount à sender et on le crédite à receiver
                            if (s != -1 && r != -1 && accounts[s].MakeWithdraw(amnt) && accounts[r].MakeDeposit(amnt))
                            {
                                writer.WriteLine($"{nid};OK");
                                accounts[s].AddTransaction(nid, amnt, sndr, rcvr);
                                accounts[r].AddTransaction(nid, amnt, sndr, rcvr);
                                Debug.WriteLine($"{nid};OK");
                            }
                            else
                            {
                                writer.WriteLine($"{nid};KO");
                                Debug.WriteLine($"{nid};KO");
                            }

                        }
                    }
                    else
                    {
                        writer.WriteLine($"{nid};KO");
                        Debug.WriteLine("Duplicate");
                    }
                    Debug.WriteLine($"Transaction N° :{transactions[i].Id} ; {transactions[i].Amount} ; {transactions[i].Sender} ; {transactions[i].Receiver} ");
                }


            }
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        #endregion
    }

}

