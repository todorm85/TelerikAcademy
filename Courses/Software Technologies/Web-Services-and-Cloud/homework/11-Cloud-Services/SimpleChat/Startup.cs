namespace SimpleConsoleChat
{
    using System;
    using System.Threading;
    using IronMQ;
    using IronMQ.Data;

    /// <summary>
    /// Simple chat application for two persons at a time using IronMQ. Run it several
    /// times and send messages with different usernames. Wait a few seconds to receive
    /// messages sent with other usernames.
    /// </summary>
    internal class Startup
    {
        private static string name;

        private static void Main()
        {
            GetUserInfo();
            PrintInstructions();
            StartChat();
        }

        private static void StartChat()
        {
            Queue queue = GetChatQueue();

            while (true)
            {
                ReceiveMessage(queue);
                SendMessage(queue);

                //Thread.Sleep(100);
            }
        }

        private static void GetUserInfo()
        {
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Press 's' to send a message.");
        }

        private static void ReceiveMessage(Queue queue)
        {
            Message msg = queue.Get();
            if (msg != null)
            {
                if (!msg.Body.StartsWith(name))
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }
            }
        }

        private static Queue GetChatQueue()
        {
            Client client = new Client(
                        "564191224aa03100070000c9",
                        "SI9mlvuSEQqy6o7W5vip4SFNfx0");
            Queue queue = client.Queue("MySimpleChat");
            return queue;
        }

        private static void SendMessage(Queue queue)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Please enter your message:");
                    string outMsg = Console.ReadLine();
                    queue.Push(String.Format("{0} : {1}", name, outMsg));
                    Console.WriteLine("Message sent.");
                }
            }
        }
    }
}