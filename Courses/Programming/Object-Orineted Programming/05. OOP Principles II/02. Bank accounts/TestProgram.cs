using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_accounts
{
    class TestProgram
    {
        static void Main()
        {
            // loan tests
            "Test1: Loan account".PrintDelimiter();
            Console.WriteLine("\nCreating individual loan account with 1500 deposit and 25 month interest...\n");
            Customer lili = new Individual("Lili");
            Account liliLoanAcc = new Loan(lili, 1500, 25);

            int months = 5;
            Console.WriteLine("Expected interest for {0} months: 750", months);
            Console.WriteLine("Returned: {0}", liliLoanAcc.CalcInterestAmount(months));

            months = 3;
            Console.WriteLine("Expected interest for {0} months: 0", months);
            Console.WriteLine("Returned: {0}", liliLoanAcc.CalcInterestAmount(months));


            Console.WriteLine("\nCreating company loan account with 500 deposit and 50 month interest...\n");
            Customer gbs = new Company("GlavBulgarStroi");
            Account GBSLoanAccount = new Loan(gbs, 500, 50);

            months = 3;
            Console.WriteLine("Expected interest for {0} months: 250", months);
            Console.WriteLine("Returned: {0}", GBSLoanAccount.CalcInterestAmount(months));

            months = 5;
            Console.WriteLine("Expected interest for {0} months: 750", months);
            Console.WriteLine("Returned: {0}", GBSLoanAccount.CalcInterestAmount(months));





            // deposits tests
            "Test2: Deposit account".PrintDelimiter();
            Console.WriteLine("Creating individual deposit account with 500 deposit and 20 month interest...\n");
            Account liliDeposit = new Deposit(lili, 500, 20);

            months = 8;
            Console.WriteLine("Expected interest for {0} months: 0", months);
            Console.WriteLine("Returned: {0}", liliDeposit.CalcInterestAmount(months));

            Console.WriteLine("\nDepositing 700 to individual`s Deposit account...\n");
            liliDeposit.Deposit(700);

            Console.WriteLine("Expected deposit balance: 1200" );
            Console.WriteLine("Returned: {0}", liliDeposit.Balance);

            Console.WriteLine("Expected interest for {0} months: 1920", months);
            Console.WriteLine("Returned: {0}", liliDeposit.CalcInterestAmount(months));


            Console.WriteLine("\nCreating company deposit account with 1500 deposit and 20 month interest...\n");
            Deposit gbsDeposit = new Deposit(gbs, 1500, 20);

            months = 8;
            Console.WriteLine("Expected interest for {0} months: 2400", months);
            Console.WriteLine("Returned: {0}", gbsDeposit.CalcInterestAmount(months));

            Console.WriteLine("\nWithdrawing 700 from company deposit...\n");
            gbsDeposit.Withdraw(700);

            Console.WriteLine("Expected deposit balance: 800");
            Console.WriteLine("Returned: {0}", gbsDeposit.Balance);

            months = 8;
            Console.WriteLine("Expected interest for {0} months: 0", months);
            Console.WriteLine("Returned: {0}", gbsDeposit.CalcInterestAmount(months));




            // mortgage tests
            "Test3: Mortgage account".PrintDelimiter();
            Console.WriteLine("Creating individual mortgage account with 500 deposit and 20 month interest...\n");
            Account liliMortgage = new Mortgage(lili, 500, 20);

            months = 8;
            Console.WriteLine("Expected interest for {0} months: 200", months);
            Console.WriteLine("Returned: {0}", liliMortgage.CalcInterestAmount(months));

            months = 5;
            Console.WriteLine("Expected interest for {0} months: 0", months);
            Console.WriteLine("Returned: {0}", liliMortgage.CalcInterestAmount(months));

            Console.WriteLine("\nCreating company mortgage account with 1500 deposit and 30 month interest...\n");
            Account gbsMortgage = new Mortgage(gbs, 1500, 30);

            months = 8;
            Console.WriteLine("Expected interest for {0} months: 1800", months);
            Console.WriteLine("Returned: {0}", gbsMortgage.CalcInterestAmount(months));

            months = 13;
            Console.WriteLine("Expected interest for {0} months: 3150", months);
            Console.WriteLine("Returned: {0}", gbsMortgage.CalcInterestAmount(months));
        }
    }
}
