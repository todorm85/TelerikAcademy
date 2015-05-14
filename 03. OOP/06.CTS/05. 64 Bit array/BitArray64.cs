using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_array64
{
    class BitArray64 : IEnumerable<byte>
    {
        private ulong bitsArray;

        public BitArray64(string bits)
        {
            this.BitsArray = bits;
        }

        public string BitsArray
        {
            get { return UlongToBitString(this.bitsArray); }
            set
            {
                if (value.Length > 64 || value.Length == 0)
                {
                    throw new ArgumentException("Array length must be in range [1-64]");
                }

                bitsArray = Convert.ToUInt64(value, 2);
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index > 63 || index < 0)
                {
                    throw new ArgumentException("Index must be in range [0-63]");
                }

                return (byte)((this.bitsArray >> (63 - index)) & 1ul);
            }
            set
            {
                if (index > 63 || index < 0)
                {
                    throw new ArgumentException("Inde must be in range [0-63]");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Bit value can be either 1 or 0");
                }

                ulong currentBitValue = (this.bitsArray >> (63 - index)) & 1ul;
                ulong mask = (ulong)1 << (63 - index);

                if (value == 1)
                {
                    this.bitsArray = this.bitsArray | mask;
                }

                else
                {
                    if (currentBitValue == 1ul)
                    {
                        this.bitsArray = this.bitsArray ^ mask;
                    }
                }
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static string UlongToBitString(ulong num)
        {
            StringBuilder sb = new StringBuilder();
            ulong remainder = 0;
            while (true)
            {
                remainder = num % 2;
                sb.Insert(0, remainder);
                num /= 2;
                if (num == 0)
                {
                    break;
                }
            }

            //return sb.ToString().PadLeft(64, '0');
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if ((obj as BitArray64) == null)
            {
                return false;
            }

            return this.bitsArray == (obj as BitArray64).bitsArray;
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
	        return BitArray64.Equals(a,b);
        }

        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !(BitArray64.Equals(a, b));

        }

        public override int GetHashCode()
        {
            return bitsArray.GetHashCode();
        }
    }
}
