namespace SimpleConsoleChat
{
    using System;
    using System.Threading;

    /// <summary>
    /// Simple chat application for two persons at a time using PubNub.
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
            var chatRoom = "randomChannel101";
            var chatService = GetChatService();
            EnterChatroom(chatService, chatRoom);

            while (true)
            {
                SendMessage(chatService, chatRoom);
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

        private static void EnterChatroom(PubnubAPI pubnub, string chatRoom)
        {
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
            () =>
            pubnub.Subscribe(
                chatRoom,
                (object message) =>
                {
                    Console.WriteLine("Received Message -> " + message);
                    return true;
                }
            )
        );
            t.Start();
        }

        private static PubnubAPI GetChatService()
        {
            PubnubAPI pubnub = new PubnubAPI(
            "pub-c-25499a0d-31e9-468c-b4e4-e1940acb2e46",               // PUBLISH_KEY
            "sub-c-73f3014a-8793-11e5-8e17-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-NzBlZGI4OGYtZjkzNS00MjQ1LWI2NzItMTZlODNlOTdjNDEz",   // SECRET_KEY
            true                                                        // SSL_ON?
        );
            return pubnub;

        }

        private static void SendMessage(PubnubAPI chatService, string chatRoom)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Please enter your message:");
                    string outMsg = Console.ReadLine();
                    chatService.Publish(chatRoom, String.Format("{0} : {1}", name, outMsg));
                    Console.WriteLine("Message sent.");
                }
            }
        }
    }
}