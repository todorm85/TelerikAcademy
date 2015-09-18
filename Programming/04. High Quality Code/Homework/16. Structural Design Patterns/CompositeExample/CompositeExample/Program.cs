namespace CompositeExample
{
    internal class Program
    {
        private static void Main()
        {
            var rootComposite = new CompositeElementA("root compElementA");

            var firstComposite1 = new CompositeElementA("first compElementA");
            rootComposite.AddComponent(firstComposite1);
            var firstComposite2 = new CompositeElementB("first compElementB");
            rootComposite.AddComponent(firstComposite2);

            var secondaryComposite1 = new CompositeElementA("secondary compElementA");
            firstComposite1.AddComponent(secondaryComposite1);
            var secondarySimple1 = new SimpleElementA("secondary simpleElementA");
            firstComposite2.AddComponent(secondarySimple1);

            rootComposite.getDetails(0);
        }
    }
}