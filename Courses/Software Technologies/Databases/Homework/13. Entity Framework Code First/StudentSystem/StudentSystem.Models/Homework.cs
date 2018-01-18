using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentSystem.Models
{
    public class Homework
    {
        public Homework()
        {
            this.students = new HashSet<Student>();
            this.courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [MaxLength(100)]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        private ICollection<Student> students;

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        private ICollection<Course> courses;

        public virtual ICollection<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }
        
    }
}