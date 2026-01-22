using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a strategy for binding a static value to the UI. Enables the encapsulation of a
    /// pre-defined value within the binding strategy, allowing retrieval and modification, as well
    /// as optional conversion through an associated value converter.
    /// </summary>
    public class StaticValueBindingStrategy : IBindingStrategy
    {
        private object value;
        private IValueConverter converter;

        public event Action GotDirty;

        public StaticValueBindingStrategy(object value)
        {
            this.value = value;
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
            object value = this.value;
            
            if (converter != null)
            {
                value = converter.Convert(value);
            }

            return value;
        }

        public void Set(object value)
        {
            if (converter != null)
            {
                value = converter.ConvertBack(value);
            }

            if (this.value == value) return;
            this.value = value;
            GotDirty?.Invoke();
        }
    }
}