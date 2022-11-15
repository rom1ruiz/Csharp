using Part_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    public class Transaction
    {
        private int id;
        private DateTime date;
        private double amount;
        private int sender;
        private int receiver;


        public int Id => id;
        public DateTime Date => date;
        public double Amount { get => amount; set => amount = value; }
        public int Sender => sender;
        public int Receiver => receiver;

        public Transaction(int id, DateTime date, double amount , int sender, int receiver)
        {
            this.id = id;
            this.date = date;
            this.amount = amount;
            this.sender = sender;
            this.receiver = receiver;
        }


        



    }
}
