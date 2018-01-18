using System;

namespace Stool
{
    class errorSomewhere
    {
        static int n;
        static Stool[] stools;
        static int[,,] memo;

        static int MaxHeight(int used, int top, int side)
        {
            if (used == (1 << top))
            {
                if (side == 0)
                {
                    return stools[top].X;
                }

                if (side == 1)
                {
                    return stools[top].Y;
                }

                return stools[top].Z;
            }

            if (memo[used, top, side] != 0)
            {
                return memo[used, top, side];
            }

            int fromStools = used ^ (1 << top);
            
            int sideX = (side == 0) ? stools[top].Y : stools[top].X;
            int sideY = (side == 2) ? stools[top].Y : stools[top].Z;
            int sideH = stools[top].X + stools[top].Y + stools[top].Z - sideX - sideY;

            int result = sideH;

            for (int i = 0; i < n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {
                    // side == 0
                    if ((stools[i].Y >= sideX && stools[i].Z >= sideY)
                    || (stools[i].Y >= sideY && stools[i].Z >= sideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 0) + sideH);
                    }

                    if (stools[i].X == stools[i].Y && stools[i].X == stools[i].Z)
                    {
                        continue;
                    }

                    // side == 1
                    if ((stools[i].X >= sideX && stools[i].Z >= sideY)
                    || (stools[i].X >= sideY && stools[i].Z >= sideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 1) + sideH);
                    }

                    // side == 2
                    if ((stools[i].X >= sideX && stools[i].Y >= sideY)
                    || (stools[i].X >= sideX && stools[i].Y >= sideX))
                    {
                        result = Math.Max(result, MaxHeight(fromStools, i, 2) + sideH);
                    }
                }
            }

            memo[used, top, side] = result;
            return result;
        }

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            stools = new Stool[n];
            memo = new int[1 << n, n, 3];
            //memo = new int[1 << n, 16, 4];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                int x = int.Parse(line[0]);
                int y = int.Parse(line[1]);
                int z = int.Parse(line[2]);

                stools[i] = new Stool(x, y, z);
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result = Math.Max(result, MaxHeight((1 << n) - 1, i, j));
                }
            }

            Console.WriteLine(result);
        }

    }

    public class Stool
    {
        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Z { get; set; }
    }
}