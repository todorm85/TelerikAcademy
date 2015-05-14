using System;
using System.Collections.Generic;
using System.IO;

class UntitledClass
{
    static char[] WordSymbolsArr()
    {
        char[] letters = new char[63];
        for (int i = 0; i < 10; i++)
        {
            letters[i] = (char)(48 + i);
        }

        int asciiIndex = 0;
        for (int i = 0; i < 52; i += 2)
        {
            letters[10 + i] = (char)(65 + asciiIndex);
            letters[10 + i + 1] = (char)(97 + asciiIndex);
            asciiIndex++;
        }

        letters[62] = '_';

        return letters;
    }

    static char[] PunctuationArr()
    {
        List<char> punctuationList = new List<char>();
        for (int i = 0; i < 128; i++)
        {
            if (Char.IsPunctuation((char)i)) //|| Char.IsSeparator((char)i))
            {
                punctuationList.Add((char)i);
            }
        }

        punctuationList.Remove('_');

        char[] punctuation = new char[punctuationList.Count];
        for (int i = 0; i < punctuationList.Count; i++)
        {
            punctuation[i] = punctuationList[i];
        }

        return punctuation;
    }

    static bool IsWord(string input)
    {
        char[] wordSymbols = WordSymbolsArr();
        bool isWord;
        if (input == "" || input == null)
        {
            return false;
        }

        input = RemovePunctuation(input);

        string[] removedWordSymbols = input.Split(wordSymbols, StringSplitOptions.RemoveEmptyEntries);

        if (removedWordSymbols.Length == 0)
        {
            isWord = true;
        }

        else
        {
            isWord = false;
        }

        return isWord;
    }

    static string RemovePunctuation(string input)
    {
        char[] punctuation = PunctuationArr();

        for (int i = 0; i < punctuation.Length; i++)
        {
            if (input[0] == punctuation[i])
            {
                input = input.Remove(0, 1);
                break;
            }
        }

        for (int i = 0; i < punctuation.Length; i++)
        {
            if (input[input.Length - 1] == punctuation[i])
            {
                input = input.Remove(input.Length - 1, 1);
                break;
            }
        }

        return input;
    }

   static void Main()
    {
        List<string> filtherWords = new List<string>();
        using (StreamReader source = new StreamReader(@"..\..\filther.txt"))
        {
            string currentLine = source.ReadLine();
            while (currentLine != null)
            {
                if (!IsWord(currentLine))
                {
                    throw new Exception("Invalid filther word found! Possible empty line in filther words source file.");
                }

                filtherWords.Add(currentLine);
                currentLine = source.ReadLine();
            }
        }
    }
}

