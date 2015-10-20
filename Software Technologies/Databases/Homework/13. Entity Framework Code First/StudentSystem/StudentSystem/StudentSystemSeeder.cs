namespace StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public class StudentSystemSeeder
    {
        private StudentSystemDb db = new StudentSystemDb();
        private IRandomGenerator randomGenerator;
        public StudentSystemSeeder(IRandomGenerator rand)
        {
            this.randomGenerator = rand;
        }

        public void SeedStudents(int studentsCount)
        {
            for (int i = 0; i < studentsCount; i++)
            {
                var student = new Student()
                {
                    FacultyNumber = randomGenerator.GetRandomString(),
                    Name = randomGenerator.GetRandomString()
                };

                db.Students.Add(student);

                if (db.ChangeTracker.Entries<Student>().Count() > 1000)
                {
                    ResetDb();
                }
            }

            ResetDb();
        }

        public void SeedCourses(int coursesCount)
        {
            for (int i = 0; i < coursesCount; i++)
            {
                var course = new Course()
                {
                    Description = randomGenerator.GetRandomString(),
                    Name = randomGenerator.GetRandomString()
                };

                db.Courses.Add(course);

                if (db.ChangeTracker.Entries<Course>().Count() > 1000)
                {
                    ResetDb();
                }
            }

            ResetDb();
        }

        public void SeedHomeworks(int homeworksCount)
        {
            for (int i = 0; i < homeworksCount; i++)
            {
                int year = randomGenerator.GetRandomInteger(1997, 2015);
                int month = randomGenerator.GetRandomInteger(1, 12);
                int day = randomGenerator.GetRandomInteger(1, 28);

                var hw = new Homework()
                {
                    Content = randomGenerator.GetRandomString(),
                    TimeSent = new DateTime(year, month, day)
                };

                db.Homeworks.Add(hw);

                if (db.ChangeTracker.Entries<Homework>().Count() > 1000)
                {
                    ResetDb();
                }
            }

            ResetDb();
        }

        public void SeedStudentCourses()
        {
            int courseCount = db.Courses.Count();
            if (courseCount <= 2)
            {
                return;
            }

            var studentCount = db.Students.Count();
            for (int i = 1; i <= studentCount; i++)
            {
                var student = db.Students.First(c => c.Id == i);

                var coursesCount = randomGenerator.GetRandomInteger(1, 5);
                for (int j = 0; j < coursesCount; j++)
                {
                    var randCourseId = randomGenerator.GetRandomInteger(1, courseCount);
                    var course = db.Courses.First(c => c.Id == randCourseId);

                    student.Courses.Add(course);
                }
            }

            db.SaveChanges();
        }

        public void SeedStudentHomeworks()
        {
            var studentCount = db.Students.Count();
            for (int i = 1; i <= studentCount; i++)
            {

                var randomHwId = randomGenerator.GetRandomInteger(1, db.Homeworks.Count());
                var hw = db.Homeworks.First(c => c.Id == randomHwId);

                var student = db.Students.First(c => c.Id == i);
                student.Homework = hw;

                if (db.ChangeTracker.Entries().Count() > 1000)
                {
                    ResetDb();
                }
            }

            ResetDb();
        }

        private void ResetDb()
        {
            db.SaveChanges();
            db = new StudentSystemDb();
        }

    }
}
