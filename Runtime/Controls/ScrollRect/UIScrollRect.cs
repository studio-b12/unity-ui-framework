using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public class UIScrollRect : UIScrollRectBase
    {
        [SerializeField] private ScrollRect target;
        
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

        public override bool Horizontal
        {
            get => target.horizontal;
            set
            {
                target.horizontal = value;
                OnPropertyChanged();
            }
        }

        public override bool Vertical
        {
            get => target.vertical;
            set
            {
                target.vertical = value;
                OnPropertyChanged();
            }
        }

        public override ScrollRect.MovementType MovementType
        {
            get => target.movementType;
            set
            {
                target.movementType = value;
                OnPropertyChanged();
            }
        }

        public override float Elasticity
        {
            get => target.elasticity;
            set
            {
                target.elasticity = value;
                OnPropertyChanged();
            }
        }

        public override bool Inertia
        {
            get => target.inertia;
            set
            {
                target.inertia = value;
                OnPropertyChanged();
            }
        }

        public override float DecelerationRate
        {
            get => target.decelerationRate;
            set
            {
                target.decelerationRate = value;
                OnPropertyChanged();
            }
        }

        public override float ScrollSensitivity
        {
            get => target.scrollSensitivity;
            set
            {
                target.scrollSensitivity = value;
                OnPropertyChanged();
            }
        }

        public override ScrollRect.ScrollbarVisibility HorizontalScrollbarVisibility
        {
            get => target.horizontalScrollbarVisibility;
            set
            {
                target.horizontalScrollbarVisibility = value;
                OnPropertyChanged();
            }
        }

        public override ScrollRect.ScrollbarVisibility VerticalScrollbarVisibility
        {
            get => target.verticalScrollbarVisibility;
            set
            {
                target.verticalScrollbarVisibility = value;
                OnPropertyChanged();
            }
        }

        public override float HorizontalScrollbarSpacing
        {
            get => target.horizontalScrollbarSpacing;
            set
            {
                target.horizontalScrollbarSpacing = value;
                OnPropertyChanged();
            }
        }

        public override float VerticalScrollbarSpacing
        {
            get => target.verticalScrollbarSpacing;
            set
            {
                target.verticalScrollbarSpacing = value;
                OnPropertyChanged();
            }
        }

        public override Vector2 NormalizedPosition
        {
            get => target.normalizedPosition;
            set
            {
                target.normalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override float HorizontalNormalizedPosition
        {
            get => target.horizontalNormalizedPosition;
            set
            {
                target.horizontalNormalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override float VerticalNormalizedPosition
        {
            get => target.verticalNormalizedPosition;
            set
            {
                target.verticalNormalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override Vector2 Velocity
        {
            get => target.velocity;
            set
            {
                target.velocity = value;
                OnPropertyChanged();
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
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (target)
            {
                target.onValueChanged.RemoveListener(OnValueChanged);
            }
        }

        private void OnValueChanged(Vector2 _)
        {
            OnPropertyChanged(nameof(NormalizedPosition));
            OnPropertyChanged(nameof(HorizontalNormalizedPosition));
            OnPropertyChanged(nameof(VerticalNormalizedPosition));
            
            if (ChangedCommand != null && ChangedCommand.CanExecute(null))
            {
                ChangedCommand?.Execute(NormalizedPosition);
            }
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<ScrollRect>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<ScrollRect>();
            }
        }
#endif
    }
}