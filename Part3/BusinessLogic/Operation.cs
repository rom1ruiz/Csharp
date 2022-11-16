using System;

namespace Part_3
{
    internal class Operation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Balance { get; set; }
        public int Input { get; set; }
        public int Output { get; set; }

        public Operation(int id, DateTime date, double solde, int input, int output)
        {
            this.Id = id;
            this.Date = date;
            this.Balance = solde;
            this.Input = input;
            this.Output = output;
        }
    }
}