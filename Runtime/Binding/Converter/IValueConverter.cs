namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a value conversion mechanism for transforming data from one format to another.
    /// </summary>
    public interface IValueConverter
    {
        object Convert(object value);
        object ConvertBack(object value);
    }
}