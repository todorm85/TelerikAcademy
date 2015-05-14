using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Display
    {
        #region Fields

        private double displaySize;
        private long colorsCount;

        #endregion

        #region Properties

        public double DisplaySize
        {
            get
            {
                return this.displaySize;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Size cannot be negative");
                }

                this.displaySize = value;
            }
        }

        public long ColorsCount
        {
            get
            {
                return this.colorsCount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Colors count cannot be negative");
                }

                this.colorsCount = value;
            }
        }

        #endregion

        #region Constructors

        public Display() { }

        public Display(double sizeInch, long colorsCount) : this()
        {
            this.DisplaySize = sizeInch;
            this.ColorsCount = colorsCount;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string result = "";
            result =
                string.Format("DisplaySize: {0}\n", DisplaySize) +
                string.Format("ColorsCount: {0}", ColorsCount);
            return result;
        }

        #endregion
    }
}