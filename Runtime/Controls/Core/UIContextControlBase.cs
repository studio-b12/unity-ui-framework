using System;
using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a UI control that manages a context object and provides methods for setting, retrieving, and managing the context.
    /// </summary>
    public interface IUIContextControl : IUIControl
    {
        /// <summary>
        /// Occurs when the context associated with this control is changed.
        /// </summary>
        /// <remarks>
        /// This event is triggered whenever the context object of the control is modified,
        /// typically through methods such as <c>SetContext</c> or <c>ClearContext</c>.
        /// Subscribing to this event allows responding to context updates or changes.
        /// </remarks>
        event Action ContextChanged;

        /// <summary>
        /// Gets a value indicating whether a context object is currently assigned to the control.
        /// </summary>
        /// <remarks>
        /// This property is used to determine the presence of an active context within the control.
        /// It returns <c>true</c> if a context is assigned; otherwise, <c>false</c>.
        /// </remarks>
        bool HasContext { get; }

        /// <summary>
        /// Gets the raw context object associated with the control.
        /// </summary>
        /// <remarks>
        /// The raw context represents the internal object used by the control. It can be any type of object and serves
        /// as the underlying data or state managed by the context control. This property facilitates access to the
        /// unmanaged or untyped context in scenarios where type-specific access is not required or applicable.
        /// </remarks>
        object RawContext { get; }

        /// <summary>
        /// Retrieves the current context object if it matches the specified type.
        /// </summary>
        /// <typeparam name="T">The expected type of the context object.</typeparam>
        /// <returns>The context object cast to the specified type, or the default value if the context is not of the specified type.</returns>
        T GetContext<T>();

        /// <summary>
        /// Attempts to retrieve the current context object if it matches the specified type.
        /// </summary>
        /// <typeparam name="T">The expected type of the context object.</typeparam>
        /// <param name="context">When this method returns, contains the context object cast to the specified type if the cast is successful; otherwise, contains the default value of the type.</param>
        /// <returns>True if the context is successfully cast to the specified type; otherwise, false.</returns>
        bool TryGetContext<T>(out T context);

        /// <summary>
        /// Sets the context object for this control to the specified value.
        /// </summary>
        /// <typeparam name="T">The type of the context object to be set.</typeparam>
        /// <param name="context">The new context object to assign to this control.</param>
        void SetContext<T>(T context);

        /// <summary>
        /// Clears the context object for this control by setting it to null.
        /// </summary>
        void ClearContext();
    }

    /// <summary>
    /// Serves as a base class for UI controls that manage and manipulate a context object,
    /// providing common functionality for managing the context lifecycle and interacting with other components.
    /// </summary>
    public abstract class UIContextControlBase : UIControlBase, IUIContextControl
    {
        public event Action ContextChanged;

        public bool HasContext => RawContext != null;

        public object RawContext { get; private set; }

        public T GetContext<T>()
        {
            if (RawContext is T castedContext)
            {
                return castedContext;
            }

            return default;
        }

        public bool TryGetContext<T>(out T context)
        {
            if (RawContext is T castedValue)
            {
                context = castedValue;
                return true;
            }

            context = default;
            
            return false;
        }

        public void SetContext<T>(T context)
        {
            BeforeContextChanged();

            RawContext = context;

            AfterContextChanged();

            SetDirty();

            ContextChanged?.Invoke();
        }

        public void ClearContext()
        {
            SetContext<object>(null);
        }

        /// <summary>
        /// Invoked before the current context is changed. This method provides a hook for derived classes
        /// to implement logic that needs to occur before modifying the context object.
        /// </summary>
        protected virtual void BeforeContextChanged() {}

        /// <summary>
        /// Executed after the context object has been updated. This method serves as a lifecycle hook,
        /// allowing derived classes to handle any necessary operations or adjustments in response to changes in the context.
        /// Can be overridden to implement custom behavior after the context is changed.
        /// </summary>
        protected virtual void AfterContextChanged() {}
    }
    
    public interface IUIContextControl<out T> : IUIContextControl
    {
        /// <summary>
        /// Gets the context object associated with the control, strongly-typed to the specified context type.
        /// </summary>
        /// <remarks>
        /// This property provides access to the context object of the control. The context type is determined by the generic type parameter
        /// defined in the implementation. Accessing this property allows retrieval of the associated context in its strongly-typed form,
        /// enabling type-safe operations specific to the context type.
        /// The context must be set and compatible with the specified type; otherwise, accessing this property may result in an exception
        /// or an unexpected default behavior, depending on the implementation.
        /// </remarks>
        T Context { get; }

        /// <summary>
        /// Gets the base type of the context managed by the control.
        /// </summary>
        /// <remarks>
        /// This property provides the base <see cref="Type"/> of the context associated with the control, as defined during the control implementation.
        /// It is useful for determining the expected type of the context without directly retrieving it.
        /// </remarks>
        Type ContextBaseType { get; }
    }

    public abstract class UIContextControlBase<T> : UIContextControlBase, IUIContextControl<T>
    {
        public T Context { get; private set; }

        public Type ContextBaseType => typeof(T);

        protected override void AfterContextChanged()
        {
            base.AfterContextChanged();

            try
            {
                Context = (T) RawContext;
            }
            catch (InvalidCastException)
            {
                Debug.LogError($"Context was not of expected type. [expectedType={typeof(T)}, actualType={RawContext.GetType()}]");
            }
        }
    }
}