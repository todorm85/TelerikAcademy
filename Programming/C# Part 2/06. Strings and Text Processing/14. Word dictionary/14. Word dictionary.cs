using System;
//### Problem 14. Word dictionary
//*	A dictionary is stored as a sequence of text lines containing words and their explanations.
//*	Write a program that enters a word and translates it by using the dictionary.

//_Sample dictionary:_

//|   input   |                  output                  |
//|:---------:|:----------------------------------------:|
//| .NET      | platform for applications from Microsoft |
//| CLR       | managed execution environment for .NET   |
//| namespace | hierarchical organization of classes     |
class Program
{
    static void Main()
    {
        string[] dic = 
        {
            ".NET - platform for applications from Microsoft",
            "CLR - managed execution environment for .NET",
            "namespace - hierarchical organization of classes"
        };

        Console.Write("Enter search word: ");
        string searchWord = Console.ReadLine();
        searchWord = searchWord.ToLower();
        int index = -1;
        for (int i = 0; i < dic.Length; i++)
        {
            string firstWord = dic[i].Substring(0, dic[i].IndexOf(" - "));
            firstWord = firstWord.ToLower();
            if (searchWord==firstWord)
            {
                index = i;
                break;
            }
        }

        if (index >= 0)
        {
            Console.WriteLine(dic[index]);
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }
}

