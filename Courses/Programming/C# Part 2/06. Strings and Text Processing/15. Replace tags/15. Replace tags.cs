using System;
//### Problem 15. Replace tags
//*	Write a program that replaces in a HTML document given as string all the tags `<a href="�">�</a>` with corresponding tags `[URL=�]�/URL]`.

//_Example:_

//| input | output |
//|:-----:|:------:|
//| `<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>` | `<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>` |
class Program
{
    static void Main()
    {
        string html = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string html1 = "<a href=\"";
        string html2 = @""">";
        string html3 = "</a>";
        string url1 = "[URL=";
        string url2 = "]";
        string url3 = "[/URL]";

        while (html.Contains(html1))
            html = html.Replace(html1, url1);
        while (html.Contains(html2))
            html = html.Replace(html2, url2);
        while (html.Contains(html3))
            html = html.Replace(html3, url3);

        Console.WriteLine(html);
    }
}

