using System;

namespace Part3.BusinessLogic
{
    internal class Operation
    {
        public int Id { get; set; }
        public string Type { get; }
        public DateTime Date { get; set; }
        public double Balance { get; set; }
        public int Age { get; }
        public int Input { get; set; }
        public int Output { get; set; }

        public Operation(int id, string type, DateTime date, double balance, int age, int input, int output)
        {
            Id = id;
            Type = type;
            Date = date;
            Balance = balance;
            Age = age;
            Input = input;
            Output = output;
        }
    }
}