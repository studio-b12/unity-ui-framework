using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public abstract class UIScrollRectBase : UIElementBase
    {
        public abstract bool Enabled { get; set; }
        public abstract bool Horizontal { get; set; }
        public abstract bool Vertical { get; set; }
        public abstract ScrollRect.MovementType MovementType { get; set; }
        public abstract float Elasticity { get; set; }
        public abstract bool Inertia { get; set; }
        public abstract float DecelerationRate { get; set; }
        public abstract float ScrollSensitivity { get; set; }
        public abstract ScrollRect.ScrollbarVisibility HorizontalScrollbarVisibility { get; set; }
        public abstract ScrollRect.ScrollbarVisibility VerticalScrollbarVisibility { get; set; }
        public abstract float HorizontalScrollbarSpacing { get; set; }
        public abstract float VerticalScrollbarSpacing { get; set; }
        public abstract Vector2 NormalizedPosition { get; set; }
        public abstract float HorizontalNormalizedPosition { get; set; }
        public abstract float VerticalNormalizedPosition { get; set; }
        public abstract Vector2 Velocity { get; set; }
        public abstract ICommand ChangedCommand { get; set; }
    }
}