using System;
using System.Windows.Data;

namespace PhysicalQuantities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    public class Mass : PhysicalQuantityBase<Mass.Units>
    {
        public enum Units : int
        {
            kg = 0,
            lb = 1,
        }

        #region Properties
        protected override Units ViewUnits
        {
            get { return Units.kg; }
        }
        protected override Units ModelUnits
        {
            get { return Units.kg; }
        }
        public override String UIUnitSymbol
        {
            get
            {
                String ans = String.Empty;
                switch (ViewUnits)
                {
                    case Units.kg:
                        ans = "kg";
                        break;
                    case Units.lb:
                        ans = "lb";
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
                case Units.kg:
                    break;
                case Units.lb:
                    Value = Value * 4.5359237e-1;
                    break;
                default:
                    break;
            }

            switch (To)
            {
                case Units.kg:
                    break;
                case Units.lb:
                    Value = Value / 4.5359237e-1;
                    break;
                default:
                    break;
            }

            return Value;
        }
        #endregion
    }
}
