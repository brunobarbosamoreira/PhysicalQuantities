using System;
using System.Windows.Data;

namespace PhysicalQuantities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    public class Volume : PhysicalQuantityBase<Volume.Units>
    {
        public enum Units : int
        {
            CubicMeter = 0,
            Liter = 1,
            gallon = 2
        }

        #region Properties
        protected override Units ViewUnits
        {
            get { return Units.Liter; }
        }
        protected override Units ModelUnits
        {
            get { return Units.Liter; }
        }
        public override String UIUnitSymbol
        {
            get
            {
                String ans = String.Empty;
                switch (ViewUnits)
                {
                    case Units.CubicMeter:
                        ans = "m³";
                        break;
                    case Units.Liter:
                        ans = "L";
                        break;
                    case Units.gallon:
                        ans = "gal";
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
                case Units.CubicMeter:
                    break;
                case Units.Liter:
                    Value = Value * 1e-3;
                    break;
                case Units.gallon:
                    Value = Value * 3.785411784e-3;
                    break;
                default:
                    break;
            }

            switch (To)
            {
                case Units.CubicMeter:
                    break;
                case Units.Liter:
                    Value = Value * 1e3;
                    break;
                case Units.gallon:
                    Value = Value / 3.785411784e-3;
                    break;
                default:
                    break;
            }

            return Value;
        }
        #endregion
    }
}
