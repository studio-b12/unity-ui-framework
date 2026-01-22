namespace Rehawk.UIFramework
{
    public abstract class UIValueInteractableBase : UIInteractableBase
    {
        /// <summary>
        /// Gets or sets the value associated with the UI element in its boxed (object) form.
        /// This property allows for generalized interaction with the value of various UI components,
        /// decoupling the value's actual type from its usage.
        /// </summary>
        public abstract object BoxedValue { get; set; }

        /// <summary>
        /// Gets or sets the command that is triggered when the value of the UI element changes.
        /// This property facilitates handling of value change events by allowing assignment
        /// of a command to execute, streamlining interaction within the framework.
        /// </summary>
        public abstract ICommand ChangedCommand { get; set; }
    }
}