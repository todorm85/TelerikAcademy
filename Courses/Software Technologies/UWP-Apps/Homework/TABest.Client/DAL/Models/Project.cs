namespace TABest.Client.DAL.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string MainImageUrl { get; set; }

        public string ShortDate { get; set; }

        public int Likes { get; set; }
    }
}