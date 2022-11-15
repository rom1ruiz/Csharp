using Part_2;
using System;
using System.Collections.Generic;
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
        private readonly List<Transaction> _transactions = new List<Transaction>();
        private int idMngr;

        public int AccountNumber => _accountNumber;
        public DateTime DateOuv { get => _dateOuv; set => _dateOuv = value; }
        public DateTime DateClo { get => _dateClo; set => _dateClo = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public static int MaxWithdraw => _maxWithdraw;
        public int IdMngr { get => idMngr; set => idMngr = value; }

        public Account(int accountNumber, DateTime date, double balance, int idMngr)
        {
            _accountNumber = accountNumber;
            _dateOuv = date;
            _balance = balance;
            IdMngr = idMngr;
        }

        public bool AddTransaction(int id, DateTime date, double amount, int sender, int receiver)
        {

            if (_transactions.Count <= 10 && SumTransactions(_transactions) <= MaxWithdraw)
            {
                _transactions.Add(new Transaction(id, date, amount, sender, receiver));
            }

            return false;
        }

        private double SumTransactions(List<Transaction> transactions)
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
