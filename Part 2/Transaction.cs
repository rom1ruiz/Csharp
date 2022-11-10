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
        private double amount;
        private int sender;
        private int receiver;


        public int Id { get => id; }
        public double Amount { get => amount; set => amount = value; }
        public int Sender { get => sender; }
        public int Receiver { get => receiver; }


        public Transaction(int id, double amount , int sender, int receiver)
        {
            this.id = id;
            this.amount = amount;
            this.sender = sender;
            this.receiver = receiver;
        }



    }
}
