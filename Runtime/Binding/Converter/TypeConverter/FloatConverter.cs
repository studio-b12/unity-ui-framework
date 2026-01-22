namespace Rehawk.UIFramework
{
    /// <summary>
    /// Provides functionality to convert given input values into a float representation and
    /// perform reverse conversion without modifications.
    /// </summary>
    public class FloatConverter : IValueConverter
    {
        public object Convert(object value)
        {
            string inputStr = value?.ToString();
                
            if (float.TryParse(inputStr, out float result))
            {
                return result;
            }

            return 0f;
        }

        public object ConvertBack(object value)
        {
            return value;
        }
    }
}