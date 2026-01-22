namespace Rehawk.UIFramework
{
    public static class BindingTagsExtensions
    {
        /// <summary>
        /// Adds the specified tags to the binding.
        /// </summary>
        /// <param name="binding">The binding instance to which the tags will be added.</param>
        /// <param name="tags">An array of tags to be added to the binding.</param>
        /// <returns>The updated binding instance with the added tags.</returns>
        public static Binding WithTag(this Binding binding, params string[] tags)
        {
            binding.AddTags(tags);
            return binding;
        }
    }
}