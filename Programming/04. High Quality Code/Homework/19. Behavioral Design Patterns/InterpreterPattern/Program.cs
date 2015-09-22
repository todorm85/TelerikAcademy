using System;

namespace InterpreterPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* The forum and its posts and their posts and so on is our syntax tree.
             * Syntax tree consists of expressions which are used to interpret data in certain context.
             * Forum and Post are all implementing the IExpression.
             * Context is the context at which each expression is interpreted.
             * Its depth property is needed for the proper interpretation of each post node.
             * The interpreted result is also saved in the output property of context.
             * Here the syntax tree is constructed manually by the client.
             * In real world it is constructed with the help of a parser.
             */
            var forum = new Forum();

            var post1 = new Post("Post 1 message.");
            var post11 = new Post("Post 1 reply 1 message");
            var post12 = new Post("Post 1 reply 2 message");
            var post121 = new Post("Post 1 reply 2 repy 1 message");
            post12.AddReply(post121);
            post1.AddReply(post11);
            post1.AddReply(post12);

            forum.AddPost(post1);

            var post2 = new Post("Post 2 message.");
            var post21 = new Post("Post 2 reply 1 message.");
            post2.AddReply(post21);

            forum.AddPost(post2);

            var ctx = new Context();
            forum.Interpret(ctx);

            Console.WriteLine(ctx.Output);
        }
    }
}