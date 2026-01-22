namespace Rehawk.UIFramework
{
    public static class BindingCombinerExtensions
    {
        /// <summary>
        /// Combines a binding using a specified function for value conversion.
        /// </summary>
        /// <param name="binding">The binding instance to be combined.</param>
        /// <param name="valueConverter">A delegate that specifies the function used to convert multiple values into a single result.</param>
        /// <returns>The modified binding with the function-based combiner applied.</returns>
        public static Binding CombineByFunction(this Binding binding, MultiValueConvertFunctionDelegate valueConverter)
        {
            return binding.CombineBy(new FunctionCombiner(valueConverter));
        }

        /// <summary>
        /// Combines a binding using a specified string format to produce a formatted result from multiple inputs.
        /// </summary>
        /// <param name="binding">The binding instance to be combined.</param>
        /// <param name="format">The string format to be applied, which determines how the combined values are presented.</param>
        /// <returns>The modified binding with the format-based combiner applied.</returns>
        public static Binding CombineByFormat(this Binding binding, string format)
        {
            return binding.CombineBy(new StringFormatCombiner(format));
        }

        /// <summary>
        /// Combines a binding using a specified value combiner.
        /// </summary>
        /// <param name="binding">The binding instance to be combined.</param>
        /// <param name="valueCombiner">An implementation of <see cref="IValueCombiner"/> that specifies the logic for combining or dividing values.</param>
        /// <returns>The modified binding with the specified combiner applied.</returns>
        public static Binding CombineBy(this Binding binding, IValueCombiner valueCombiner)
        {
            MultiBindingStrategy multiBindingStrategy = MultiBindingHelper.ReplaceSourceWithMultiBindingStrategy(binding);
            
            multiBindingStrategy.SetCombiner(valueCombiner);

            return binding;
        }
    }
}