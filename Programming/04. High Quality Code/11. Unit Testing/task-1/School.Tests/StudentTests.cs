using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace School.Tests
{
    [TestClass]
    public class StudentTests
    {
        // Test name
        [TestMethod]
        public void StudentShouldReturnCorrectName()
        {
            var student = new Student("Pesho", 10000);
            Assert.AreEqual(student.Name, "Pesho", "Student returned wrong name.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowIfNameIsNull()
        {
            var studnet = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowIfNameIsWhitespaces()
        {
            var studnet = new Student("  ", 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowIfNameIsEmptyString()
        {
            var studnet = new Student("", 10000);
        }

        // test id
        [TestMethod]
        public void StudentShouldReturnCorrectId()
        {
            var student = new Student("Pesho", 15000);
            Assert.AreEqual(student.Id, 15000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowIfIdIsLessThanMinId()
        {
            var student = new Student("Pesho", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowIfIdIsBiggerThanMaxId()
        {
            var student = new Student("Pesho", 1000000);
        }

        // test student course methods
        [TestMethod]
        public void StudentShouldNotThrowWhenJoiningCourse()
        {
            var course = new Course("testCourse");
            var st = new Student("Pesho", 15000);
            st.JoinCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentSHouldThrowWehnJoiningNullCourse()
        {
            var st = new Student("Pesho", 15000);
            st.JoinCourse(null);
        }

        [TestMethod]
        public void StudentShouldNotThrowWhenLeavingCourse()
        {
            var course = new Course("testCourse");
            var st = new Student("Pesho", 15000);
            st.JoinCourse(course);
            st.LeaveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void StudentSHouldThrowWhenLeavingNullCourse()
        {
            var st = new Student("Pesho", 15000);
            st.LeaveCourse(null);
        }
    }
}
