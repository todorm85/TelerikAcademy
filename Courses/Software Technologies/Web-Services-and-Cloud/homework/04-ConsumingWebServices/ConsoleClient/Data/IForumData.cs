﻿namespace ConsoleClient
{
    using System.Collections.Generic;

    public interface IForumData
    {
        IEnumerable<string> GetPosts(string searchKey);
    }
}