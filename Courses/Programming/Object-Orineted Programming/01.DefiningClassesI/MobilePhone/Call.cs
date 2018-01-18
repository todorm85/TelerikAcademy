using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        #region Fields

        private DateTime date;
        private string dialedNumber;
        private int duration;

        #endregion

        #region Properties

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = value;
            }
        }

        public string DialedNumber
        {
            get
            {
                return this.dialedNumber;
            }

            set
            {
                this.dialedNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Call duration cannot be negative!");
                }

                this.duration = value;
            }
        }

        #endregion

        #region Constructors

        public Call(DateTime date, string dialedNumber, int duration)
        {
            this.Date = date;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        #endregion
    }
}
