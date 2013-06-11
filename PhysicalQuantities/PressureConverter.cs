using System;
using System.Windows.Data;

namespace PhysicalQuantities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    public class Pressure : PhysicalQuantityBase<Pressure.Units>
    {
        public enum Units : int
        {
            pascal = 0,
            bar = 1,
            psi = 2
        }

        #region Properties
        protected override Units ViewUnits
        {
            get { return Units.bar; }
        }
        protected override Units ModelUnits
        {
            get { return Units.bar; }
        }
        public override String UIUnitSymbol
        {
            get
            {
                String ans = String.Empty;
                switch (ViewUnits)
                {
                    case Units.pascal:
                        ans = "Pa";
                        break;
                    case Units.bar:
                        ans = "bar";
                        break;
                    case Units.psi:
                        ans = "psi";
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
                case Units.pascal:
                    break;
                case Units.bar:
                    Value = Value * 1e5;
                    break;
                case Units.psi:
                    Value = Value * 6.8948e3;
                    break;
                default:
                    break;
            }

            switch (To)
            {
                case Units.pascal:
                    break;
                case Units.bar:
                    Value = Value * 1e-5;
                    break;
                case Units.psi:
                    Value = Value * 1.450377e-4;
                    break;
                default:
                    break;
            }

            return Value;
        }
        #endregion
    }
}
