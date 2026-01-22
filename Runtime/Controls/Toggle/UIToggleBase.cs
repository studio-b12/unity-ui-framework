namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for toggleable UI elements. This abstract class provides a mechanism
    /// for managing a toggle's value as well as common properties shared by interactable UI elements.
    /// </summary>
    public abstract class UIToggleBase : UIValueInteractableBase
    {
        /// <summary>
        /// Gets or sets the value of the toggle. This property represents the on/off state of the toggleable UI element.
        /// </summary>
        public abstract bool Value { get; set; }
    }
}