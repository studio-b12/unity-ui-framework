namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for button components.
    /// It provides commands for handling button interaction events like clicking and hovering.
    /// </summary>
    public abstract class UIButtonBase : UIInteractableBase
    {
        /// <summary>
        /// Represents the command to execute when the associated UI button is clicked.
        /// This command can be bound to an implementation of <see cref="ICommand"/> to handle click events dynamically.
        /// </summary>
        /// <remarks>
        /// The <c>ClickCommand</c> is typically used to define interactive behavior within a UI component,
        /// allowing developers to specify custom logic that gets executed in response to click interactions.
        /// </remarks>
        public abstract ICommand ClickCommand { get; set; }

        /// <summary>
        /// Represents the command to execute when a pointer enters the associated UI element, initiating a hover interaction.
        /// This command can be bound to an implementation of <see cref="ICommand"/> to handle hover begin events dynamically.
        /// </summary>
        /// <remarks>
        /// The <c>HoverBeginCommand</c> is commonly used to define specific behaviors or logic that should be triggered
        /// when a user begins hovering over a UI element. It allows developers to implement custom hover interactions,
        /// enhancing the responsiveness and interactivity of the UI component.
        /// </remarks>
        public abstract ICommand HoverBeginCommand { get; set; }

        /// <summary>
        /// Represents the command to execute when a pointer ends hovering over the associated UI element.
        /// This command can be bound to an implementation of <see cref="ICommand"/> to dynamically handle the hover-end event.
        /// </summary>
        /// <remarks>
        /// The <c>HoverEndCommand</c> is typically used to define behavior that triggers when the hovering interaction on a UI element ends.
        /// Developers can leverage this command to execute custom logic, such as resetting visual states or triggering animations.
        /// </remarks>
        public abstract ICommand HoverEndCommand { get; set; }
    }
}