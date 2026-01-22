namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for all UI elements.
    /// This class provides common functionality for managing the visibility of UI elements.
    /// </summary>
    public abstract class UIElementBase : UIControlBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether the element is enabled.
        /// </summary>
        public abstract bool Enabled { get; set; }
        
        /// <summary>
        /// Gets or sets the visibility state of the UI element.
        /// </summary>
        /// <remarks>
        /// When set to true, the UI element is visible; when set to false, the UI element is hidden.
        /// Implementing types may propagate this visibility state to their child elements or associated targets.
        /// Changing this property may trigger additional actions, such as updating the visual state or notifying listeners.
        /// </remarks>
        public abstract bool IsVisible { get; set; }
    }
}