using System;

//Problem 11. Bank Account Data
//• A bank account has a holder name (first name, middle name and last name), available 
//amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
//• Declare the variables needed to keep the information for a single bank 
//account using the appropriate data types and descriptive names.

class BankAccountData
{
    static void Main()
    {
        string firstName = "";
        string middleName = "";
        string lastName = "";
        //ok, so for the names we use string because they are just an array of characters
        decimal balance = 0;
        //we use decimal for the account balance because it is required for financial
        //calculations due to its accuracy when working with decimal numbers
        string bankName = "";
        //the bank name is just another array of characters so string is used
        string IBAN = "";
        string card1 = "";
        string card2 = "";
        string card3 = "";
        //the iban and credit card numbers are also defined as array of characters
        //because they probably won`t participate in any calculations

    }
}

