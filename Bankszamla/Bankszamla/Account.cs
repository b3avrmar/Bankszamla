using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankszamla
{
    internal class Account
    {
        private string accountNumber;
        private string ownerName;
        private decimal balance;
        private decimal creditLimit;

        private List<string> logs = new List<string>();

        public Account(string accountNumber, string ownerName, decimal openingBalance)
        {
            this.accountNumber = accountNumber;
            this.ownerName = ownerName;
            this.balance = openingBalance;
            this.creditLimit = openingBalance * 0.2m;
        }

    }
}
