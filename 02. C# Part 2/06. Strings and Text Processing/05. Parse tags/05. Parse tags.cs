using System;
//### Problem 05. Parse tags
//*	You are given a text. Write a program that changes the text in all regions surrounded by the tags `<upcase>` and `</upcase>` to upper-case.
//*	The tags cannot be nested.
class Program
{
    static void Main()
    {
        string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
        string startFlag = "<upcase>";
        string endFlag = "</upcase>";

        int startIndex = 0;
        int endIndex = 0;
        string result = "";
        while (true)
        {
            startIndex = text.IndexOf(startFlag);
            if (startIndex < 0)
            {
                result += text;
                break;
            }

            else
            {
                result += text.Substring(0, startIndex);
                text = text.Substring(startIndex + startFlag.Length);
                endIndex = text.IndexOf(endFlag);
                result += text.Substring(0, endIndex).ToUpper();
                text = text.Substring(endIndex + endFlag.Length);
            }
        }

        Console.WriteLine(result);
    }
}

