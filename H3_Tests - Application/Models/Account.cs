using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Models
{
    public class Account : Entity
    {
        public string Number { get; set; }
        public double Balance { get; set; }

        public Account(string number)
        {
            Number = number;
        }

        public double Deposit(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException("Cannot deposit less than 0 money", nameof(amount));
            }

            Balance += amount; // Add balance

            return Balance; // New balance
        }


    }
}
