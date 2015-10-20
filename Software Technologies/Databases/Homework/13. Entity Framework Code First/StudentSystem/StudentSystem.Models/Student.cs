namespace StudentSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> courses;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string FacultyNumber { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public virtual Homework Homework { get; set; }
    }
}