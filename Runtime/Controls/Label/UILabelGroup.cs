using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of UI labels that share common properties and behaviors.
    /// UILabelGroup provides a way to collectively manage multiple UI labels as a single entity.
    /// Updates to visibility, material, color, alpha, or other properties are propagated to all grouped labels.
    /// </summary>
    public class UILabelGroup : UILabelBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UILabelBase[] targets;

        private bool isEnabled;
        private bool isVisible;
        private Material material;
        private Color color;
        private float alpha;
        private string text;
        
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

        public override string Text
        {
            get => text;
            set 
            { 
                text = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Text = text;
                }
                
                OnPropertyChanged();
            }
        }

        public override void SetStrategy(IUILabelTextStrategy strategy)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].SetStrategy(strategy);
            }
        }
    }
}