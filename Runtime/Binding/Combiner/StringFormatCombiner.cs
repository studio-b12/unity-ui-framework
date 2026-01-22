using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// StringFormatCombiner combines multiple input values into a single formatted string
    /// based on the provided string format. This implementation is useful in scenarios
    /// where a user needs to bind and format multiple values into a single string output.
    /// </summary>
    public class StringFormatCombiner : IValueCombiner
    {
        private readonly string format;
        
        public StringFormatCombiner(string format)
        {
            this.format = format;
        }
        
        public object Combine(object[] values)
        {
            return string.Format(format, values);
        }

        public object[] Divide(object value)
        {
            throw new NotSupportedException("Back conversion of multiple values formatted as string is not supported.");
        }
    }
}