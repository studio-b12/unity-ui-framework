using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// A class that combines two numerical values to calculate the
    /// percentage. The first value represents the part, and the second
    /// represents the whole. The output is the ratio of part to whole
    /// expressed as a percentage.
    /// </summary>
    /// <remarks>
    /// This class implements the IValueCombiner interface. It computes
    /// the percentage by dividing the first input value by the second,
    /// provided both values are non-null, parsable as floats, and the
    /// second value is not zero. If these conditions are not met, a default
    /// value of 0 is returned. Back conversion is not supported.
    /// </remarks>
    public class PercentageCombiner : IValueCombiner
    {
        public object Combine(object[] values)
        {
            if (values.Length < 2 || values[0] == null || values[1] == null)
                return 0;

            if (float.TryParse(values[0].ToString(), out float part) &&
                float.TryParse(values[1].ToString(), out float whole) &&
                whole != 0)
            {
                return (part / whole);
            }

            return 0;
        }

        public object[] Divide(object value)
        {
            throw new NotSupportedException("Back conversion of percentage is not supported.");
        }
    }
}