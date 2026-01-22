using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Defines a strategy interface for managing and updating text content in UI label components.
    /// </summary>
    public interface IUILabelTextStrategy
    {
        /// <summary>
        /// An event that occurs when the text managed by the strategy changes.
        /// </summary>
        public event Action<string> TextChanged;

        /// <summary>
        /// Retrieves the text associated with a specified UI label.
        /// </summary>
        /// <param name="label">The UI label whose text is to be retrieved.</param>
        /// <returns>The text content of the specified UI label.</returns>
        string GetText(UILabelBase label);

        /// <summary>
        /// Sets the text content for the specified UI label.
        /// </summary>
        /// <param name="label">The UI label whose text is to be set.</param>
        /// <param name="value">The new text value to assign to the label and can be altered by the strategy.</param>
        /// <returns>A boolean indicating whether the text was successfully updated.</returns>
        bool SetText(UILabelBase label, string value);
    }
}