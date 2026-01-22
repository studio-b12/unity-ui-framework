namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for UI elements that are interactable.
    /// This abstract class provides properties to manage the enabled and interactable states of the UI element.
    /// </summary>
    public abstract class UIInteractableBase : UIElementBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the UI element or group of elements is interactable.
        /// </summary>
        /// <remarks>
        /// The <c>IsInteractable</c> property controls whether the UI element can respond to user interactions,
        /// such as clicks or hover events, based on its current state.
        /// </remarks>
        public abstract bool IsInteractable { get; set; }
    }
}