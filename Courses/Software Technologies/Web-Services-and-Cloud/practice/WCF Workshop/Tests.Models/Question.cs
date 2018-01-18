namespace Tests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Category Category { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }

    }
}
