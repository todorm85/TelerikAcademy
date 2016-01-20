namespace _01_CarsSearch
{
    public class Extra
    {
        public Extra(string[] gears, string[] engines)
        {
            this.Gears = gears;
            this.EngineTypes = engines;
        }

        public string[] EngineTypes { get; private set; }

        public string[] Gears { get; private set; }
    }
}