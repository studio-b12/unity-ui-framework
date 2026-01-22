using UnityEngine;

namespace Rehawk.UIFramework
{
    public class UIValueInteractableGroup : UIValueInteractableBase
    {
        [SerializeField] private UIValueInteractableBase[] targets;

        private bool isVisible;
        private bool isEnabled;
        private bool isInteractable;
        private object boxedValue;
        private ICommand changedCommand;
        
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
    }
}