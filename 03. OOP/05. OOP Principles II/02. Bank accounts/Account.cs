using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_accounts
{
    abstract class Account : IDepositable
    {
        private Customer customer;
        private decimal balance;
        private decimal monthInterest;

        protected Account(Customer customer, decimal balance, decimal monthInterest)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.MonthInterest = monthInterest;
        }

        public decimal MonthInterest
        {
            get { return monthInterest; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Month Interest must be positive.");
                }

                monthInterest = value;
            }
        }

        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance must be positive!");
                }

                balance = value;
            }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public virtual decimal CalcInterestAmount(decimal months)
        {
            if (months <= 0)
            {
                throw new ArgumentException("Months count cannot be 0 or negative");
            }

            return this.Balance * (this.MonthInterest / 100) * months;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit must be bigger than 0.");
            }

            this.Balance += amount;
        }
    }
}
