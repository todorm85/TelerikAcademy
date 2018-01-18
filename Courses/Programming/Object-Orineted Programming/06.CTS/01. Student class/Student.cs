using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_class
{
    class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string tel;
        private string email;
        private string course;
        private Specialities speciality;
        private Universities uni;
        private Faculties faculty;

        public Student(string firstName, string middleName, string lastName, string SSN)
        {
            this.Ssn = SSN;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }

        public Faculties Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public Universities Uni
        {
            get { return uni; }
            set { uni = value; }
        }

        public Specialities Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        public string Course
        {
            get { return course; }
            set { course = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public override bool Equals(object obj)
        {
            if (this.Ssn == (obj as Student).Ssn)
            {
                return true;
            }

            else return false;
        }

        public override int GetHashCode()
        {
            return this.Ssn.GetHashCode();
        }

        public static bool operator ==(Student st1, Student st2)
        {
            return st1.Equals(st2);
        }

        public static bool operator !=(Student st1, Student st2)
        {
            return !(st1==st2);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, SSN = {2}",this.firstName, this.LastName, this.Ssn);
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
                return this.FirstName.CompareTo(other.FirstName);
            if (this.MiddleName.CompareTo(other.MiddleName) != 0)
                return this.MiddleName.CompareTo(other.MiddleName);
            if (this.LastName.CompareTo(other.LastName) != 0)
                return this.LastName.CompareTo(other.LastName);
            if (Convert.ToUInt64(this.Ssn).CompareTo(Convert.ToUInt64(other.Ssn)) != 0)
                return Convert.ToUInt64(this.Ssn).CompareTo(Convert.ToUInt64(other.Ssn));

            return 0;
        }

        public object Clone()
        {
            Student clonedStudent = new Student(this.FirstName,this.MiddleName,this.LastName,this.Ssn);
            clonedStudent.Course = this.Course;
            clonedStudent.Email = this.Email;
            clonedStudent.Faculty = this.Faculty;
            clonedStudent.Speciality = this.Speciality;
            clonedStudent.Tel = this.Tel;
            clonedStudent.Uni = this.Uni;
            return clonedStudent;
        }
    }
}
