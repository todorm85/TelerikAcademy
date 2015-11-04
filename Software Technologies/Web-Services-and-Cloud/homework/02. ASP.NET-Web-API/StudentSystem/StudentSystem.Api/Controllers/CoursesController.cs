namespace StudentSystem.Api.Controllers
{
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using StudentSystem.Api.Models;
    using StudentSystem.Data;
    using System.Linq;
    using AutoMapper;
    using StudentSystem.Models;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var allCoursesView = this.data.Courses.All().ProjectTo<CourseModel>();

            return this.Ok(allCoursesView);
        }

        public IHttpActionResult Get(string id)
        {
            var allCoursesView = this.data.Courses
                .All()
                .Where(c => c.Name == id)
                .ProjectTo<CourseModel>()
                .FirstOrDefault();

            if (allCoursesView == null)
            {
                return this.BadRequest("No such course.");
            }

            return this.Ok(allCoursesView);
        }

        public IHttpActionResult Post(CourseModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No model data received.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var newCourse = Mapper.Map<Course>(model);

            data.Courses.Add(newCourse);
            data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(string id)
        {
            var course = this.data.Courses.All().Where(c => c.Name == id).FirstOrDefault();
            if (course == null)
            {
                return this.BadRequest("Course not found");
            }

            this.data.Courses.Delete(course);
            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Put(CourseModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var course = this.data.Courses.All().Where(c => c.Name == model.Name).FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Course not found");
            }

            course.Description = model.Description;
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}