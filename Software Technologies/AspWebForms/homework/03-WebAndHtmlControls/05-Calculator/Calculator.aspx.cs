using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _05_Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        public const string ErrorMessage = "Error";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Digit_ServerClick(object sender, EventArgs e)
        {
            if (this.result.Value == ErrorMessage)
            {
                this.result.Value = String.Empty;
            }
            var digit = ((HtmlButton)sender).InnerText;
            if (digit == "0" && this.result.Value == String.Empty)
            {
                return;
            }

            this.result.Value += digit;
        }

        protected void Operation_ServerClick(object sender, EventArgs e)
        {
            if (this.result.Value == String.Empty || this.result.Value == ErrorMessage)
            {
                this.result.Value = ErrorMessage;
                this.lastOperation.Value = String.Empty;
                this.currentResult.Value = String.Empty;
                return;
            }


            switch (this.lastOperation.Value)
            {
                case "+":
                    Sum();
                    break;
                case "-":
                    Subtract();
                    break;
                case "x":
                    Multiply();
                    break;
                case "/":
                    Divide();
                    break;
                case "":
                    this.currentResult.Value = this.result.Value;
                    this.result.Value = String.Empty;
                    break;
                default:
                    break;
            }

            var operation = ((HtmlButton)sender).InnerText;
            if (operation == "=")
            {
                this.lastOperation.Value = String.Empty;
                this.result.Value = this.currentResult.Value;
                this.currentResult.Value = String.Empty;
                return;
            }

            this.lastOperation.Value = operation;
        }

        private void Divide()
        {
            this.currentResult.Value = (decimal.Parse(this.currentResult.Value) / decimal.Parse(this.result.Value)).ToString();
            this.result.Value = String.Empty;
        }

        private void Multiply()
        {
            this.currentResult.Value = (decimal.Parse(this.currentResult.Value) * decimal.Parse(this.result.Value)).ToString();
            this.result.Value = String.Empty;
        }

        private void Subtract()
        {
            this.currentResult.Value = (decimal.Parse(this.currentResult.Value) - decimal.Parse(this.result.Value)).ToString();
            this.result.Value = String.Empty;
        }

        private void Sum()
        {
            this.currentResult.Value = (decimal.Parse(this.result.Value) + decimal.Parse(this.currentResult.Value)).ToString();
            this.result.Value = String.Empty;
        }

        protected void Clear_ServerClick(Object sender, EventArgs e)
        {
            this.result.Value = String.Empty;
            this.currentResult.Value = String.Empty;
            this.lastOperation.Value = String.Empty;
        }

        protected void Sqrt_ServerClick(Object sender, EventArgs e)
        {
            try
            {
                this.result.Value = Math.Sqrt(double.Parse(this.result.Value)).ToString();
            }
            catch (Exception)
            {
                this.result.Value = ErrorMessage;
            }
        }
    }
}