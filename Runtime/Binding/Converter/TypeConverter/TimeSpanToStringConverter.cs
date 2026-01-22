using System;
using System.Globalization;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// A converter that transforms a TimeSpan object into a string representation, using a specified format and culture information.
    /// </summary>
    public class TimeSpanToStringConverter : IValueConverter
    {
        private readonly string format;
        private readonly CultureInfo cultureInfo;
        
        public TimeSpanToStringConverter(string format = null, CultureInfo cultureInfo = null)
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
            if (value is TimeSpan timeSpan)
            {
                return timeSpan.ToString(format, CultureInfo);
            }
                
            return value;
        }

        public object ConvertBack(object value)
        {
            return value;
        }
    }
}