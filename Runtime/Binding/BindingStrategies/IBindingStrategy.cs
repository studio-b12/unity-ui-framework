using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a strategy for binding data within the UI framework. Provides methods
    /// and events that allow evaluation, retrieval, modification, and release of binding data.
    /// </summary>
    public interface IBindingStrategy
    {
        /// <summary>
        /// Occurs when the binding strategy detects a change in the associated data or state.
        /// This event can be raised to signal that the binding data needs to be re-evaluated
        /// or updated within the UI framework.
        /// </summary>
        event Action GotDirty;

        /// <summary>
        /// Evaluates the current state of the binding strategy. This may involve
        /// processing or updating the related data or state depending on the specific implementation
        /// of the binding strategy. Calling this method ensures that the strategy is in sync with
        /// its data source and destination.
        /// </summary>
        void Evaluate();

        /// <summary>
        /// Releases any resources and associations held by the implementation.
        /// This may include unbinding events, clearing references, and performing
        /// cleanup logic specific to the binding strategy. Once invoked, the binding
        /// strategy may no longer function as expected unless reinitialized.
        /// </summary>
        void Release();

        /// <summary>
        /// Retrieves the current value bound by the binding strategy.
        /// This method fetches the data or state based on the specific implementation
        /// of the concrete binding strategy, which may involve data retrieval,
        /// computation, or processing.
        /// </summary>
        /// <returns>
        /// The value currently represented by the binding strategy.
        /// </returns>
        object Get();

        /// <summary>
        /// Updates the binding strategy with the provided value.
        /// The implementation defines how the given value is processed and applied to the bound data or state.
        /// </summary>
        /// <param name="value">The value to be set in the binding strategy.</param>
        void Set(object value);
    }
}