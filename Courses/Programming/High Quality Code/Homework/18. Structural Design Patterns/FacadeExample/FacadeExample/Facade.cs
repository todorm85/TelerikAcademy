namespace FacadeExample
{
    internal class Facade
    {
        private SimpleClass1 simpleInstance1 = new SimpleClass1();
        private SimpleClass2 simpleInstance2 = new SimpleClass2();
        private SimpleClass3 simpleInstance3 = new SimpleClass3();

        public Facade()
        {
        }

        public void DoSomethingComplex()
        {
            this.simpleInstance1.DoSomethingSimple();
            this.simpleInstance2.DoSomethingSimple();
            this.simpleInstance3.DoSomethingSimple();
        }
    }
}