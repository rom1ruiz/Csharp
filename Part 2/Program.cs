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


                List<int> duplicatesMngr = new List<int>();

                foreach (Operation operation in operations)
                {
                    //duplicatesOper.Add(operation.Id);
                    //if (!w.IsThisADuplicateOper(operation.Id, duplicatesOper))

                    foreach (Transaction transaction in transactions)
                    {
                        //SI Operation en premier
                        if (operation.Date <= transaction.Date)
                        {
                            bool opOk = false;
                            //Open
                            if (operation.Input != 0 && operation.Output == 0)
                            {
                                opOk = b.OpenAccount(operation);
                            }
                            //Close
                            else if (operation.Input == 0 && operation.Output != 0)
                            {
                                opOk = b.CloseAccount(operation);
                            }
                            //Transfer
                            else if (operation.Input != 0 && operation.Output != 0)
                            {
                                opOk = b.TransferAccount(operation);
                            }
                            //...
                        }
                        else if (operation.Date > transaction.Date)
                        {
                            bool trxnOk = false;

                            //Withdrawal
                            if (transaction.Sender != 0 && transaction.Receiver == 0)
                            {
                                trxnOk = b.MakeWithdrawal(transaction);
                            }
                            //Deposit
                            else if (transaction.Sender == 0 && transaction.Receiver != 0)
                            {
                                trxnOk = b.MakeDeposit(transaction);
                            }
                            //Transfer
                            else if (transaction.Sender != 0 && transaction.Receiver != 0)
                            {
                                trxnOk = b.MakeTranfer(transaction);
                            }
                            //...
                            /**
                            //int nid = transaction.Id;
                            //DateTime date_ef = transaction.Date;
                            //double amnt = transaction.Amount;
                            //int sndr = transactions[i].Sender;
                            //int rcvr = transactions[i].Receiver;
                            //int s = w.WhereIsThisAccount(sndr, manager.Accounts);
                            //int r = w.WhereIsThisAccount(rcvr, managers[i].Accounts);

                            //Si le n°id a un doublon
                            if (!b.IsThisADuplicateTrxn(transaction.Id, duplicatesTrxn))
                                {
                                    duplicatesTrxn.Add(nid);
                                    if (sndr == 0 && rcvr == 0)
                                    {
                                        //Alors cas d'erreur transaction impossible
                                        trxnOk = false;
                                    }

                                    //Dépôt 
                                    else if (sndr == 0)
                                    {
                                        if (r != -1 && accounts[r].MakeDeposit(amnt))
                                        {
                                            //Alors on effectue un dépôt sur le compte receiver
                                            //On crédite l'amount à receiver
                                            accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);

                                            isTrxnValid = true;
                                        }
                                    }

                                    //Retrait
                                    else if (rcvr == 0)
                                    {
                                        if (s != -1 && accounts[s].MakeWithdraw(amnt))
                                        {
                                            //Alors on effectue un retrait sur le compte sender
                                            //On retire l'amount à sender
                                            accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                            isTrxnValid = true;
                                        }
                                    }
                                    //Virement
                                    else if (s != -1 && r != -1 && accounts[s].MakeWithdraw(amnt) && accounts[r].MakeDeposit(amnt))
                                    {
                                        //Alors on effectue un virement de sender vers receiver
                                        // On retire l'amount à sender et on le crédite à receiver
                                        accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        isTrxnValid = true;
                                    }
                                }
                            }
                        }
                        /**
                        //SINON Transaction en premier
                        else
                        {
                            //Déterminer nature transaction


                            //Alors on traite la transaction
                            for (int i = 0; i < transactions.Count; i++)
                            {
                                int nid = transaction.Id;
                                DateTime date_ef = transaction.Date;
                                double amnt = transaction.Amount;
                                int sndr = transactions[i].Sender;
                                int rcvr = transactions[i].Receiver;
                                int s = w.WhereIsThisAccount(sndr, managers[i].Accounts);
                                int r = w.WhereIsThisAccount(rcvr, managers[i].Accounts);
                                bool isTrxnValid = false;

                                //Si le n°id a un doublon
                                if (!w.IsThisADuplicateTrxn(nid, duplicatesTrxn))
                                {
                                    duplicatesTrxn.Add(nid);
                                    if (sndr == 0 && rcvr == 0)
                                    {
                                        //Alors cas d'erreur transaction impossible
                                        isTrxnValid = false;
                                    }

                                    //Dépôt 
                                    else if (sndr == 0)
                                    {
                                        if (r != -1 && accounts[r].MakeDeposit(amnt))
                                        {
                                            //Alors on effectue un dépôt sur le compte receiver
                                            //On crédite l'amount à receiver
                                            accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);

                                            isTrxnValid = true;
                                        }
                                    }

                                    //Retrait
                                    else if (rcvr == 0)
                                    {
                                        if (s != -1 && accounts[s].MakeWithdraw(amnt))
                                        {
                                            //Alors on effectue un retrait sur le compte sender
                                            //On retire l'amount à sender
                                            accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                            isTrxnValid = true;
                                        }
                                    }
                                    //Virement
                                    else if (s != -1 && r != -1 && accounts[s].MakeWithdraw(amnt) && accounts[r].MakeDeposit(amnt))
                                    {
                                        //Alors on effectue un virement de sender vers receiver
                                        // On retire l'amount à sender et on le crédite à receiver
                                        accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        isTrxnValid = true;
                                    }
                                }
                            }
                        }
                        /**/
                        }
                    }

                    /**
                    using (StreamWriter writer = new StreamWriter(sttsOpePath))
                    {
                        for (int i = 0; i < managers.Count; i++)
                        {
                            int idMngr = managers[i].Id;
                            duplicatesMngr.Add(idMngr);
                            string type = managers[i].Type;
                            int number_trxn = managers[i].Number;
                            bool isOpeValid = false;

                            if (IsThisADuplicateMngr(idMngr))
                            {
                                foreach (Account acc in accounts)
                                {
                                    int intp = WhereIsThisManager(acc.Input);
                                    int outp = WhereIsThisManager(acc.Output);
                                    //Création de compte
                                    if (acc.Input == idMngr && acc.Output == 0)
                                    {
                                        //Ajout du compte dans la liste du manager
                                        managers[i].Accounts.Add(acc);
                                        isOpeValid = true;

                                    }
                                    //Clôture de compte
                                    else if (acc.Output == idMngr && acc.Input == 0)
                                    {
                                        //Suppression du compte dans la liste du manager
                                        managers[i].Accounts.Remove(acc);
                                        isOpeValid = true;
                                    }
                                    //Cession de compte
                                    else if (acc.Input == idMngr && outp != -1)
                                    {
                                        //On enleve le compte de la liste du premier
                                        managers[i].Accounts.Remove(acc);
                                        isOpeValid = true;

                                        //Et on l'ajoute dans la liste du deuxieme
                                        managers[outp].Accounts.Add(acc);
                                        isOpeValid = true;
                                    }

                                }
                                if (isOpeValid)
                                {
                                    writer.WriteLine($"{i};OK");
                                }
                                else
                                {
                                    writer.WriteLine($"{i};KO");
                                }
                            }
                        }

                    }

                    using (StreamWriter writer = new StreamWriter(sttsTrxnPath))
                    {
                        for (int i = 0; i < transactions.Count; i++)
                        {
                            int nid = transactions[i].Id;
                            DateTime date_ef = transactions[i].Date;
                            double amnt = transactions[i].Amount;
                            int sndr = transactions[i].Sender;
                            int rcvr = transactions[i].Receiver;
                            int s = WhereIsThisAccount(sndr);
                            int r = WhereIsThisAccount(rcvr);
                            bool isTrxnValid = false;

                            //Si le n°id a un doublon
                            if (!IsThisADuplicateTrxn(nid))
                            {
                                duplicatesTrxn.Add(nid);
                                if (sndr == 0 && rcvr == 0)
                                {
                                    //Alors cas d'erreur transaction impossible
                                    isTrxnValid = false;
                                }

                                //Dépôt 
                                else if (sndr == 0)
                                {
                                    if (r != -1 && accounts[r].MakeDeposit(amnt))
                                    {
                                        //Alors on effectue un dépôt sur le compte receiver
                                        //On crédite l'amount à receiver
                                        accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        
                                        isTrxnValid = true;
                                    }
                                }

                                //Retrait
                                else if (rcvr == 0)
                                {
                                    if (s != -1 && accounts[s].MakeWithdraw(amnt))
                                    {
                                        //Alors on effectue un retrait sur le compte sender
                                        //On retire l'amount à sender
                                        accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                        isTrxnValid = true;
                                    }
                                }
                                //Virement
                                else if (s != -1 && r != -1 && accounts[s].MakeWithdraw(amnt) && accounts[r].MakeDeposit(amnt))
                                {
                                    //Alors on effectue un virement de sender vers receiver
                                    // On retire l'amount à sender et on le crédite à receiver
                                    accounts[s].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                    accounts[r].AddTransaction(nid, date_ef, amnt, sndr, rcvr);
                                    isTrxnValid = true;
                                }
                            }
                            if (isTrxnValid)
                            {
                                writer.WriteLine($"{nid};OK");
                            }
                            else
                            {
                                writer.WriteLine($"{nid};KO");
                            }
                            Debug.WriteLine($"Transaction N° :{transactions[i].Id} ; {transactions[i].Amount} ; {transactions[i].Sender} ; {transactions[i].Receiver} ");
                        }

                    }


                    /**/
                }
                // Keep the console window open
                Console.WriteLine("----------------------");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }

