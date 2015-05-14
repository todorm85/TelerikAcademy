using System;
using System.Text;
//### Problem 25. Extract text from HTML
//*	Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags.
class Program
{
    static void Main()
    {
        string htmlText = "<html><head><title>News</title></head><body><p><a href=\"http://academy.telerik.com\">TelerikAcademy</a>aims to provide free real-world practical training for young people who want to turn into skilful .NET software engineers.</p></body>	</html>";
        string title = "";

        if (htmlText.Contains("<title>"))
        {
            int start = htmlText.IndexOf("<title>") + 7;
            int end = htmlText.IndexOf("</title>");
            title = htmlText.Substring(start, end - start);
            htmlText = htmlText.Substring(end + 8);
        }

        // insert spaces outside of hyperlink tags
        while (htmlText.Contains("</a>"))
        {
            htmlText = htmlText.Replace("<a", " <x");
            htmlText = htmlText.Replace("a>", "x> ");
        }

        // remove all tags
        StringBuilder sb = new StringBuilder();
        sb.Append(htmlText);
        while (sb.ToString().Contains("<") || sb.ToString().Contains(">"))
        {
            int start = sb.ToString().IndexOf("<");
            int end = sb.ToString().IndexOf(">");
            sb.Remove(start, end - start + 1);
        }

        string text = sb.ToString().Trim();
        if (title!="")
        {
            Console.WriteLine(title);
        }

        Console.WriteLine(text);
    }
}

