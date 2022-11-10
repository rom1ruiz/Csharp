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
        private double _balance;
        private const int _maxWithdraw = 1000;
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public int AccountNumber => _accountNumber;
        public double Balance { get => _balance; set => _balance = value; }
        public static int MaxWithdraw => _maxWithdraw;


        public Account(int accountNumber, double balance)
        {
            _accountNumber = accountNumber;
            _balance = balance;
        }

        public bool MakeDeposit(double amount)
        {
            if (IsAmountValid(amount))
            {
                _balance = _balance + amount;
                return true;
            }
            return false;
        }

        public bool MakeWithdraw(double amount)
        {
            if (IsAmountValid(amount) && amount < _balance)
            {
                _balance = _balance - amount;
                return true;
            }
            return false;
        }

        private static bool IsAmountValid(double amount)
        {
            return amount > 0;
        }

        public bool AddTransaction(int id, double amount, int sender, int receiver)
        {
            _transactions.Add(new Transaction(id, amount, sender, receiver));
            return false;
        }


    }
}
