using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Part3.BusinessLogic;

namespace Part3.Types
{
    class Terme : Account
    {
        public Terme(int accountNumber, string type, DateTime date, double balance, int age, int idMngr) : base(accountNumber, type, date, balance, age, idMngr)
        {

        }
    }
}
