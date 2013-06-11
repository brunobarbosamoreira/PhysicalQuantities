using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PhysicalQuantities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    public abstract class PhysicalQuantityBase<T> : IValueConverter where T : struct
    {
        #region Constructor(s)
        static PhysicalQuantityBase()
        {
            if (!typeof(T).IsEnum) throw new InvalidOperationException(
                 typeof(T).Name + " is not an enum");
        }         
        #endregion

        #region Properties
        protected abstract T ViewUnits
        {
            get;
        }
        protected abstract T ModelUnits
        {
            get;
        }
        public abstract String UIUnitSymbol
        {
            get;
        }
        #endregion

        #region Methods
        protected abstract Double Convert(Double Value, T From, T To);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(System.Convert.ToDouble(value), ModelUnits, ViewUnits);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Convert(System.Convert.ToDouble(value), ViewUnits, ModelUnits);
            }
            catch (System.InvalidCastException)
            {
                return DependencyProperty.UnsetValue;
            }
            catch (System.OverflowException)
            {
                return DependencyProperty.UnsetValue;
            }
            catch (System.FormatException)
            {
                return DependencyProperty.UnsetValue;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
