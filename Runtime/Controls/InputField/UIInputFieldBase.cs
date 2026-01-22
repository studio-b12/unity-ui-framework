namespace Rehawk.UIFramework
{
    /// <summary>
    /// Serves as an abstract base class for user interface input field components.
    /// This class extends <see cref="UIValueInteractableBase"/> to provide a framework for input fields
    /// where user interactions can modify a textual value.
    /// </summary>
    /// <remarks>
    /// Derived classes must implement the <see cref="Value"/> property, allowing for manipulation and retrieval
    /// of the input field's text content.
    /// </remarks>
    public abstract class UIInputFieldBase : UIValueInteractableBase
    {
        public abstract string Value { get; set; }
    }
}