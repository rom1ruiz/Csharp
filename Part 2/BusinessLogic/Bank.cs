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
                return true;
            }
            return false;
        }

        public bool CloseAccount(Operation operation)
        {
            if (_managers.ContainsKey(operation.Input) && AccountExists(operation.Id) && _accounts[operation.Id].IdMngr == operation.Output)
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
                return true;
            }
            return false;
        }
        public bool MakeWithdrawal(Transaction transaction)
        {
            if (IsAmountValid(transaction.Amount) && transaction.Amount < _accounts[transaction.Sender].Balance)
            {
                _accounts[transaction.Sender].Balance = _accounts[transaction.Sender].Balance - transaction.Amount;
                return true;
            }
            return false;
        }
        internal bool MakeTranfer(Transaction transaction)
        {
            if (IsAmountValid(transaction.Amount) && AccountExists(transaction.Receiver) && AccountExists(transaction.Sender) &&  transaction.Amount < _accounts[transaction.Sender].Balance)
            {
                _accounts[transaction.Sender].Balance = _accounts[transaction.Sender].Balance - transaction.Amount;
                _accounts[transaction.Receiver].Balance += transaction.Amount;
                return true;
            }
            return false;
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

        public int WhereIsThisManager(int id, List<Manager> managers)
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

        public int WhereIsThisAccount(int id, List<Account> accounts)
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

    }
}
