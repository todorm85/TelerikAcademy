namespace UWPControls.ViewModels
{
    public class PersonViewModel : ViewModelBase
    {
        private string name;

        private int age;

        public PersonViewModel(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }

            set
            {
                age = value;
                this.RaisePropertyChanged("Age");
            }
        }

        public static PersonViewModel FromPerson(PersonViewModel person)
        {
            return new PersonViewModel(person.Name, person.Age);
        }
    }
}