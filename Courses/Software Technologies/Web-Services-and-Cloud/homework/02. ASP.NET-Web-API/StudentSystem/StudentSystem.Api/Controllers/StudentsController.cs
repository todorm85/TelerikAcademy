namespace StudentSystem.Api.Controllers
{
    using System.Web.Http;
    using StudentSystem.Services.Data;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using StudentSystem.Api.Models;
    using StudentSystem.Models;
    using System.ComponentModel.DataAnnotations;

    public class StudentsController : ApiController
    {
        private IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        public IHttpActionResult GetAllStudents()
        {
            var allStudents = this.studentsService
                .All()
                .ProjectTo<StudentViewModel>()
                .ToList();

            return this.Ok(allStudents);
        }

        public IHttpActionResult GetStudent(int id)
        {
            if (!this.studentsService.IsFound(id))
            {
                return this.BadRequest("Student not found.");
            }

            var student = this.studentsService.All().Where(s => s.StudentIdentification == id).ProjectTo<StudentViewModel>().FirstOrDefault();

            return this.Ok(student);
        }

        [HttpPost]
        public IHttpActionResult CreateStudent(StudentBindingModel newStudentModel)
        {
            if (newStudentModel == null)
            {
                return this.BadRequest("Invalid student data. No data received.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid student data.");
            }

            var newStudent = Mapper.Map<Student>(newStudentModel);

            int createdStudentId = this.studentsService.Add(newStudent);

            return this.Ok(createdStudentId);
        }

        public IHttpActionResult DeleteStudent(int id)
        {
            if (!studentsService.IsFound(id))
            {
                return this.BadRequest("No such student.");
            }

            this.studentsService.Delete(id);

            return this.Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentBindingModel studentModel)
        {
            if (studentModel == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid student data.");
            }

            if (!this.studentsService.IsFound(id))
            {
                return this.BadRequest("No such student.");
            }

            studentsService.Update(id, studentModel.FirstName, studentModel.LastName, studentModel.Level);

            return this.Ok();
        }
    }
}