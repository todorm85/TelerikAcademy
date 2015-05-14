using System;
using System.Collections.Generic;
using System.Text;
//Problem 8. Extract sentences• Write a program that extracts from a given text all sentences containing given word.

//Example:

//The word is: in

//The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

//Consider that the sentences are separated by  .  and the words – by non-letter symbols.

class Program
{
    static void Main()
    {
        // your input here !!!!!!!!!!!!!!!!!!!
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";

        List<string> sentences = ExtractSentences(text);
        RemoveSentencesWithWord(sentences, word);
        string resultText = ConvertListToString(sentences);
        Console.WriteLine(resultText);
    }

    private static List<string> ExtractSentences(string text)
    {
        List<string> sentences = new List<string>();
        while (true)
        {
            bool isFinished = false;
            int dotIndex = text.IndexOf(".");
            while (true)
            {
                if (dotIndex == text.Length - 1)
                {
                    isFinished = true;  // flag that we have reached last sentence
                    break;
                }

                    // if it is not the end dot of a sentence: next word is not with capital letter
                else if (text[dotIndex + 1] != ' ' || char.IsLower(text[dotIndex + 2]))
                {
                    dotIndex = text.IndexOf(".", dotIndex + 1); // leave this dot and get the index of the next dot
                    continue;
                }

                else
                {
                    break;
                }
            }

            // after we got the index of the end sentence dot of remaining text
            sentences.Add(text.Substring(0, dotIndex + 1));
            // if we have reached the last sentence stop cycle
            if (isFinished) break;
            // if not last sentence remove it and continue extracting from remaining text
            text = text.Substring(dotIndex + 1);
        }

        return sentences;
    }

    private static void RemoveSentencesWithWord(List<string> sentences, string word)
    {
        string wordAtStart = char.ToUpper(word[0]) + word.Substring(1) + " "; // the word as is in beginning of sentence
        string wordAtMid = " " + word + " ";    // the word as is in middle
        string wordAtEnd = " " + word + ".";    // the word at the end

        for (int i = 0; i < sentences.Count; i++)
        {
            if (sentences[i].Contains(wordAtMid) || sentences[i].Contains(wordAtEnd) || sentences[i].Contains(wordAtStart))
            {
                continue;
            }

            else
            {
                sentences.RemoveAt(i);
                i--;
            }
        }
    }

    private static string ConvertListToString(List<string> text)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var item in text)
        {
            builder.Append(item);
        }

        return builder.ToString();
    }
}
