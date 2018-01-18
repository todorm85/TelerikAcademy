namespace StudentSystem.Data
{
    using System.Data.Entity;
    using StudentSystem.Models;

    public class StudentSystemDb : DbContext
    {
        public StudentSystemDb()
            : base("StudentSystemDb")
        {
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }
    }
}