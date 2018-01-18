using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class GSM
    {
        #region Fields

        // static fields and constants
        private static readonly GSM iPhone4S = new GSM(
            "4S", "Apple", 10000000, "Some poor guy",
            new Battery("Crap battery", 4, 46, BatteryType.LiIon),
            new Display(4.5, 16000000));

        private const decimal billPerMin = 0.37M;

        // non-static fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private List<Call> callHistory = new List<Call>();

        #endregion

        #region Properties

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("GSM model cannot be empty!");
                }

                else
                {
                    this.model = value.Trim();
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Manufacturer name cannot be empty!");
                }

                else
                {
                    this.manufacturer = value.Trim();
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be less than 0");
                }

                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentException("Owner name cannot be empty!");
                }

                else
                {
                    this.owner = value.Trim();
                }
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return new List<Call>(this.callHistory);
            }
            private set
            {
                this.callHistory = new List<Call>(value);
            }
        }

        public Display Display { get; set; }
        public Battery Battery { get; set; }

        // static properties
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public static decimal BilPerMin
        {
            get
            {
                return billPerMin;
            }
        }

        #endregion

        #region Constructors

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display) : this(model, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        #endregion

        #region Methods    
    
        public override string ToString()
        {
            string result = "";
            result =
                string.Format("Model: {0}\n", Model) +
                string.Format("Manufacturer: {0}\n", Manufacturer) +
                string.Format("Price: {0}\n", Price) +
                string.Format("Owner: {0}\n", Owner) +
                string.Format("\nBattery Specs \n{0}\n", Battery) +
                string.Format("\nDisplay Specs \n{0}", Display);
            return result.ToString();
        }

        public void AddCall(Call call)
        {
            List<Call> tempCallHistory = new List<Call>(this.CallHistory);
            tempCallHistory.Add(call);
            this.CallHistory = tempCallHistory;
        }

        public void DeleteCall(int index)
        {
            if (index < 0 || index >= this.CallHistory.Count)
            {
                throw new IndexOutOfRangeException("Invalid Call Index!");
            }

            List<Call> tempCallHistory = new List<Call>(this.CallHistory);
            tempCallHistory.RemoveAt(index);
            this.CallHistory = tempCallHistory;
        }

        public void ClearCalls()
        {
            List<Call> tempCallHistory = new List<Call>(this.CallHistory);
            tempCallHistory.Clear();
            this.CallHistory = tempCallHistory;
        }

        public decimal TotalCallsBill()
        {
            decimal totalBill = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                totalBill += ((callHistory[i].Duration / 60M) * billPerMin);
            }

            return totalBill;
        }

        #endregion
    }
}
