using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Exceptions
{
    public class OverchargedException : Exception
    {
        public double OverchargedAmount { get; set; }
        public OverchargedException(string message, double overchargedAmount) : base(message)
        {
            OverchargedAmount = overchargedAmount;
        }
    }
}
