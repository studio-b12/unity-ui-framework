using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public class UIScrollRectGroup : UIScrollRectBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIScrollRectBase[] targets;

        private bool isVisible;
        private bool isEnabled;
        private bool horizontal;
        private bool vertical;
        private ScrollRect.MovementType movementType;
        private float elasticity;
        private bool inertia;
        private float decelerationRate;
        private float scrollSensitivity;
        private ScrollRect.ScrollbarVisibility horizontalScrollbarVisibility;
        private ScrollRect.ScrollbarVisibility verticalScrollbarVisibility;
        private float horizontalScrollbarSpacing;
        private float verticalScrollbarSpacing;
        private Vector2 normalizedPosition;
        private float horizontalNormalizedPosition;
        private float verticalNormalizedPosition;
        private Vector2 velocity;
        private ICommand changedCommand;

        public override bool IsVisible
        {
            get => isVisible;
            set
            {
                isVisible = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].IsVisible = isVisible;

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
                    targets[i].Enabled = isEnabled;

                OnPropertyChanged();
            }
        }

        public override bool Horizontal
        {
            get => horizontal;
            set
            {
                horizontal = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].Horizontal = horizontal;

                OnPropertyChanged();
            }
        }

        public override bool Vertical
        {
            get => vertical;
            set
            {
                vertical = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].Vertical = vertical;

                OnPropertyChanged();
            }
        }

        public override ScrollRect.MovementType MovementType
        {
            get => movementType;
            set
            {
                movementType = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].MovementType = movementType;

                OnPropertyChanged();
            }
        }

        public override float Elasticity
        {
            get => elasticity;
            set
            {
                elasticity = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].Elasticity = elasticity;

                OnPropertyChanged();
            }
        }

        public override bool Inertia
        {
            get => inertia;
            set
            {
                inertia = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].Inertia = inertia;

                OnPropertyChanged();
            }
        }

        public override float DecelerationRate
        {
            get => decelerationRate;
            set
            {
                decelerationRate = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].DecelerationRate = decelerationRate;

                OnPropertyChanged();
            }
        }

        public override float ScrollSensitivity
        {
            get => scrollSensitivity;
            set
            {
                scrollSensitivity = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].ScrollSensitivity = scrollSensitivity;

                OnPropertyChanged();
            }
        }

        public override ScrollRect.ScrollbarVisibility HorizontalScrollbarVisibility
        {
            get => horizontalScrollbarVisibility;
            set
            {
                horizontalScrollbarVisibility = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].HorizontalScrollbarVisibility = horizontalScrollbarVisibility;

                OnPropertyChanged();
            }
        }

        public override ScrollRect.ScrollbarVisibility VerticalScrollbarVisibility
        {
            get => verticalScrollbarVisibility;
            set
            {
                verticalScrollbarVisibility = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].VerticalScrollbarVisibility = verticalScrollbarVisibility;

                OnPropertyChanged();
            }
        }

        public override float HorizontalScrollbarSpacing
        {
            get => horizontalScrollbarSpacing;
            set
            {
                horizontalScrollbarSpacing = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].HorizontalScrollbarSpacing = horizontalScrollbarSpacing;

                OnPropertyChanged();
            }
        }

        public override float VerticalScrollbarSpacing
        {
            get => verticalScrollbarSpacing;
            set
            {
                verticalScrollbarSpacing = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].VerticalScrollbarSpacing = verticalScrollbarSpacing;

                OnPropertyChanged();
            }
        }

        public override Vector2 NormalizedPosition
        {
            get => normalizedPosition;
            set
            {
                normalizedPosition = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].NormalizedPosition = normalizedPosition;

                OnPropertyChanged();
            }
        }

        public override float HorizontalNormalizedPosition
        {
            get => horizontalNormalizedPosition;
            set
            {
                horizontalNormalizedPosition = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].HorizontalNormalizedPosition = horizontalNormalizedPosition;

                OnPropertyChanged();
            }
        }

        public override float VerticalNormalizedPosition
        {
            get => verticalNormalizedPosition;
            set
            {
                verticalNormalizedPosition = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].VerticalNormalizedPosition = verticalNormalizedPosition;

                OnPropertyChanged();
            }
        }

        public override Vector2 Velocity
        {
            get => velocity;
            set
            {
                velocity = value;
                for (int i = 0; i < targets.Length; i++)
                    targets[i].Velocity = velocity;

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
                    targets[i].ChangedCommand = changedCommand;

                OnPropertyChanged();
            }
        }
    }
}
