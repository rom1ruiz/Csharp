using Part_2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    internal class Bank
    {
        Dictionary<int, Manager> _managers;
        Dictionary<int, Account> _accounts;
        List<int> _trxn;
        private int numberOfCreated, numberOfTransaction, numberOfOK, numberOfKO;
        private double sumOfOK;

        public Bank()
        {
            _managers = new Dictionary<int, Manager>();
            _accounts = new Dictionary<int, Account>();
            _trxn = new List<int>();
        }

        public void ReadManagersFile(string path)
        {
            List<string> dataMngr = new List<string>();

            using (FileStream input = File.OpenRead(path))
            {
                using (StreamReader sr = new StreamReader(input))
                {
                    while (!sr.EndOfStream)
                    {
                        dataMngr.Add(sr.ReadLine());
                    }
                }
            }

            _managers = ParseDataMngr(dataMngr);
        }
        public Dictionary<int, Manager> ParseDataMngr(List<string> dataMngr)
        {
            Dictionary<int, Manager> managers = new Dictionary<int, Manager>();
            int id;
            string type;
            int number_trxn;
            foreach (string line in dataMngr)
            {

                //Split de la ligne lu en tableau de string
                string[] split = line.Split(';');
                int.TryParse(split[0], out id);
                type = split[1];
                int.TryParse(split[2], out number_trxn);
                if (!managers.ContainsKey(id))
                {
                    managers.Add(id, new Manager(id, type, number_trxn));
                }
            }

            return managers;
        }
        public List<Operation> ReadOperationsFile(string path)
        {
            List<string> dataAcc = new List<string>();

            using (FileStream input = File.OpenRead(path))
            {
                using (StreamReader lecteur = new StreamReader(input))
                {
                    while (!lecteur.EndOfStream)
                    {
                        dataAcc.Add(lecteur.ReadLine());
                    }
                }
            }

            return ParseDataOperations(dataAcc);
        }
        public List<Operation> ParseDataOperations(List<string> dataAcc)
        {
            List<Operation> operations = new List<Operation>();
            int account;
            DateTime date;
            double initialBalance;
            int input;
            int output;
            foreach (string line in dataAcc)
            {
                string[] split = line.Split(';');
                int.TryParse(split[0], out account);
                DateTime.TryParse(split[1], out date);
                double.TryParse(split[2].Replace('.', ','), out initialBalance);
                int.TryParse(split[3], out input);
                int.TryParse(split[4], out output);
                if (initialBalance >= 0)
                {
                    operations.Add(new Operation(account, date, initialBalance, input, output));
                }
            }

            return operations;
        }
        public List<Transaction> ReadTransactionsFile(string path)
        {
            List<string> dataTransactions = new List<string>();

            using (FileStream input = File.OpenRead(path))
            {
                using (StreamReader lecteur = new StreamReader(input))
                {
                    while (!lecteur.EndOfStream)
                    {
                        dataTransactions.Add(lecteur.ReadLine());
                    }
                }
            }

            return ParseDataTransactions(dataTransactions);
        }
        public List<Transaction> ParseDataTransactions(List<string> dataTransactions)
        {
            List<Transaction> transactions = new List<Transaction>();
            int id;
            DateTime date_ef;
            double amount;
            int sender;
            int receiver;
            foreach (string line in dataTransactions)
            {
                string[] split = line.Split(';');
                int.TryParse(split[0], out id);
                DateTime.TryParse(split[1], out date_ef);
                double.TryParse(split[2], out amount);
                int.TryParse(split[3], out sender);
                int.TryParse(split[4], out receiver);
                transactions.Add(new Transaction(id, date_ef, amount, sender, receiver));
            }

            return transactions;
        }

        public bool OpenAccount(Operation operation)
        {
            if (_managers.ContainsKey(operation.Input) && !AccountExists(operation.Id) && operation.Balance >= 0)
            {
                _accounts.Add(operation.Id, new Account(operation.Id, operation.Date, operation.Balance, operation.Input));
                numberOfCreated++;
                return true;
            }
            return false;
        }
        public bool CloseAccount(Operation operation)
        {
            if (_managers.ContainsKey(operation.Output) && AccountExists(operation.Id) && _accounts[operation.Id].IdMngr == operation.Output)
            {
                return _accounts.Remove(operation.Id);
            }
            return false;
        }
        public bool TransferAccount(Operation operation)
        {
            if (_managers.ContainsKey(operation.Input) && _managers.ContainsKey(operation.Output) && AccountExists(operation.Id) && _accounts[operation.Id].IdMngr == operation.Input)
            {
                _accounts[operation.Id].IdMngr = operation.Output;
                return true;
            }
            return false;
        }

        public bool MakeDeposit(Transaction transaction)
        {
            if (IsAmountValid(transaction.Amount) && AccountExists(transaction.Receiver))
            {
                _accounts[transaction.Receiver].Balance += transaction.Amount;
                sumOfOK += transaction.Amount;
                return true;
            }
            return false;
        }
        public bool MakeWithdrawal(Transaction transaction)
        {
            if (IsAmountValid(transaction.Amount) && AccountExists(transaction.Sender)
                && transaction.Amount < _accounts[transaction.Sender].Balance
                && CheckWeeklyTransactions(transaction) && CheckLastTransactions(transaction))
            {
                _accounts[transaction.Sender].Balance -= transaction.Amount;
                _accounts[transaction.Sender].AddTransaction(transaction);
                sumOfOK += transaction.Amount;
                return true;
            }
            return false;
        }
        internal bool MakeTranfer(Transaction transaction)
        {
            if (IsAmountValid(transaction.Amount)
                && AccountExists(transaction.Receiver)
                && AccountExists(transaction.Sender)
                && transaction.Amount < _accounts[transaction.Sender].Balance
                && CheckWeeklyTransactions(transaction) && CheckLastTransactions(transaction))
            {
                double frais = 0;
                if (_accounts[transaction.Sender].IdMngr != _accounts[transaction.Receiver].IdMngr)
                {
                    frais = CalculFraisGestion(transaction.Amount, _managers[_accounts[transaction.Sender].IdMngr].Type);
                    _managers[_accounts[transaction.Sender].IdMngr].SumFees += frais;
                }
                _accounts[transaction.Sender].Balance -= (transaction.Amount + frais);
                _accounts[transaction.Sender].AddTransaction(transaction);
                _accounts[transaction.Receiver].Balance += transaction.Amount;
                sumOfOK += transaction.Amount;
                return true;
            }
            return false;
        }

        public bool MakeOperation(int indice, List<Operation> operations)
        {
            bool opOk = false;
            //Open
            if (operations[indice].Input != 0 && operations[indice].Output == 0)
            {
                opOk = OpenAccount(operations[indice]);

            }
            //Close
            else if (operations[indice].Input == 0 && operations[indice].Output != 0)
            {
                opOk = CloseAccount(operations[indice]);
            }
            //Transfer
            else if (operations[indice].Input != 0 && operations[indice].Output != 0)
            {
                opOk = TransferAccount(operations[indice]);
            }
            return opOk;
        }

        public bool MakeTransaction(int indice, List<Transaction> transactions)
        {
            bool trxnOk = false;
            //Withdrawal
            if (transactions[indice].Sender != 0 && transactions[indice].Receiver == 0)
            {
                trxnOk = MakeWithdrawal(transactions[indice]);
                //int accNumber = transactions[indice].Sender;
                //Account account = _accounts[accNumber];
                //int idMngr = account.IdMngr;
                //int numberOfTrxn = _managers[idMngr].Number;
                //_accounts[WhereIsThisAccount(accNumber, _accounts)].Addtransaction(transactions[indice], numberOfTrxn);

                numberOfTransaction++;
            }
            //Deposit
            else if (transactions[indice].Sender == 0 && transactions[indice].Receiver != 0)
            {
                trxnOk = MakeDeposit(transactions[indice]);
                //int accNumber = transactions[indice].Receiver;
                //Account account = _accounts[accNumber];
                //int idMngr = account.IdMngr;
                //int numberOfTrxn = _managers[idMngr].Number;
                //_accounts[WhereIsThisAccount(accNumber, _accounts)].Addtransaction(transactions[indice], numberOfTrxn);
                numberOfTransaction++;
            }
            //Transfer
            else if (transactions[indice].Sender != 0 && transactions[indice].Receiver != 0)
            {
                trxnOk = MakeTranfer(transactions[indice]);
                //int accSender = transactions[indice].Sender;
                //Account accountS = _accounts[accSender];
                //int idMngrS = accountS.IdMngr;
                //int numberOfTrxnS = _managers[idMngrS].Number;
                //_accounts[WhereIsThisAccount(accSender, _accounts)].Addtransaction(transactions[indice], numberOfTrxnS);
                //int accReceiver = transactions[indice].Receiver;
                //Account accountR = _accounts[accReceiver];
                //int idMngrR = accountR.IdMngr;
                //int numberOfTrxnR = _managers[idMngrR].Number;
                //_accounts[WhereIsThisAccount(accReceiver, _accounts)].Addtransaction(transactions[indice], numberOfTrxnR);
                numberOfTransaction++;
            }
            return trxnOk;
        }

        public double CalculFraisGestion(double amount, string type)
        {
            double frais = 0;
            if (IsAmountValid(amount))
            {
                switch (type)
                {
                    case "Particulier":
                        frais = amount * 0.01;
                        return frais;
                    case "Entreprise":
                        frais = 10;
                        return frais;
                    default:
                        break;
                }

            }
            return -1;


        }

        public void WriteOperation(bool b,int id, StreamWriter writerOpe)
        {
            if (b)
            {
                writerOpe.WriteLine($"{id};OK");

            }
            else
            {
                writerOpe.WriteLine($"{id};KO");
            }
        }

        public void WriteTransaction(bool b,int id, StreamWriter writerTrxn)
        {
            if (b)
            {
                writerTrxn.WriteLine($"{id};OK");
                numberOfOK++;
            }
            else
            {
                writerTrxn.WriteLine($"{id};KO");
                numberOfKO++;
            }
        }

        public void WriteMetrologie(StreamWriter writerMetro)
        {
            writerMetro.WriteLine($"Statistiques: \n" +
                                  $"Nombre de comptes : {numberOfCreated} \n" +
                                  $"Nombre de transactions : {numberOfTransaction} \n" +
                                  $"Nombre de réussite : {numberOfOK} \n" +
                                  $"Nombre d'échecs : {numberOfKO} \n" +
                                  $"Montant total : {sumOfOK} euros \n \n" +
                                  $"Frais de gestion :");
            foreach (KeyValuePair<int, Manager> m in _managers)
            {
                writerMetro.WriteLine($"{m.Value.Id} : {m.Value.SumFees} euros");
            }
        }

        private static bool IsAmountValid(double amount)
        {
            return amount > 0;
        }

        private bool AccountExists(int accountNumber)
        {
            return _accounts.ContainsKey(accountNumber);
        }

        public bool IsThisADuplicateTrxn(int id, List<int> transactions)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                if (id == transactions[i])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsThisADuplicateMngr(int id, List<int> managers)
        {
            for (int i = 0; i < managers.Count; i++)
            {
                if (id == managers[i])
                {
                    return true;
                }
            }
            return false;

        }

        public bool IsThisADuplicateOper(int id, List<int> operations)
        {
            for (int i = 0; i < operations.Count; i++)
            {
                if (id == operations[i])
                {
                    return true;
                }
            }
            return false;
        }

        public int WhereIsThisManager(int id, Dictionary<int, Manager> managers)
        {
            for (int n = 0; n < managers.Count; n++)
            {
                if (id == managers[n].Id)
                {
                    return n;
                }
            }
            return -1;
        }

        public int WhereIsThisAccount(int id, Dictionary<int, Account> accounts)
        {
            for (int n = 0; n < accounts.Count; n++)
            {
                if (id == accounts[n].AccountNumber)
                {
                    return n;
                }
            }
            return -1;
        }


        private bool CheckWeeklyTransactions(Transaction t)
        {
            TimeSpan week = new TimeSpan(7, 0, 0, 0);
            List<Transaction> transactions = _accounts[t.Sender].Transactions;
            double total = 0;
            for (int i = transactions.Count - 1; i >= 0; i--)
            {
                if (transactions[i].Date > t.Date - week)
                {
                    total += transactions[i].Amount;
                }
                else
                    break;
            }
            return total + t.Amount <= 2000;
        }
        private bool CheckLastTransactions(Transaction t)
        {
            int nbr = _managers[_accounts[t.Sender].IdMngr].Number;
            List<Transaction> transactions = _accounts[t.Sender].Transactions;
            double total = 0;
            for (int i = transactions.Count - 1; i >= 0 && i >= transactions.Count - nbr; i--)
            {
                total += transactions[i].Amount;

            }
            return total + t.Amount <= 1000;

        }
    }
}
