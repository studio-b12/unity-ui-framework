using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a connection within a data binding system, facilitating data flow between source and destination
    /// as determined by the specified direction. Implementations of this interface define how the connection is
    /// managed and how changes are tracked or propagated.
    /// </summary>
    public interface IBindingConnection
    {
        /// <summary>
        /// Occurs when the state of the binding connection changes, such as when data is updated
        /// or propagated in the binding system.
        /// </summary>
        event Action Changed;

        /// <summary>
        /// Gets the direction of the data binding connection, indicating whether data flows
        /// from source to destination, destination to source, or both, as defined by the
        /// <see cref="BindingConnectionDirection"/> enumeration.
        /// </summary>
        BindingConnectionDirection Direction { get; }

        /// <summary>
        /// Re-evaluates the state of the binding connection. This method updates the connection
        /// to ensure that it reflects the current state of the underlying data, context, or member path.
        /// </summary>
        void Evaluate();

        /// <summary>
        /// Releases resources or handlers associated with the binding connection. This method is invoked to clean up
        /// or detach the connection, ensuring that any references to the underlying data, event handlers,
        /// </summary>
        void Release();
    }
}