using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Rehawk.UIFramework
{
    public static class BindingConnectionExtensions
    {
        /// <summary>
        /// Reevaluates the binding when the provided property changes.
        /// </summary>
        /// <typeparam name="T">The type of the property to be monitored for changes.</typeparam>
        /// <param name="binding">The current binding object to be reevaluated when the specified property changes.</param>
        /// <param name="memberExpression">An expression that identifies the property to monitor for changes.</param>
        /// <param name="direction">The direction of the data binding connection (e.g., SourceToDestination or DestinationToSource).</param>
        public static Binding ReevaluateWhenChanged<T>(this Binding binding, Expression<Func<T>> memberExpression, BindingConnectionDirection direction = BindingConnectionDirection.SourceToDestination)
        {
            binding.ConnectTo(memberExpression, direction);
            
            return binding;
        }

        /// <summary>
        /// Reevaluates the binding when the provided property changes.
        /// </summary>
        /// <typeparam name="T">The type of the property to be monitored for changes.</typeparam>
        /// <param name="binding">The current binding object to be reevaluated when the specified property changes.</param>
        /// <param name="memberExpression">An expression that identifies the property to monitor for changes.</param>
        /// <param name="direction">The direction of the data binding connection (e.g., SourceToDestination or DestinationToSource).</param>
        /// <returns>The updated binding object with the configuration applied.</returns>
        public static Binding ReevaluateWhenChanged(this Binding binding, Func<INotifyPropertyChanged> getContextFunction, string propertyName, BindingConnectionDirection direction = BindingConnectionDirection.SourceToDestination)
        {
            binding.ConnectTo(getContextFunction, propertyName, direction);
            
            return binding;
        }
    }
}