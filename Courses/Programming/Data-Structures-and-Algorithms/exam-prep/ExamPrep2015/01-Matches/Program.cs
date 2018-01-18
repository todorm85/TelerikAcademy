
//# Задача – Съвпадение
//Ето как ще проверим вашата памет.Вашата задача е по два зададени стринга да намерите колко е най-дългата обща част в тях.

//## Вход
//Входните данни се четат от стандартния вход (конзолата).
//Двата стринга се четат на два отделни реда, до края на редовете.

//## Изход
//Изходните данни трябва да се изведат на стандартния изход(конзолата).
//На единствения ред от стандартния да се изведе едно число – търсения отговор.

//## Ограничения
//* Стринговете ще бъдат не по-дълги от **100 000** символа.
//* В тях могат да се съдържат символи с ASCII код** между 32 и 126 включително**.
//* Разрешено време за работа на програмата: **0.30 секунди**.
//* Разрешена памет: **16 MB**.

//## Примери
//| Примерен вход | Примерен изход |
//| ------------- |--------------- |
//| -=input= -< br > put -= 42; | 3 |
//| #define<br>(!Fine) | 3 |

namespace Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static string str1;
        private static string str2;

        private static void Main()
        {
            //Inputs.SetInput(Inputs.Test3);

            GetInput();
            Solve(str1, str2);
        }

        private static void Solve(string str1, string str2)
        {
            int left = 0;
            int right = Math.Min(str1.Length, str2.Length);

            Hash.ComputePowers(right);

            while (left < right)
            {
                var mid = (left + right) / 2 + 1;

                bool matchFound = CheckMatch(str1, str2, mid);

                if (matchFound)
                {
                    left = mid;
                }
                else
                {
                    right = mid-1;
                }
            }

            Console.WriteLine(right);
        }

        private static bool CheckMatch(string str1, string str2, int len)
        {
            var firstHash = new Hash(str1.Substring(0, len));
            var str1hashes = new HashSet<ulong>();
            str1hashes.Add(firstHash.Value1);

            for (int i = len; i < str1.Length; i++)
            {
                var char2add = str1[i];
                firstHash.Add(char2add);

                var char2rem = str1[i-len];
                firstHash.Remove(char2rem, len);

                str1hashes.Add(firstHash.Value1);
            }

            var secondHash = new Hash(str2.Substring(0, len));
            if (str1hashes.Contains(secondHash.Value1))
            {
                return true;
            }

            for (int i = len; i < str2.Length; i++)
            {
                var char2add = str2[i];
                secondHash.Add(char2add);

                var char2rem = str2[i - len];
                secondHash.Remove(char2rem, len);

                if (str1hashes.Contains(secondHash.Value1))
                {
                    return true;
                }
            }

            return false;
        }

        private static void GetInput()
        {
            str1 = Console.ReadLine();
            str2 = Console.ReadLine();
        }
    }

    class Hash
    {
        private const ulong BASE1 = 127;
        private const ulong BASE2 = 257;
        private const ulong MOD = ulong.MaxValue / BASE2;

        private static ulong[] powers1;
        private static ulong[] powers2;

        public static void ComputePowers(int n)
        {
            powers1 = new ulong[n + 1];
            powers2 = new ulong[n + 1];
            powers1[0] = 1;
            powers2[0] = 1;

            for (int i = 0; i < n; i++)
            {
                powers1[i + 1] =
                  powers1[i] * BASE1 % MOD;

                powers2[i + 1] =
                  powers2[i] * BASE2 % MOD;
            }
        }

        public ulong Value1 { get; private set; }
        public ulong Value2 { get; private set; }

        public Hash(string str)
        {
            this.Value1 = 0;

            foreach (char c in str)
            {
                this.Add(c);
            }
        }

        public void Add(char c)
        {
            this.Value1 =
                (this.Value1 * BASE1 + c)
                          % MOD;

            this.Value2 =
                (this.Value2 * BASE2 + c)
                          % MOD;
        }

        public void Remove(char c, int n)
        {
            this.Value1 = (MOD +
              this.Value1 - powers1[n] * c % MOD)
                    % MOD;

            this.Value2 = (MOD +
              this.Value2 - powers2[n] * c % MOD)
                    % MOD;
        }
    }
}