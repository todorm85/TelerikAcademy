namespace StudentSystem.Services.Data
{
    using System.Linq;
    using StudentSystem.Models;

    public interface IStudentsService
    {
        IQueryable<Student> All();

        int Add(Student newStudent);

        void Delete(int studentId);

        bool IsFound(int studentId);

        void Update(int studentId, string firstName, string LastName, int level);
    }
}