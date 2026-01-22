namespace Rehawk.UIFramework
{
    public static class BindingConverterExtensions
    {
        /// <summary>
        /// Applies a custom conversion to a binding using the specified conversion function.
        /// </summary>
        /// <param name="binding">The binding to which the conversion function will be applied.</param>
        /// <param name="converterFunction">The function that defines the custom conversion logic.</param>
        /// <returns>The modified binding with the applied conversion.</returns>
        public static Binding ConvertByFunction(this Binding binding, ValueConvertFunctionDelegate converterFunction)
        {
            var converter = new FunctionConverter(converterFunction);
            
            MultiConverterHelper.AddConverter(binding, converter);

            return binding;
        }

        /// <summary>
        /// Applies a typed custom conversion to a binding using the specified conversion function.
        /// </summary>
        /// <typeparam name="T">The type of value that the conversion function applies to.</typeparam>
        /// <param name="binding">The binding to which the conversion function will be applied.</param>
        /// <param name="converterFunction">The function that defines the custom conversion logic.</param>
        /// <returns>The modified binding with the applied conversion.</returns>
        public static Binding ConvertByFunction<T>(this Binding binding,
                                                   ValueConvertFunctionDelegate<T> converterFunction)
        {
            var converter = FunctionConverter.CreateTyped(converterFunction);

            MultiConverterHelper.AddConverter(binding, converter);

            return binding;
        }

        /// <summary>
        /// Converts the value of a binding to the specified type.
        /// </summary>
        /// <param name="binding">The binding whose value will be converted.</param>
        /// <typeparam name="T">The target type to which the binding value will be converted.</typeparam>
        /// <returns>The modified binding with the value converted to the specified type.</returns>
        public static Binding ConvertTo<T>(this Binding binding)
        {
            return binding.ConvertByFunction(input =>
            {
                if (input != null)
                {
                    return (T) input;
                }

                return default(T);
            });
        }

        /// <summary>
        /// Converts a binding to a Boolean representation with an optional inversion.
        /// </summary>
        /// <param name="binding">The binding to be converted to a Boolean.</param>
        /// <param name="invert">Specifies whether the resulting Boolean value should be inverted. Defaults to false.</param>
        /// <returns>The modified binding, converted to a Boolean value.</returns>
        public static Binding ConvertToBool(this Binding binding, bool invert = false)
        {
            return binding.ConvertBy(new BoolConverter(invert));
        }

        /// <summary>
        /// Converts the binding's value to a boolean that is inverted.
        /// </summary>
        /// <param name="binding">The binding whose value will be converted to an inverted boolean.</param>
        /// <returns>The modified binding with an inverted boolean conversion applied.</returns>
        public static Binding ConvertToInvertedBool(this Binding binding)
        {
            return binding.ConvertToBool(true);
        }

        /// <summary>
        /// Converts a binding to an integer value using the IntConverter.
        /// </summary>
        /// <param name="binding">The binding to be converted to an integer.</param>
        /// <returns>The modified binding with applied integer conversion logic.</returns>
        public static Binding ConvertToInt(this Binding binding)
        {
            return binding.ConvertBy(new IntConverter());
        }

        /// <summary>
        /// Converts the values in the specified binding to a float format using a predefined converter.
        /// </summary>
        /// <param name="binding">The binding object whose values will be converted to float.</param>
        /// <returns>The updated binding with values converted to float.</returns>
        public static Binding ConvertToFloat(this Binding binding)
        {
            return binding.ConvertBy(new FloatConverter());
        }

        /// <summary>
        /// Converts the binding value to a double type.
        /// </summary>
        /// <param name="binding">The binding to be converted to a double type.</param>
        /// <returns>The modified binding with double type conversion applied.</returns>
        public static Binding ConvertToDouble(this Binding binding)
        {
            return binding.ConvertBy(new DoubleConverter());
        }

        /// <summary>
        /// Converts the binding's value to its string representation.
        /// </summary>
        /// <param name="binding">The binding whose value will be converted to a string.</param>
        /// <returns>The modified binding with the applied string conversion.</returns>
        public static Binding ConvertToString(this Binding binding)
        {
            return binding.ConvertBy(new StringConverter());
        }

        /// <summary>
        /// Converts the binding's value to a string using the default conversion logic.
        /// </summary>
        /// <param name="binding">The binding whose value will be converted to a string.</param>
        /// <returns>The modified binding with the value converted to a string.</returns>
        public static Binding ConvertToString(this Binding binding, string format)
        {
            return binding.ConvertBy(new StringConverter(format));
        }

        /// <summary>
        /// Converts a binding's value to a date-time formatted string using the specified format.
        /// </summary>
        /// <param name="binding">The binding whose value will be converted to a date-time string.</param>
        /// <param name="format">The format string that determines the date-time formatting.</param>
        /// <returns>The binding with the date-time to string conversion applied.</returns>
        public static Binding ConvertToDateTimeString(this Binding binding, string format)
        {
            return binding.ConvertBy(new DateTimeToStringConverter(format));
        }

        /// <summary>
        /// Adds a value converter to the specified binding for custom value conversion logic.
        /// </summary>
        /// <param name="binding">The binding to which the converter will be applied.</param>
        /// <param name="converter">The value converter responsible for handling the conversion logic.</param>
        /// <returns>The updated binding with the specified converter applied.</returns>
        public static Binding ConvertBy(this Binding binding, IValueConverter converter)
        {
            MultiConverterHelper.AddConverter(binding, converter);
            
            return binding;
        }
    }
}