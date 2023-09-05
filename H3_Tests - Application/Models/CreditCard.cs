using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Models
{
    public class CreditCard : Entity
    {
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string AccountNumber { get; set; }
        public bool IsOverchangeAble { get; set;}

        public CreditCard(string cardNumber, string cardHolderName, string accountNumber, bool isOverchangeAble)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            AccountNumber = accountNumber;
            IsOverchangeAble = isOverchangeAble;
        }
    }
}