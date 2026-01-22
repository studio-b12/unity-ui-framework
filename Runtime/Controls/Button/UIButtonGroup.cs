using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of UI buttons that share common properties and behavior.
    /// </summary>
    /// <remarks>
    /// UIButtonGroup manages a collection of button targets, ensuring that their
    /// properties and commands are synchronized. This allows for collective control
    /// of visibility, state, and interactions within a group of buttons.
    /// </remarks>
    public class UIButtonGroup : UIButtonBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIButtonBase[] targets;
        
        private bool isEnabled;
        private bool isVisible;
        private bool isInteractable;
        private ICommand clickCommand;
        private ICommand hoverBeginCommand;
        private ICommand hoverEndCommand;

        public override bool Enabled
        {
            get => isEnabled;
            set 
            { 
                isEnabled = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Enabled = isEnabled;
                }
            }
        }

        public override bool IsVisible
        {
            get => isVisible;
            set 
            { 
                isVisible = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].IsVisible = isVisible;
                }
            }
        }

        public override bool IsInteractable
        {
            get => isInteractable;
            set 
            { 
                isInteractable = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].IsInteractable = isInteractable;
                }
            }
        }

        public override ICommand ClickCommand
        {
            get => clickCommand;
            set 
            { 
                clickCommand = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].ClickCommand = clickCommand;
                }
            }
        }

        public override ICommand HoverBeginCommand
        {
            get => hoverBeginCommand;
            set 
            { 
                hoverBeginCommand = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].HoverBeginCommand = hoverBeginCommand;
                }
            }
        }

        public override ICommand HoverEndCommand
        {
            get => hoverEndCommand;
            set 
            { 
                hoverEndCommand = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].HoverEndCommand = hoverEndCommand;
                }
            }
        }
    }
}