namespace Rehawk.UIFramework
{
    /// <summary>
    /// A value converter designed to transform an input value into an integer representation.
    /// Implements the IValueConverter interface to support custom conversion logic.
    /// </summary>
    public class IntConverter : IValueConverter
    {
        public object Convert(object value)
        {
            string inputStr = value?.ToString();
                
            if (int.TryParse(inputStr, out int result))
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