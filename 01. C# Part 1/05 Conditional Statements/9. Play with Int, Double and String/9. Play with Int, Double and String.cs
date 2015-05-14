using System;

//Problem 9. Play with Int, Double and String
//• Write a program that, depending on the user’s choice, inputs an  int ,  double
//or  string  variable. ◦ If the variable is  int  or  double , the program increases it by one.
//◦ If the variable is a  string , the program appends  *  at the end.
//• Print the result at the console. Use switch statement.

//Example 1:
//program                         user
//Please choose a type:  
//1 --> int  
//2 --> double                    3 
//3 --> string  

//Please enter a string:          hello 
//hello*  

//Example 2:
//program                         user
//Please choose a type:  
//1 --> int  
//2 --> double                    2 
//3 --> string  

//Please enter a double:          1.5 
//2.5 

class Play_with_Int_Double_and_String
{
    static void Main()
    {
        Console.Write("Please choose an input type:\n1-->int\n2-->double\n3-->string\nchoice: ");
        byte input = byte.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
                Console.Write("Please enter an integer: ");
                int input1 = int.Parse(Console.ReadLine());
                Console.WriteLine(input1+1);
                break;
            case 2:
                Console.Write("Please enter a floating point number: ");
                double input2 = double.Parse(Console.ReadLine());
                Console.WriteLine(input2+1);
                break;
            case 3:
                Console.Write("Please enter a string: ");
                string input3 = Console.ReadLine();
                Console.WriteLine(input3 + new string('*',1));
                break;
        }
    }
}

