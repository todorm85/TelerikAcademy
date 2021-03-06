﻿using System;

////Problem 12. Parse URL• Write a program that parses an URL address given in the format:  [protocol]://[server]/[resource]  and extracts from it the  [protocol] ,  [server]  and  [resource]  elements.

//Example: 

// http://telerikacademy.com/Courses/Courses/Details/212  
//[protocol] =  http  
// [server] =  telerikacademy.com  
// [resource] =  /Courses/Courses/Details/212   

class Program
{
    static void Main()
    {
        string url = "http://telerikacademy.com/Courses/Courses/Details/212";
        string protocol = url.Substring(0, url.IndexOf("://"));
        url = url.Substring(url.IndexOf("://")+3);
        string server = url.Substring(0, url.IndexOf("/"));
        string resource = url.Substring(url.IndexOf("/"));
        Console.WriteLine("[protocol] = {0}\n[server] = {1}\n[resource] = {2}", protocol, server, resource);
    }


}
