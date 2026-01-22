namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for UI labels.
    /// This abstract class provides functionality for managing text content and text rendering strategies.
    /// </summary>
    public abstract class UILabelBase : UIGraphicBase
    {
        /// <summary>
        /// Gets or sets the text content of the UI label.
        /// This property manages the textual representation displayed by the UI label.
        /// </summary>
        public abstract string Text { get; set; }

        /// <summary>
        /// Sets the text management strategy for the label instance.
        /// The provided strategy determines how text content is retrieved and updated.
        /// </summary>
        /// <param name="strategy">The strategy object implementing <see cref="IUILabelTextStrategy"/> to manage text behavior for this label.</param>
        public abstract void SetStrategy(IUILabelTextStrategy strategy);
    }
}