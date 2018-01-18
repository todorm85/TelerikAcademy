namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumber(1.3, "f");
            PrintNumber(0.75, "%");
            PrintNumber(2.30, "r");

            Point p1 = new Point(3, -1),
                   p2 = new Point(3, 2.5);
            Console.WriteLine(CalcDistance(p1, p2));
            Console.WriteLine("Horizontal? " + IsHorizontal(p1, p2));
            Console.WriteLine("Vertical? " + IsVertical(p1, p2));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";
            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";
            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }

        private static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive");
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Provided side lengths cannot form a triangle!");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        private static string DigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentException("Invalid digit!");
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Must provide arguments!");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        private static void PrintNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }
        
        private static double CalcDistance(Point p1, Point p2)
        {
            double distance = Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)));
            return distance;
        }

        private static bool IsHorizontal(Point p1, Point p2)
        {
            bool isHorizontal = p1.Y == p2.Y;
            return isHorizontal;
        }

        private static bool IsVertical(Point p1, Point p2)
        {
            bool isVertical = p1.X == p2.X;
            return isVertical;
        }
    }
}
