namespace StudentSystem.Services.Data
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Models;

    public class StudentsService : IStudentsService
    {
        private IStudentSystemData data;

        public StudentsService(IStudentSystemData data)
        {
            this.data = data;
        }

        public IQueryable<Student> All()
        {
            return this.data.Students.All();
        }

        public int Add(Student newStudent)
        {
            data.Students.Add(newStudent);
            data.SaveChanges();

            return newStudent.StudentIdentification;
        }

        public void Delete(int studentId)
        {
            var studentToDelete = data.Students.All().FirstOrDefault(s => s.StudentIdentification == studentId);

            if (studentToDelete == null)
            {
                throw new InvalidOperationException("No such student.");
            }

            data.Students.Delete(studentToDelete);
            data.SaveChanges();
        }

        public bool IsFound(int studentId)
        {
            return this.data.Students.All().Any(s => s.StudentIdentification == studentId);
        }

        public void Update(int studentId, string firstName, string LastName, int level)
        {
            var studentToUpdate = data.Students.All().FirstOrDefault(s => s.StudentIdentification == studentId);

            if (studentToUpdate == null)
            {
                throw new InvalidOperationException("No such student.");
            }

            studentToUpdate.FirstName = firstName;
            studentToUpdate.LastName = LastName;
            studentToUpdate.Level = level;

            data.Students.Update(studentToUpdate);
            data.SaveChanges();
        }
    }
}