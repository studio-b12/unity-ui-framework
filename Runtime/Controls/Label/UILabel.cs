using TMPro;
using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a user interface label component.
    /// This class extends the functionality of <see cref="UILabelBase"/> and wrappers the <see cref="TextMeshProUGUI"/> component.
    /// The label also supports a configurable text strategy to handle text setting and retrieval. For example to implement localization.
    /// </summary>
    public class UILabel : UILabelBase
    {
        [SerializeField] private TextMeshProUGUI target;
        
        private IUILabelTextStrategy strategy;

        public override bool Enabled
        {
            get => target.enabled;
            set 
            {
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

        public override Material Material
        {
            get => target.material;
            set
            {
                if (target.material == value) 
                    return;
                
                target.material = value;
                OnPropertyChanged();
            }
        }

        public override string Text
        {
            get => strategy.GetText(this);
            set
            {
                if (strategy.SetText(this, value))
                {
                    OnPropertyChanged();
                }
            }
        }

        public override Color Color
        {
            get => target.color;
            set
            {
                if (target.color == value)
                    return;
                
                target.color = value;
                OnPropertyChanged();
            }
        }

        public override float Alpha
        {
            get => target.alpha;
            set
            {
                if (!Mathf.Approximately(target.alpha, value))
                {
                    target.alpha = value;
                    OnPropertyChanged();
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            if (strategy == null)
            {
                SetStrategy(new DefaultTextStrategy());
            }
        }

        public override void SetStrategy(IUILabelTextStrategy strategy)
        {
            if (this.strategy != null)
            {
                this.strategy.TextChanged -= OnTextChanged;
            }
            
            this.strategy = strategy;
            
            if (this.strategy != null)
            {
                this.strategy.TextChanged += OnTextChanged;
            }
        }

        private void OnTextChanged(string text)
        {
            target.text = text;
        }

#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<TextMeshProUGUI>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<TextMeshProUGUI>();
            }
        }
#endif
    }
}