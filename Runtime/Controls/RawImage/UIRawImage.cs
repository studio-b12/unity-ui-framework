using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public class UIRawImage : UIRawImageBase
    {
        [SerializeField] private RawImage target;

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
                if (target.enabled != value)
                {
                    target.enabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public override Material Material
        {
            get => target.material;
            set 
            {
                if (target.material != value)
                {
                    target.material = value;
                    OnPropertyChanged();
                }
            }
        }

        public override Texture Texture
        {
            get => target.texture;
            set
            {
                if (target.texture != value)
                {
                    target.texture = value;
                    OnPropertyChanged();
                }
            }
        }

        public override Color Color
        {
            get => target.color;
            set
            {
                if (target.color != value)
                {
                    target.color = value;
                    OnPropertyChanged();
                }
            }
        }

        public override float Alpha
        {
            get => Color.a;
            set
            {
                if (!Mathf.Approximately(Color.a, value))
                {
                    var previousColor = Color;
                    previousColor.a = value;
                    Color = previousColor;
                    OnPropertyChanged();
                }
            }
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<RawImage>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<RawImage>();
            }
        }
#endif
    }
}