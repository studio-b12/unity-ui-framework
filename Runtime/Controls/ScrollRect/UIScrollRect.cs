using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a scrollable UI element with customizable scrolling behavior.
    /// Inherits from <see cref="UIScrollRectBase"/> and provides implementation for properties and methods
    /// to manage the scrolling behavior of the associated RectTransform.
    /// </summary>
    public class UIScrollRect : UIScrollRectBase
    {
        [SerializeField] private ScrollRect target;
        
        private ICommand changedCommand;

        public override bool Enabled
        {
            get => target.enabled;
            set 
            {
                if (target.enabled == value) 
                    return;
                
                target.enabled = value;
                OnPropertyChanged();
            }
        }

        public override bool IsVisible
        {
            get => gameObject.activeSelf;
            set 
            {
                gameObject.SetActive(value);
                OnPropertyChanged();
            }
        }

        public override bool Horizontal
        {
            get => target.horizontal;
            set
            {
                if (target.horizontal == value) 
                    return;

                target.horizontal = value;
                OnPropertyChanged();
            }
        }

        public override bool Vertical
        {
            get => target.vertical;
            set
            {
                if (target.vertical == value) 
                    return;

                target.vertical = value;
                OnPropertyChanged();
            }
        }

        public override float ScrollSensitivity
        {
            get => target.scrollSensitivity;
            set
            {
                if (Mathf.Approximately(target.scrollSensitivity, value)) 
                    return;

                target.scrollSensitivity = value;
                OnPropertyChanged();
            }
        }

        public override Vector2 NormalizedPosition
        {
            get => target.normalizedPosition;
            set
            {
                if (target.normalizedPosition == value) 
                    return;

                target.normalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override float HorizontalNormalizedPosition
        {
            get => target.horizontalNormalizedPosition;
            set
            {
                if (Mathf.Approximately(target.horizontalNormalizedPosition, value)) 
                    return;

                target.horizontalNormalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override float VerticalNormalizedPosition
        {
            get => target.verticalNormalizedPosition;
            set
            {
                if (Mathf.Approximately(target.verticalNormalizedPosition, value)) 
                    return;

                target.verticalNormalizedPosition = value;
                OnPropertyChanged();
            }
        }

        public override Vector2 Velocity
        {
            get => target.velocity;
            set
            {
                if (target.velocity == value) 
                    return;

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