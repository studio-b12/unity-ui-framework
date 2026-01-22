using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public class UISlider : UISliderBase
    {
        [SerializeField] private Slider target;
        
        private ICommand changedCommand;

        public override bool IsVisible
        {
            get => gameObject.activeSelf;
            set 
            {
                gameObject.SetActive(value);
                OnPropertyChanged();
            }
        }

        public override bool Enabled
        {
            get => target.enabled;
            set 
            {
                target.enabled = value;
                OnPropertyChanged();
            }
        }

        public override bool IsInteractable
        {
            get => target.interactable;
            set
            {
                target.interactable = value;
                OnPropertyChanged();
            }
        }

        public override float Value
        {
            get => target.value;
            set => target.value = value;
        }

        public override object BoxedValue
        {
            get => target.value;
            set
            {
                if (value != null && float.TryParse(value.ToString(), out float floatValue))
                {
                    target.value = floatValue;
                }
                else
                {
                    target.value = 0f;
                }
            }
        }

        public override float NormalizedValue
        {
            get => target.normalizedValue;
            set => target.normalizedValue = value;
        }

        public override float MinValue
        {
            get => target.minValue;
            set 
            {
                if (!Mathf.Approximately(target.minValue, value))
                {
                    target.minValue = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NormalizedValue));
                } 
            }
        }

        public override float MaxValue
        {
            get => target.maxValue;
            set 
            {
                if (!Mathf.Approximately(target.maxValue, value))
                {
                    target.maxValue = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(NormalizedValue));
                } 
            }
        }

        public override ICommand ChangedCommand
        {
            get => changedCommand;
            set => SetField(ref changedCommand, value);
        }

        protected override void Awake()
        {
            base.Awake();

            if (target)
            {
                target.onValueChanged.AddListener(OnValueChanged);
            }
            
            IsInteractable = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (target)
            {
                target.onValueChanged.RemoveListener(OnValueChanged);
            }
        }

        private void OnValueChanged(float value)
        {
            OnPropertyChanged(nameof(Value));
            OnPropertyChanged(nameof(NormalizedValue));
            
            if (ChangedCommand != null && ChangedCommand.CanExecute(null))
            {
                ChangedCommand?.Execute(value);
            }
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<Slider>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<Slider>();
            }
        }
#endif
    }
}