using System;

namespace Rehawk.UIFramework
{
    public static class BindingOnChangedExtensions
    {
        /// <summary>
        /// Registers a callback to be invoked whenever the binding's state changes.
        /// </summary>
        /// <param name="binding">The binding on which the change event is monitored.</param>
        /// <param name="callback">The action to invoke when the binding changes.</param>
        /// <returns>The same binding instance, allowing for chaining of operations.</returns>
        public static Binding OnChanged(this Binding binding, Action callback)
        {
            binding.Changed += _ =>
            {
                callback.Invoke();
            };
            
            return binding;
        }

        /// <summary>
        /// Registers a callback to be invoked whenever the binding's state changes due to the specified origin.
        /// </summary>
        /// <param name="binding">The binding on which the change event is monitored.</param>
        /// <param name="origin">The origin of the change (source or destination) to monitor.</param>
        /// <param name="callback">The action to invoke when the binding changes for the specified origin.</param>
        /// <returns>The same binding instance, allowing for chaining of operations.</returns>
        public static Binding OnChanged(this Binding binding, ChangeOrigin origin, Action callback)
        {
            binding.Changed += changeOrigin =>
            {
                if (origin == changeOrigin)
                    callback.Invoke();
            };
            
            return binding;
        }
    }
}