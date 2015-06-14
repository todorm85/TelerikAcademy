using System;
using System.Collections.Generic;
//### Problem 18. Extract e-mails
//*	Write a program for extracting all email addresses from given text.
//*	All sub-strings that match the format <identifier>@<host>�<domain> should be recognized as emails.
class Program
{
    static void Main()
    {
        string txt = "This is our mail: hello@abv.bg. Please use it instead of office@abv.bg, since it is our old one. This is fake mail: com.yahoo@office";
        string[] words = txt.Split(' ', ',');
        List<string> mails = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            // finds all words that contain '@'
            if (words[i].Contains("@"))
            {
                // take care of trailing '.' if current word was at the end of sentence
                if (words[i][words[i].Length - 1] == '.')
                {
                    words[i] = words[i].Substring(0, words[i].Length - 1);
                }

                // check that current word is mail
                if (words[i].Contains("."))
                {
                    if (words[i].IndexOf('@') < words[i].IndexOf('.'))
                    {
                        mails.Add(words[i]);
                    }
                }
            }
        }

        foreach (var item in mails)
        {
            Console.WriteLine(item);
        }
    }
}

