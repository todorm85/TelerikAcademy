using InterpreterPattern.Expressions;
using System.Collections.Generic;

namespace InterpreterPattern
{
    internal class Forum : IExpression
    {
        private IList<Post> posts;

        public Forum()
        {
            this.posts = new List<Post>();
        }
        public void AddPost(Post post)
        {
            this.posts.Add(post);
        }

        public void Interpret(Context ctx)
        {
            ctx.Output = "<--Forum start-->\n";

            foreach (var post in this.posts)
            {
                post.Interpret(ctx);
            }

            ctx.Output += "<--Forum end-->";
        }
    }
}