namespace StudentSystem.ConsoleUI
{
    using System.Data.Entity;
    using StudentSystem.Models;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;

    public class Startup
    {
        private const int StudentsCount = 10;
        private const int HomeworksCount = 25;
        private const int CoursesCount = 15;

        public static void Main()
        {
            CreateNewDatabase();

            SeedDatabase();
        }

        private static void CreateNewDatabase()
        {
            var db = new StudentSystemDb();
            db.Database.Delete();
            db.Database.Create();
        }

        private static void SeedDatabase()
        {
            var rand = new RandomGenerator();
            var seeder = new StudentSystemSeeder(rand);

            seeder.SeedStudents(StudentsCount);
            seeder.SeedCourses(CoursesCount);
            seeder.SeedHomeworks(HomeworksCount);

            seeder.SeedStudentCourses();
            seeder.SeedStudentHomeworks();
        }
    }
}