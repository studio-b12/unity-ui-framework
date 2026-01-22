using System;
using System.Globalization;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Provides a mechanism to convert <see cref="DateTime"/> objects into formatted string representations.
    /// Implements the <see cref="IValueConverter"/> interface for use in binding scenarios requiring value transformation.
    /// </summary>
    public class DateTimeToStringConverter : IValueConverter
    {
        private readonly string format;
        private readonly CultureInfo cultureInfo;
        
        public DateTimeToStringConverter(string format = null, CultureInfo cultureInfo = null)
        {
            this.format = format;
            this.cultureInfo = cultureInfo;
        }
        
        private CultureInfo CultureInfo
        {
            get { return cultureInfo != null ? cultureInfo : CultureInfo.CurrentUICulture; }
        }

        public object Convert(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString(format, CultureInfo);
            }
                
            return value;
        }

        public object ConvertBack(object value)
        {
            return value;
        }
    }
}