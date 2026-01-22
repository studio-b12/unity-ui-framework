using TMPro;
using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a user interface text component.
    /// This class extends the functionality of <see cref="UIInputFieldBase"/> and wrappers the <see cref="TMP_InputField"/> component.
    /// </summary>
    public class UIInputField : UIInputFieldBase
    {
        [SerializeField] private TMP_InputField target;
        
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

        public override bool IsInteractable
        {
            get => target.interactable;
            set
            {
                if (target.interactable == value)
                    return;
                
                target.interactable = value;
                OnPropertyChanged();
            }
        }

        public override string Value
        {
            get => target.text;
            set => target.text = value;
        }

        public override object BoxedValue
        {
            get => target.text;
            set => target.text = value?.ToString();
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
            
            IsInteractable = true;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (target)
            {
                target.onValueChanged.RemoveListener(OnValueChanged);
            }
        }

        private void OnValueChanged(string text)
        {
            OnPropertyChanged(nameof(Value));
            
            if (ChangedCommand != null && ChangedCommand.CanExecute(null))
            {
                ChangedCommand?.Execute(text);
            }
        }
        
#if UNITY_EDITOR
        protected override void Reset()
        {
            base.Reset();
            
            if (target == null)
            {
                target = GetComponentInChildren<TMP_InputField>();
            }
        }

        protected override void OnValidate()
        {
            base.OnValidate();

            if (target == null)
            {
                target = GetComponentInChildren<TMP_InputField>();
            }
        }
#endif
    }
}