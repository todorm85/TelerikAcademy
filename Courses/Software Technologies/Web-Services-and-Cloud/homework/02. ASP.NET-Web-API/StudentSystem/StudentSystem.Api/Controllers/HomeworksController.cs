using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using StudentSystem.Api.Models;
using StudentSystem.Data;
using StudentSystem.Models;
using AutoMapper.QueryableExtensions;

namespace StudentSystem.Api.Controllers
{
    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;
        public HomeworksController(IStudentSystemData data)
        {
            this.data = data;
        }

        public IHttpActionResult Get()
        {
            var allHomeworks = this.data.Homeworks.All()
                .ProjectTo<HomeworkModel>();

            return this.Ok(allHomeworks);
        }

        public IHttpActionResult Get(int id)
        {
            var homework = this.data.Homeworks.All().Where(h => h.Id == id).ProjectTo<HomeworkModel>().FirstOrDefault();

            if (homework == null)
            {
                return this.BadRequest("Homework id not found.");
            }

            return this.Ok(homework);
        }

        public IHttpActionResult Post(HomeworkModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data received.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid homework data.");
            }


            var courseId = this.data.Courses.All().Where(c => c.Name == model.CourseName).Select(x => x.Id).FirstOrDefault();

            if (courseId == null)
            {
                return this.BadRequest("Course not found.");
            }

            if (!this.data.Students.All().Any(s => s.StudentIdentification == model.StudentIdentification))
            {
                return this.BadRequest("Student not found.");
            }

            var homework = Mapper.Map<Homework>(model);

            homework.CourseId = courseId;

            this.data.Homeworks.Add(homework);

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Put(int id, HomeworkModel model)
        {
            if (model == null)
            {
                return this.BadRequest("No data received.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest("Invalid homework data.");
            }

            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return this.BadRequest("Homework not found.");
            }

            var courseId = this.data.Courses.All().Where(c => c.Name == model.CourseName).Select(x => x.Id).FirstOrDefault();

            if (courseId == null)
            {
                return this.BadRequest("Course not found.");
            }

            if (!this.data.Students.All().Any(s => s.StudentIdentification == model.StudentIdentification))
            {
                return this.BadRequest("Student not found.");
            }

            homework.FileUrl = model.FileUrl;
            homework.CourseId = courseId;
            homework.StudentIdentification = model.StudentIdentification;

            this.data.SaveChanges();

            return this.Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return this.BadRequest("Homework not found.");
            }

            this.data.Homeworks.Delete(homework);

            return this.Ok();
        }
    }
}
