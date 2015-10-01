using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public enum BatteryType
    {
        Unknown,
        LiIon,
        NiMH,
        NiCd
    }

    public class Battery
    {
        #region Fields

        private string batteryModel;
        private double hoursTalk;
        private double hoursIdle;

        #endregion

        #region Properties

        public string BatteryModel
        {
            get
            {
                return this.batteryModel;
            }

            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Battery Model cannot be empty!");
                }

                else
                {
                    this.batteryModel = value;
                }
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery talk hours cannot be negative");
                }

                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery idle hours cannot be negative");
                }

                else
                {
                    this.hoursIdle = value;
                }
            }
        }

        public BatteryType BatteryType { get; set; }

        #endregion

        #region Constructors

        public Battery(string model)
        {
            this.BatteryModel = model;
        }

        public Battery(string model, double hoursTalk, double hoursIdle, BatteryType type)
            : this(model)
        {
            this.HoursTalk = hoursTalk;
            this.HoursIdle = hoursIdle;
            this.BatteryType = type;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string result = "";
            result =
                string.Format("BatteryModel: {0}\n", BatteryModel) +
                string.Format("HoursIdle: {0}\n", HoursIdle) +
                string.Format("HoursTalk: {0}\n", HoursTalk) +
                string.Format("BatteryType: {0}", BatteryType);
            return result;
        }

        #endregion
    }
}
