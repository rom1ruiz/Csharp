using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    internal class Manager
    {
        private int _id;
        private string _type;
        private int _number_trxn;

        public int Id => _id;
        public string Type => _type;
        public int Number => _number_trxn;
        public double SumFees {get; set;}

        public Manager(int id, string type, int number)
        {
            _id = id;
            _type = type;
            _number_trxn = number;
        }





    }
}
