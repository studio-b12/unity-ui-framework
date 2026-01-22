using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// A converter that transforms hex code strings into UnityEngine.Color values
    /// and vice versa. It implements the IValueConverter interface.
    /// </summary>
    /// <remarks>
    /// This converter is typically used to handle conversion between color representations
    /// in string (hexadecimal format) and Unity's Color structure.
    /// </remarks>
    /// <example>
    /// The class supports the conversion of valid hex color codes (e.g., "#FFFFFF", "#FF0000FF")
    /// to Color objects and the reverse conversion of Color objects to hex string representations.
    /// If an invalid or null value is provided during conversion, it defaults to Color.white.
    /// </example>
    public class HexCodeToColorConverter : IValueConverter
    {
        public object Convert(object value)
        {
            if (value != null && ColorUtility.TryParseHtmlString(value.ToString(), out Color color))
            {
                return color;
            }

            return Color.white;
        }

        public object ConvertBack(object value)
        {
            if (value is Color color)
            {
                return ColorUtility.ToHtmlStringRGBA(color);
            }
            
            return ColorUtility.ToHtmlStringRGBA(Color.white);
        }
    }
}