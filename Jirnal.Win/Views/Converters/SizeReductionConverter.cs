using System;
using System.Globalization;
using System.Windows.Data;

namespace Jirnal.Win.Views.Converters
{
    public class SizeReductionConverter : IValueConverter
    {
        public double Adjustment { get; set; }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
                return value;
            
            if (parameter is double adjustment)
                return (double) value - adjustment;

            return (double)value - Adjustment;
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double))
                return value;
            
            if (parameter is double adjustment)
                return (double) value + adjustment;

            return (double)value + Adjustment;
        }
    }
}