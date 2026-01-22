using UnityEngine;
using UnityEngine.UI;

namespace Rehawk.UIFramework
{
    public class UIImage : UIImageBase
    {
        [SerializeField] private Image target;

        public override bool IsVisible
        {
            get => target.gameObject.activeSelf;
            set 
            {
                target.gameObject.SetActive(value);
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
        
        public override Sprite Sprite
        {
            get => target.sprite;
            set
            {
                if (target.sprite != value)
                {
                    target.sprite = value;
                    OnPropertyChanged();
                }
            }
        }

        public override Sprite OverrideSprite
        {
            get => target.overrideSprite;
            set
            {
                if (target.overrideSprite != value)
                {
                    target.overrideSprite = value;
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

        public override float FillAmount
        {
            get => target.fillAmount;
            set
            {
                if (!Mathf.Approximately(target.fillAmount, value))
                {
                    target.fillAmount = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SetNativeSize()
        {
            target.SetNativeSize();    
        }
        
#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<Image>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<Image>();
            }
        }
#endif
    }
}