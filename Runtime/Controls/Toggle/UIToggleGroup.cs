using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of toggleable UI elements that manage their state collectively.
    /// This class extends <see cref="UIToggleBase"/> and provides implementation for
    /// common toggle group features such as visibility, interactivity, and value handling.
    /// </summary>
    public class UIToggleGroup : UIToggleBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIToggleBase[] targets;
        
        private bool isVisible;
        private bool isEnabled;
        private bool isInteractable;
        private object boxedValue;
        private ICommand changedCommand;
        private bool value;

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
                
                OnPropertyChanged();
            }
        }

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
                
                OnPropertyChanged();
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
                
                OnPropertyChanged();
            }
        }

        public override object BoxedValue
        {
            get => boxedValue;
            set 
            { 
                boxedValue = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].BoxedValue = boxedValue;
                }
                
                OnPropertyChanged();
            }
        }

        public override ICommand ChangedCommand
        {
            get => changedCommand;
            set 
            { 
                changedCommand = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].ChangedCommand = changedCommand;
                }
                
                OnPropertyChanged();
            }
        }
        
        public override bool Value
        {
            get => value;
            set 
            { 
                this.value = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Value = this.value;
                }
                
                OnPropertyChanged();
            }
        }
    }
}