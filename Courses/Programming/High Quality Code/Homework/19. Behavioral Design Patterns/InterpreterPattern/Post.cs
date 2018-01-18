using InterpreterPattern.Expressions;
using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
    internal class Post : IExpression
    {
        private List<Post> posts = new List<Post>();

        public Post(string msg)
        {
            this.Msg = msg;
        }

        public string Msg { get; private set; }

        public void Interpret(Context ctx)
        {
            ctx.Output += this.Msg + "\n";

            ctx.Depth++;
            foreach (var post in posts)
            {
                ctx.Output += new String(' ', ctx.Depth * 4);
                post.Interpret(ctx);
            }
            ctx.Depth--;
        }

        internal void AddReply(Post post)
        {
            this.posts.Add(post);
        }
    }
}