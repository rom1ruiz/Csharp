using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    internal class Manager
    {
        readonly int id_mngr;
        private string type;
        private int number_trxn;
        private int number_done;
        private List<Account> _accounts;

        public int Id => id_mngr;
        public string Type => type; 
        public int Number => number_trxn;
        public int Number_done { get => number_done; set => number_done = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }

        public Manager(int id, string type, int number)
        {
            this.id_mngr = id;
            this.type = type;
            number_trxn = number;
            _accounts = new List<Account>();
        }

        public double CalculFraisGestion(double amount,string type)
        {
            if(amount > 0)
            {
                switch (type)
                {
                    case "Particulier":
                        return amount;
                    case "Entreprise":
                        return amount;
                    default:
                        break;
                }
                
            }
            return -1;
        }



    }
}
