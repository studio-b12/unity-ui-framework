namespace Rehawk.UIFramework
{
    /// <summary>
    /// Defines the contract for combining and dividing values in multi-binding scenarios.
    /// Implementers of this interface provide functionality to combine multiple input values into a single output value,
    /// and optionally divide a single input value back into multiple output values.
    /// </summary>
    public interface IValueCombiner
    {
        object Combine(object[] values);
        object[] Divide(object value);
    }
}