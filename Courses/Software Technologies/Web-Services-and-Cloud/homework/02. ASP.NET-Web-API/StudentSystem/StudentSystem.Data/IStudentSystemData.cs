namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        StudentsRepository Students { get; }

        IGenericRepository<Homework> Homeworks { get; }

        void SaveChanges();
    }
}
