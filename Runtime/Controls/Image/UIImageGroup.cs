using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of UI images that are managed collectively, allowing for batch updates of properties such as visibility, enabling, material, color, alpha, and sprite configurations.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="UIImageBase"/> and provides an implementation to handle multiple UI elements simultaneously.
    /// Changes made to this group will be propagated to the individual elements in the group.
    /// </remarks>
    public class UIImageGroup : UIImageBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIImageBase[] targets;

        private bool isEnabled;
        private bool isVisible;
        private Material material;
        private Color color;
        private Sprite sprite;
        private Sprite overrideSprite;
        private float fillAmount;
        
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
            get => Color.a;
            set
            {
                var previousColor = Color;
                previousColor.a = value;
                Color = previousColor;
                OnPropertyChanged();
            }
        }

        public override Sprite Sprite
        {
            get => sprite;
            set 
            { 
                sprite = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Sprite = sprite;
                }
                
                OnPropertyChanged();
            }
        }

        public override Sprite OverrideSprite
        {
            get => overrideSprite;
            set
            {
                overrideSprite = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].OverrideSprite = overrideSprite;
                }
                
                OnPropertyChanged();
            }
        }

        public override float FillAmount
        {
            get => fillAmount;
            set 
            { 
                fillAmount = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].FillAmount = fillAmount;
                }
                
                OnPropertyChanged();
            }
        }
    }
}