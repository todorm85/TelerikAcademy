using System;

//Problem 2. Print Company Information
//• A company has name, address, phone number, fax number, web site and manager. 
//The manager has first name, last name, age and a phone number.
//• Write a program that reads the information about a company and its manager
//and prints it back on the console.

//Example input:
//program                     user
//Company name:               Telerik Academy 
//Company address:            31 Al. Malinov, Sofia 
//Phone number:               +359 888 55 55 555 
//Fax number:                 2 
//Web site:                   http://telerikacademy.com/ 
//Manager first name:         Nikolay 
//Manager last name:          Kostov 
//Manager age:                25 
//Manager phone:              +359 2 981 981 

//Example output:
//Telerik Academy
//Address: 231 Al. Malinov, Sofia
//Tel. +359 888 55 55 555
//Fax: (no fax)
//Web site: http://telerikacademy.com/
//Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981) 

class Print_Company_Information
{
    static void Main()
    {
        Console.Write("Enter company name: ");
        string company = Console.ReadLine();
        Console.Write("Enter company address: ");
        string address = Console.ReadLine();
        Console.Write("Enter company phone: ");
        string phone = Console.ReadLine();
        Console.Write("Enter company fax: ");
        string fax = Console.ReadLine();
        Console.Write("Enter company web: ");
        string web = Console.ReadLine();
        Console.Write("Enter manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter manager age: ");
        string managerAge = Console.ReadLine();
        Console.Write("Enter manager phone: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine(company);
        Console.WriteLine("address: " + address);
        Console.WriteLine("phone: " + phone);
        Console.WriteLine("fax: " + fax);
        Console.WriteLine("web: " + web);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", managerFirstName, managerLastName, managerAge, managerPhone);
    }
}

