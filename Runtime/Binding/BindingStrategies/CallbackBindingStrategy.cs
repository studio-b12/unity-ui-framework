using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a strategy for binding data using callback functions for getting and setting values.
    /// </summary>
    /// <typeparam name="T">The type of the value being bound.</typeparam>
    public class CallbackBindingStrategy<T> : IBindingStrategy
    {
        private readonly Func<T> getFunction;
        private readonly Action<T> setCallback;
        
        private IValueConverter converter;

        // Has no implementation for that.
        public event Action GotDirty;

        public CallbackBindingStrategy(Func<T> getFunction, Action<T> setCallback)
        {
            this.getFunction = getFunction;
            this.setCallback = setCallback;
        }

        /// <summary>
        /// Sets the value converter used for transforming data during binding operations.
        /// </summary>
        /// <param name="converter">The value converter to be used for data transformation.</param>
        public void SetConverter(IValueConverter converter)
        {
            this.converter = converter;
        }

        public void Evaluate() { }

        public void Release() { }
        
        public object Get()
        {
            object result = null;

            if (getFunction != null)
            {
                result = getFunction.Invoke();
            }

            if (converter != null)
            {
                result = converter.Convert(result);
            }

            return result;
        }

        public void Set(object value)
        {
            if (converter != null)
            {
                value = converter.ConvertBack(value);
            }

            if (value != null)
            {
                setCallback.Invoke((T) value);
            }
            else
            {
                setCallback.Invoke(default);
            }
        }
    }
}