using System;
using System.IO;
using System.Net;
using System.Reflection;
//### Problem 4. Download file
//*	Write a program that downloads a file from Internet (e.g. [Ninja image](http://telerikacademy.com/Content/Images/news-img01.png)) and stores it the current directory.
//*	Find in Google how to download files in C#.
//*	Be sure to catch all exceptions and to free any used resources in the finally block.
class Program
{
    public static string downloadPath = "";
    public static string fileName = "";

    static void Main()
    {
        // input values are here
        string remoteUri = "http://telerikacademy.com/Content/Images/";
        fileName = "news-img01.png";
        downloadPath = @"C:\Temp\";

        string myStringWebResource = null;
        WebClient myWebClient = new WebClient();
        myStringWebResource = remoteUri + fileName;
        Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
        try
        {
            if (!Directory.Exists(downloadPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(downloadPath);
            }
        }

        catch (Exception)
        {
            throw new Exception("Invalid Download path! Download path not found or unable to create directory.");
        }

        try
        {
            myWebClient.DownloadFile(myStringWebResource, String.Format(@"{0}{1}", downloadPath, fileName));
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + downloadPath);
        }

        catch (WebException)
        {
            throw new WebException("Problems connecting to server. Please check yoour connection and/or firewall");
        }

        catch (ArgumentNullException)
        {
            throw new ArgumentNullException("You must enter both filename and web resource. Neither can be empty.");
        }

        finally
        {
            Console.WriteLine("\nDeleting any temporarily created files.");
            if (File.Exists(String.Format(@"{0}{1}", downloadPath, fileName)))
            {
                try
                {
                    File.Delete(String.Format(@"{0}{1}", downloadPath, fileName));
                }
                catch (Exception e)
                {
                    throw new Exception(String.Format("Problems with cleaning up temporary files in {1}!\n{0}", e, downloadPath));
                }
            }
        }
    }
}

