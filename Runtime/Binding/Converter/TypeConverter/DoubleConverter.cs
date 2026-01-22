namespace Rehawk.UIFramework
{
    /// <summary>
    /// A converter class responsible for converting values to a double type.
    /// </summary>
    public class DoubleConverter : IValueConverter
    {
        public object Convert(object value)
        {
            string inputStr = value?.ToString();
                
            if (double.TryParse(inputStr, out double result))
            {
                return result;
            }

            return 0;
        }

        public object ConvertBack(object value)
        {
            return value;
        }
    }
}