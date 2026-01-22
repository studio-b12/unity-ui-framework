using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a UI element that manages a group of raw image objects.
    /// Inherits from <see cref="UIRawImageBase"/> and provides extended functionality
    /// to handle operations across a collection of targets.
    /// </summary>
    public class UIRawImageGroup : UIRawImageBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIRawImageBase[] targets;

        private bool isVisible;
        private bool isEnabled;
        private Material material;
        private Color color;
        private Texture texture;
        
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

        public override Texture Texture
        {
            get => texture;
            set 
            { 
                texture = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Texture = texture;
                }
                
                OnPropertyChanged();
            }
        }
    }
}