using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problem
{
    internal class Program
    {
        const string EndLine = "end";
        static string line;
        static string testName = "000.001";

        static HashSet<Unit> all = new HashSet<Unit>();
        //static SortedSet<Unit> sortedByAttack = new SortedSet<Unit>();

        static SortedSet<Unit> sortedByAttack = new SortedSet<Unit>();

        static Dictionary<string, HashSet<Unit>> byType = new Dictionary<string, HashSet<Unit>>();

        //private static void Main()
        //{
        //    Inputs.SetInput(testName);
        //    var ow = new StreamWriter($@"..\..\test.{testName}.result.txt");
        //    Console.SetOut(ow);

        //    // Solution start
        //    GetInput();
        //    //Solution end

        //    ow.Dispose();
        //}

        private static void Main()
        {
            GetInput();
        }


        private static void GetInput()
        {
            line = Console.ReadLine();
            while (line != EndLine)
            {
                ParseLine(line);
                line = Console.ReadLine();
            }
        }

        private static void ParseLine(string line)
        {
            var lineComponents = line.Split(' ');

            if (line.StartsWith("add"))
            {
                Add(lineComponents);
            }
            else if (line.StartsWith("remove"))
            {
                Remove(lineComponents);
            }
            else if (line.StartsWith("find"))
            {
                Find(lineComponents);
            }
            else if (line.StartsWith("power"))
            {
                Power(lineComponents);
            }
        }

        private static void Power(string[] lineComponents)
        {
            var count = int.Parse(lineComponents[1]);

            // should be kept in sorted set by power?
            //var filteredUnits = all.OrderByDescending(x => x.Attack).Take(count);

            if (sortedByAttack.Count == 0 || count <= 0)
            {
                Console.WriteLine("RESULT: ");
                return;
            }

            var filteredUnits = new List<Unit>();
            //for (int i = 0; i < count; i++)
            //{
            //    if (sortedByAttack.Count == 0)
            //    {
            //        break;
            //    }

            //    var unit = sortedByAttack.Max;

            //    sortedByAttack.Remove(unit);
            //    filteredUnits.Add(unit);
            //}

            //for (int i = 0; i < filteredUnits.Count; i++)
            //{
            //    sortedByAttack.Add(filteredUnits[i]);
            //}
            var i = 0;
            foreach (var unit in sortedByAttack)
            {
                if (i == count)
                {
                    break;
                }

                filteredUnits.Add(unit);
                i++;
            }


            var unitsList = filteredUnits.Select(x => x.ToString()).ToList();

            PrintResult(unitsList);
        }

        private static void Remove(string[] lineComponents)
        {
            var name = lineComponents[1];

            var unit = all.FirstOrDefault(x => x.Name == name);
            if (unit == null)
            {
                Console.WriteLine("FAIL: {0} could not be found!", name);
                return;
            }

            all.Remove(unit);

            byType[unit.Type].Remove(unit);

            sortedByAttack.Remove(unit);

            Console.WriteLine("SUCCESS: {0} removed!", name);

        }

        private static void Find(string[] lineComponents)
        {
            var filterType = lineComponents[1];

            if (!byType.ContainsKey(filterType))
            {
                Console.WriteLine("RESULT: ");
                return;
            }

            var filteredProducts = byType[filterType];
            var orderedFiltered = OrderBy(filteredProducts, 10);
            var productList = orderedFiltered.Select(x => x.ToString()).ToList();

            PrintResult(productList);
        }

        private static void PrintResult(List<string> productList)
        {
            // todo: spped up with StringBuilder
            //var result = string.Join(", ", productList);
            //result = "Ok: " + result;

            var sb = new StringBuilder("RESULT: ");
            for (int i = 0; i < productList.Count; i++)
            {
                sb.Append(productList[i]);
                if (i == productList.Count - 1)
                {
                    continue;
                }

                sb.Append(", ");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static IEnumerable<Unit> OrderBy(IEnumerable<Unit> filteredProducts, int count)
        {
            return filteredProducts
                .OrderByDescending(x => x.Attack)
                .ThenBy(x => x.Name)
                //.ThenBy(x => x.Type)
                .Take(count);
        }

        

        private static void Add(string[] lineComponents)
        {
            var name = lineComponents[1];
            var type = lineComponents[2];
            var attack = int.Parse(lineComponents[3]);

            var unit = new Unit(name, attack, type);

            if (all.Contains(unit))
            {
                Console.WriteLine("FAIL: {0} already exists!", unit.Name);
                return;
            }

            all.Add(unit);

            if (!byType.ContainsKey(type))
            {
                byType[type] = new HashSet<Unit>();
            }

            byType[type].Add(unit);

            sortedByAttack.Add(unit);

            Console.WriteLine("SUCCESS: {0} added!", name);
        }

        private class Unit : IComparable
        {
            public Unit(string name, int attack, string type)
            {
                this.Name = name;
                this.Attack = attack;
                this.Type = type;
            }

            public string Name { get; private set; }
            public int Attack { get; private set; }
            public string Type { get; private set; }

            public override int GetHashCode()
            {
                return this.Name.GetHashCode() + this.Attack.GetHashCode() + this.Type.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var other = (Unit)obj;
                if (this.Name == other.Name && this.Attack == other.Attack && this.Type == other.Type)
                {
                    return true;
                }

                return false;
            }

            public override string ToString()
            {
                return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
            }

            public int CompareTo(Unit other)
            {
                var res = this.Attack.CompareTo(other.Attack);
                if (res == 0)
                {
                    return this.Name.CompareTo(other.Name) * -1;
                }

                return res;
            }

            public int CompareTo(object obj)
            {
                return this.CompareTo((Unit)obj) * -1;
            }
        }
    }
}