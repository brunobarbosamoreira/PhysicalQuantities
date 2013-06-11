using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PhysicalQuantities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    public class Temperature : PhysicalQuantityBase<Temperature.Units>
    {
        public enum Units : int
        {
            kelvin = 0,
            Celsius = 1,
            Fahrenheit = 2
        }

        #region Properties
        protected override Units ViewUnits
        {
            get { return Units.Celsius; }
        }
        protected override Units ModelUnits
        {
            get { return Units.Celsius; }
        }
        public override String UIUnitSymbol
        {
            get
            {
                String ans = String.Empty;
                switch (ViewUnits)
                {
                    case Units.kelvin:
                        ans = "K";
                        break;
                    case Units.Celsius:
                        ans = "°C";
                        break;
                    case Units.Fahrenheit:
                        ans = "°F";
                        break;
                    default:
                        break;
                }
                return ans;
            }
        }
        #endregion

        #region Methods
        protected override sealed Double Convert(Double Value, Units From, Units To)
        {
            switch (From)
            {
                case Units.kelvin:
                    break;
                case Units.Celsius:
                    Value = Value + 273.15;
                    break;
                case Units.Fahrenheit:
                    Value = (Value + 459.67) * 5.0 / 9.0;
                    break;
                default:
                    break;
            }

            switch (To)
            {
                case Units.kelvin:
                    break;
                case Units.Celsius:
                    Value = Value - 273.15;
                    break;
                case Units.Fahrenheit:
                    Value = Value * 9.0 / 5.0 - 459.67;
                    break;
                default:
                    break;
            }

            return Value;
        }
        #endregion
    }
}
