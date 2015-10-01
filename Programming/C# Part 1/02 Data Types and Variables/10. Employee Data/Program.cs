using System;

//Problem 10. Employee Data
//A marketing company wants to keep record of its employees. Each record would have the following characteristics:
//• First name
//• Last name
//• Age (0...100)
//• Gender (m or f)
//• Personal ID number (e.g. 8306112507)
//• Unique employee number (27560000…27569999)

//Declare the variables needed to keep the information for a single employee using
//appropriate primitive data types. Use descriptive names. Print the data at the console.

class EmployeeData
{
    static void Main()
    {
        string firstName = "Pe6o";
        string lastName = "Pe6ov";
        byte age = 57;
        //byte has a range of 0 to 255, which is more than enough for age
        char gender = 't';
        string personalId = "12345";
        //personal ID probably will not be used for any calculations and it doesn`t have a limit
        //so string is most appropriate
        int uniqueId = 27560000;
        //unique ID is in the range of 27560000…27569999 so integer will suffize,
        //it is likely that it will be used for comparison or arrangment

        Console.WriteLine(firstName+" "+lastName);
        Console.WriteLine("age = "+age);
        Console.WriteLine("gender = "+gender);
        Console.WriteLine("personal ID = "+personalId);
        Console.WriteLine("unique ID = "+uniqueId);
    }
}

