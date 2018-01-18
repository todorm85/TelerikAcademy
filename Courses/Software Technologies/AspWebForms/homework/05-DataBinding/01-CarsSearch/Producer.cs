namespace _01_CarsSearch
{
    public class Producer
    {
        public Producer(string name, string[] models)
        {
            this.Name = name;
            this.Models = models;
        }

        public string[] Models { get; private set; }

        public string Name { get; private set; }
    }
}