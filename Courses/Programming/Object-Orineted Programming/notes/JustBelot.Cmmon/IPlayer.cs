using System;

namespace JustBelot.Common
{
    public interface IPlayer
    {
        string Name { get; }
        int Points { get; }
        void PlayCard();
    }
}