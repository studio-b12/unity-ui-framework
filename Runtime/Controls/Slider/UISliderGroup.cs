using UnityEngine;

namespace Rehawk.UIFramework
{
    public class UISliderGroup : UISliderBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UISliderBase[] targets;
        
        private bool isVisible;
        private bool isEnabled;
        private bool isInteractable;
        private object boxedValue;
        private ICommand changedCommand;
        private float value;
        private float normalizedValue;
        private float minValue;
        private float maxValue;

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

        public override float Value
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

        public override float NormalizedValue
        {
            get => normalizedValue;
            set 
            { 
                normalizedValue = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].NormalizedValue = normalizedValue;
                }
                
                OnPropertyChanged();
            }
        }

        public override float MinValue
        {
            get => minValue;
            set 
            { 
                minValue = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].MinValue = minValue;
                }
                
                OnPropertyChanged();
            }
        }

        public override float MaxValue
        {
            get => maxValue;
            set 
            { 
                maxValue = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].MaxValue = maxValue;
                }
                
                OnPropertyChanged();
            }
        }
    }
}