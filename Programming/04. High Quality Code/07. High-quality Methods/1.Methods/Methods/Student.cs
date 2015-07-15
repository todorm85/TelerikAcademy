namespace Methods
{
    using System;
    using System.Globalization;

    public class Student
    {
        private string otherInfo;
        private DateTime birthday;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentException("Must specify at least birthdate at the end of other info string. Date must be exactly in format dd.mm.yyyy");
                }

                string dateString = value.Substring(value.Length - 10);
                DateTime convertedDate;
                if (!DateTime.TryParseExact(
                    dateString,
                    "dd.MM.yyyy",
                    CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out convertedDate))
                {
                    throw new ArgumentException("Birthdate must be exactly in dd.mm.yyyy format!");
                }

                this.birthday = convertedDate;
                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            DateTime currentStudentBirthday = this.birthday;
            DateTime otherStudentBirthday = other.birthday;

            // date comparison must be opposite, because student with 'lesser' date value is actually older
            bool isOlder = currentStudentBirthday < otherStudentBirthday;
            return isOlder;
        }
    }
}
