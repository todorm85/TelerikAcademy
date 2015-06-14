using System;
//### Problem 3. Read file contents
//*	Write a program that enters file name along with its full file path (e.g. `C:\WINDOWS\win.ini`), reads its contents and prints it on the console.
//*	Find in MSDN how to use `System.IO.File.ReadAllText(�)`.
//*	Be sure to catch all possible exceptions and print user-friendly error messages.
class Program
{
    static void Main()
    {
        try
        {
            string path = "C:\\WINDOWS\\win.ini";
            string data = System.IO.File.ReadAllText(path);
            Console.WriteLine(data);
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Empty or wrong path!");
        }

        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("DirectoryNotFound");
        }

        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("PathTooLong");
        }

        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("FileNotFound");
        }

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The program has no permissions to read the file!");
        }

        catch (Exception ex)
        {
            Console.WriteLine("An unknown error occured!");
            throw ex;
        }
    }
}

