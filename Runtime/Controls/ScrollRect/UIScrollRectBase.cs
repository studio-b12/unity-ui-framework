using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for a scrollable UI element in the UI Framework.
    /// This abstract class provides properties to configure and control scrolling behavior,
    /// such as direction, sensitivity, inertia, and elasticity.
    /// </summary>
    public abstract class UIScrollRectBase : UIElementBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether horizontal scrolling is enabled for the UI scroll rect element.
        /// </summary>
        public abstract bool Horizontal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the vertical scrolling is enabled for the UI scroll rect element.
        /// </summary>
        public abstract bool Vertical { get; set; }

        /// <summary>
        /// Gets or sets the sensitivity of scrolling for the UI scroll rect element.
        /// </summary>
        public abstract float ScrollSensitivity { get; set; }

        /// <summary>
        /// Gets or sets the normalized position of the scrollable content relative to its bounds.
        /// The value ranges from (0, 0) for the beginning to (1, 1) for the end of the scrollable area.
        /// </summary>
        public abstract Vector2 NormalizedPosition { get; set; }

        /// <summary>
        /// Gets or sets the horizontal scroll position as a normalized value between 0 and 1.
        /// </summary>
        public abstract float HorizontalNormalizedPosition { get; set; }

        /// <summary>
        /// Gets or sets the vertical normalized scroll position of the UI scroll rect element.
        /// The value is represented as a float between 0 and 1, where 0 indicates
        /// the topmost position and 1 indicates the bottommost position.
        /// </summary>
        public abstract float VerticalNormalizedPosition { get; set; }

        /// <summary>
        /// Gets or sets the current velocity of the scrolling movement, represented as a Vector2 value.
        /// </summary>
        public abstract Vector2 Velocity { get; set; }

        /// <summary>
        /// Gets or sets the command that is triggered when normalized position changes.
        /// </summary>
        public abstract ICommand ChangedCommand { get; set; }
    }
}