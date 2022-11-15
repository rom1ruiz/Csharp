using Part_2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    public class Account
    {
        private int _accountNumber;
        private DateTime _dateOuv;
        private DateTime _dateClo;
        private double _balance;
        private const int _maxWithdraw = 1000;
        private List<Transaction> _transactions;
        private int idMngr;

        public int AccountNumber => _accountNumber;
        public DateTime DateOuv { get => _dateOuv; set => _dateOuv = value; }
        public DateTime DateClo { get => _dateClo; set => _dateClo = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public static int MaxWithdraw => _maxWithdraw;
        public int IdMngr { get => idMngr; set => idMngr = value; }
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }

        public Account(int accountNumber, DateTime date, double balance, int idMngr)
        {
            _accountNumber = accountNumber;
            _dateOuv = date;
            _balance = balance;
            _transactions = new List<Transaction>();
            IdMngr = idMngr;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public bool Addtransaction(Transaction transaction, int numberOfTrxn)
        {
            int j = 0;
            //Si premiere date < date transaction < premiere date - 1 semaine
            for (int i = 0; i < _transactions.Count; i++)
            {
                if (_transactions[i].Date <= _transactions[j].Date.AddDays(7))
                {
                    //SI nombre de transaction n'excede pas la nombre de transactions autorisés
                    //Et si la somme des transactions n'excede pas la maximum de retrait
                    if (_transactions.Count <= numberOfTrxn && SumTransactions(_transactions) <= MaxWithdraw)
                    {
                        _transactions.Add(new Transaction(transaction.Id, transaction.Date, transaction.Amount, transaction.Sender, transaction.Receiver));
                    }

                }
                else
                {
                    j = i;
                }
            }

            return false;
        }

        public double SumTransactions(List<Transaction> transactions)
        {
            double sum = 0;
            foreach (Transaction transaction in transactions)
            {
                sum += transaction.Amount;
            }
            return sum;
        }


    }
}
