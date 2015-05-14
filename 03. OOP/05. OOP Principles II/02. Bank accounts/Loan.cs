using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_accounts
{
    class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal monthInterest)
            : base(customer, balance, monthInterest)
        { }

        public override decimal CalcInterestAmount(decimal months)
        {  
            if (this.Customer is Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }

                return base.CalcInterestAmount(months - 3);
            }

            if (this.Customer is Company)
            {
                if (months <= 2)
                {
                    return 0;
                }

                return base.CalcInterestAmount(months - 2);
            }

            throw new ArgumentException("Invalid customer type. Should be either Individula or Company");
        }
    }
}
