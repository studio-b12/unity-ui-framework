using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IUILabelTextStrategy"/> interface.
    /// This strategy handles the management and updates of text content for a <see cref="UILabelBase"/>.
    /// It provides a mechanism for setting and retrieving text while notifying listeners when the text changes.
    /// </summary>
    public class DefaultTextStrategy : IUILabelTextStrategy
    {
        private string text;

        public event Action<string> TextChanged;

        public string GetText(UILabelBase label)
        {
            return text;
        }

        public bool SetText(UILabelBase label, string value)
        {
            if (text != value)
            {
                text = value;
                
                TextChanged?.Invoke(value);
                
                return true;
            }

            return false;
        }
    }
}