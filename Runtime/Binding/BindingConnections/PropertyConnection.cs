using System;
using System.ComponentModel;

namespace Rehawk.UIFramework
{
    internal class PropertyConnection : IBindingConnection
    {
        private readonly Func<INotifyPropertyChanged> getContextFunction;
        private readonly string propertyName;

        private INotifyPropertyChanged context;
        
        public BindingConnectionDirection Direction { get; }

        public event Action Changed;
            
        public PropertyConnection(Func<INotifyPropertyChanged> getContextFunction, string propertyName, BindingConnectionDirection direction)
        {
            this.getContextFunction = getContextFunction;
            this.propertyName = propertyName;
            Direction = direction;
        }

        ~PropertyConnection()
        {
            context.PropertyChanged -= OnContextPropertyChanged;
        }

        public void Evaluate()
        {
            if (context != null)
            {
                context.PropertyChanged -= OnContextPropertyChanged;
            }
            
            context = getContextFunction?.Invoke();

            if (context != null)
            {
                context.PropertyChanged += OnContextPropertyChanged;
            }
        }

        public void Release() { }
        
        private void OnContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == propertyName)
            {
                Changed?.Invoke();
            }
        }
    }
}