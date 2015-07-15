namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine("File Utils testing...");
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("OrthoSpace testing...");
            OrthogonalSpace3D mySpace = new OrthogonalSpace3D(15, 10, 20);
            TestSpaceMethods(mySpace);
            mySpace.Depth = 1;
            mySpace.Width = 1;
            mySpace.Height = 1;
            TestSpaceMethods(mySpace);
        }

        private static void TestSpaceMethods(OrthogonalSpace3D space)
        {
            Console.WriteLine(space.CalcDiagonalXY());
            Console.WriteLine(space.CalcDiagonalXYZ());
            Console.WriteLine(space.CalcDiagonalYZ());
            Console.WriteLine(space.CalcVolume());
        }
    }
}
