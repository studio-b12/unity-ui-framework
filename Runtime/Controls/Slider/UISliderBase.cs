namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for UI sliders, providing core functionality for
    /// value-based interactive UI components.
    /// </summary>
    public abstract class UISliderBase : UIValueInteractableBase
    {
        /// <summary>
        /// Gets or sets the current value of the slider component. The value
        /// typically falls within the range defined by <c>MinValue</c> and <c>MaxValue</c>.
        /// </summary>
        public abstract float Value { get; set; }
        
        /// <summary>r
        /// Gets or sets the normalized value of the slider, representing the current
        /// slider's value as a percentage of the range between <c>MinValue</c> and <c>MaxValue</c>.
        /// </summary>
        public abstract float NormalizedValue { get; set; }

        /// <summary>
        /// Gets or sets the minimum value that the slider can represent. This value
        /// defines the lower boundary of the slider's range and is used in conjunction
        /// with <c>MaxValue</c> to establish the slider's allowable limits.
        /// </summary>
        public abstract float MinValue { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowable value of the slider component.
        /// The value defines the upper limit of the slider's range and can
        /// be adjusted dynamically at runtime.
        /// </summary>
        public abstract float MaxValue { get; set; }
    }
}