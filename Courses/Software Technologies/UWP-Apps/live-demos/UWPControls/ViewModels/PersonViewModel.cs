namespace UWPControls.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}