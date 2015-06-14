using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_accounts
{
    class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal monthInterest)
            : base(customer, balance, monthInterest)
        { }

        public override decimal CalcInterestAmount(decimal months)
        {
            if (this.Customer is Individual)
            {
                if (months <=6)
                {
                    return 0;
                }

                return base.CalcInterestAmount(months - 6);
            }

            if (this.Customer is Company)
            {
                if (months <= 12)
                {
                    return base.CalcInterestAmount(months / 2);
                }

                return base.CalcInterestAmount(months - 6);                
            }

            throw new ArgumentException("Invalid customer type. Should be either Individula or Company");
        }
    }
}
