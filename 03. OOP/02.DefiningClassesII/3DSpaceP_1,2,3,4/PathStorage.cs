using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space3D
{
    public static class PathStorage
    {
        public static void SavePath(Path inputPath, string fileName)
        {
            using (StreamWriter output = new StreamWriter(String.Format(@"..\..\{0}.txt", fileName)))
            {
                StringBuilder rawPath = new StringBuilder();
                for (int i = 0; i < inputPath.PathPoints.Count; i++)
                {
                    rawPath.Append(inputPath.PathPoints[i].ToString());
                    rawPath.Append('*');
                }

                output.WriteLine(rawPath.ToString());
            }
        }

        public static Path LoadPath(string fileName)
        {
            Path loadedPath = new Path();
            if (!File.Exists(String.Format(@"..\..\{0}.txt", fileName)))
            {
                throw new ArgumentException("File to load path from does not exist!");
            }

            using (StreamReader input = new StreamReader(String.Format(@"..\..\{0}.txt", fileName)))
            {
                string[] loadedPoints = input.ReadLine().Split(new char[] {'*'},StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < loadedPoints.Length; i++)
                {
                    string[] loadedPoint = loadedPoints[i].Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Substring(1)).ToArray();
                    Point3D currentPoint = new Point3D();
                    currentPoint.X = double.Parse(loadedPoint[0]);
                    currentPoint.Y = double.Parse(loadedPoint[1]);
                    currentPoint.Z = double.Parse(loadedPoint[2]);
                    loadedPath.AddPoint(currentPoint);
                }
            }

            return loadedPath;
        }
    }
}
