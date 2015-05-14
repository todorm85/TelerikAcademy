using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_accounts
{
    class Deposit : Account, IWithdrawable
    {
        public Deposit(Customer customer, decimal balance, decimal monthInterest)
            : base(customer, balance, monthInterest)
        { }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdraw amount must be positive!");
            }

            if (amount > this.Balance)
            {
                throw new ArgumentException("Not enough money in account balance!");
            }

            this.Balance -= amount;
        }

        public override decimal CalcInterestAmount(decimal months)
        {
            if (this.Balance < 1000 && this.Balance > 0)
            {
                return 0;
            }

            return base.CalcInterestAmount(months);
        }
    }
}
