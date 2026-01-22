using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of UI graphical elements that share unified properties.
    /// Any adjustments made to this group will propagate to all its target elements.
    /// </summary>
    public class UIGraphicGroup : UIGraphicBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIGraphicBase[] targets;

        private bool isEnabled;
        private bool isVisible;
        private Material material;
        private Color color;
        private float alpha;
        
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
                
                OnPropertyChanged();
            }
        }

        public override Material Material
        {
            get => material;
            set 
            { 
                material = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Material = material;
                }
                
                OnPropertyChanged();
            }
        }

        public override Color Color
        {
            get => color;
            set 
            { 
                color = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Color = color;
                }
                
                OnPropertyChanged();
            }
        }

        public override float Alpha
        {
            get => alpha;
            set 
            { 
                alpha = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Alpha = alpha;
                }
                
                OnPropertyChanged();
            }
        }
    }
}