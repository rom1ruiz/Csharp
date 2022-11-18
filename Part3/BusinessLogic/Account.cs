using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Part3.BusinessLogic
{
    public class Account
    {
        private int _accountNumber, _age, idMngr;
        private string _type;
        private DateTime _dateOuv;
        private DateTime _dateClo;
        private double _balance;
        private const int _maxWithdraw = 1000;
        private List<Transaction> _transactions;

        public int AccountNumber => _accountNumber;
        public DateTime DateOuv { get => _dateOuv; set => _dateOuv = value; }
        public DateTime DateClo { get => _dateClo; set => _dateClo = value; }
        public double Balance { get => _balance; set => _balance = value; }
        public int Age { get => _age; set => _age = value; }
        public static int MaxWithdraw => _maxWithdraw;
        public int IdMngr { get => idMngr; set => idMngr = value; }
        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
        public string Type { get => _type; set => _type = value; }

        public Account(int accountNumber, string type, DateTime date, double balance, int age, int idMngr)
        {
            _accountNumber = accountNumber;
            _type = type;
            _dateOuv = date;
            _balance = balance;
            _age = age;
            _transactions = new List<Transaction>();
            IdMngr = idMngr;
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
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
