using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace School.Tests
{
    [TestClass]
    public class CourseTests
    {
        // name
        [TestMethod]
        public void CourseShouldReturnCorrectName()
        {
            var course = new Course("Maths");
            Assert.AreEqual("Maths", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowOnEmptyName()
        {
            var course = new Course("");
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CourseShouldThrowOnNullName()
        {
            var course = new Course(null);
            
        }

        //AddStudent
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowIfStudentsAreMoreThanMaxAllowed()
        {
            var course = new Course("Maths");
            for (int i = 0; i <= Course.MaxStudentsCount; i++)
			{
			    var student = new Student("unnamed", Student.MinValidId+i);
                student.JoinCourse(course);
			}
            
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowIfStudentAlreadyAdded()
        {
            var course = new Course("Maths");
			var student = new Student("unnamed", Student.MinValidId);
            student.JoinCourse(course);
            student.JoinCourse(course);
        }

        [TestMethod]
        public void CourseShouldAddStudent()
        {
            var course = new Course("Maths");
			var student = new Student("unnamed", Student.MinValidId);
            student.JoinCourse(course);
            Assert.AreEqual(1, course.Students.Count);
        }

        //Remove student
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowIfStudentToRemoveDoesNotExist()
        {
            var course = new Course("Maths");
            var student = new Student("unnamed", Student.MinValidId);
            student.LeaveCourse(course);
        }

        [TestMethod]
        public void CourseShouldRemoveStudent()
        {
            var course = new Course("Maths");
            var student = new Student("unnamed", Student.MinValidId);
            student.JoinCourse(course);
            Assert.AreEqual(1, course.Students.Count);
            student.LeaveCourse(course);
            Assert.AreEqual(0, course.Students.Count);
        }
    }
}
