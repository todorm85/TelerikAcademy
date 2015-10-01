using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace School.Tests
{
    [TestClass]
    public class SchoolTests
    {
        // school name
        [TestMethod]
        public void StudentGroupShouldReturnCorrectName()
        {
            var myClass = new StudentGroup("TelerikAcad");
            Assert.AreEqual("TelerikAcad", myClass.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentGroupShouldThrowOnEmptyName()
        {
            var myClass = new StudentGroup("");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentGroupShouldThrowOnNullName()
        {
            var myClass = new StudentGroup(null);
        }

        // add student
        [TestMethod]
        public void StudentGroupShouldAddStudent()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var student = new Student("Pe6o Ubaveca", Student.MinValidId);
            myClass.AddStudent(student);
            Assert.AreEqual(1, myClass.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentGroupShouldThrowOnNullStudentAdd()
        {
            var myClass = new StudentGroup("TelerikAcad");
            myClass.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StudentGroupShouldThrowIfStudentAlreadyAdded()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var student = new Student("Pe6o Ubaveca", Student.MinValidId);
            myClass.AddStudent(student);
            myClass.AddStudent(student);
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StudentGroupShouldThrowIfStudentWithSameIdAlreadyAdded()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var student = new Student("Pe6o Ubaveca", Student.MinValidId);
            var student2 = new Student("Pe6o Ubaveca2", Student.MinValidId);
            myClass.AddStudent(student);
            myClass.AddStudent(student2);
        }

        // remove student
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentGroupShouldThrowOnNullStudentRemove()
        {
            var myClass = new StudentGroup("TelerikAcad");
            myClass.RemoveStudent(null);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StudentGroupShouldThrowIfNoSuchStudentToRemove()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var student = new Student("Pe6o Ubaveca", Student.MinValidId);
            myClass.RemoveStudent(student);

        }

        [TestMethod]
        public void StudentGroupShouldRemoveStudent()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var student = new Student("Pe6o Ubaveca", Student.MinValidId);
            myClass.AddStudent(student);
            Assert.AreEqual(1, myClass.Students.Count);
            myClass.RemoveStudent(student);
            Assert.AreEqual(0, myClass.Students.Count);
        }

        // add course
        [TestMethod]
        public void StudentGroupShouldAddCourse()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var course = new Course("HQC");
            myClass.AddCourse(course);
            Assert.AreEqual(1, myClass.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentGroupShouldThrowOnNullCOurseAdd()
        {
            var myClass = new StudentGroup("TelerikAcad");
            myClass.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StudentGroupShouldThrowIfCourseIsAlreadyAdded()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var course = new Course("HQC");
            myClass.AddCourse(course);
            myClass.AddCourse(course);
        }

        [TestMethod]
        public void StudentGroupShouldAddOnlyNewNotAlreadyAddedStudentsFromNewCourseOnNewCourseAdd()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var newCourse = new Course("HQC");
            var existingStudent = new Student("Existing Guy", Student.MinValidId);
            var newStudent = new Student("New Guy", Student.MinValidId+1);
            newStudent.JoinCourse(newCourse);
            myClass.AddStudent(existingStudent);

            myClass.AddCourse(newCourse);

            Assert.AreEqual(2, myClass.Students.Count);
        }

        // remove course
        [TestMethod]
        public void StudentGroupShouldRemoveCourse()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var course = new Course("HQC");

            myClass.AddCourse(course);
            myClass.RemoveCourse(course);

            Assert.AreEqual(0, myClass.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentGroupShouldThrowOnNullCourseRemove()
        {
            var myClass = new StudentGroup("TelerikAcad");
            myClass.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StudentGroupShouldThrowIfCourseDoesNotExistOnCourseRemove()
        {
            var myClass = new StudentGroup("TelerikAcad");
            var course = new Course("HQC");
            myClass.RemoveCourse(course);
        }
    }
}
