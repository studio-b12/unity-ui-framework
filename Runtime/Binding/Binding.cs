using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a binding mechanism between a source and a destination, with optional conversion and direction control.
    /// </summary>
    public class Binding
    {
        private IBindingStrategy sourceStrategy;
        private IBindingStrategy destinationStrategy;
        
        private IValueConverter converter;
        private BindingDirection direction;

        private readonly object parent;
        private readonly List<IBindingConnection> connections = new List<IBindingConnection>();
        private readonly List<string> tags = new List<string>();

        internal object Parent => parent;

        internal IReadOnlyList<string> Tags => tags;

        internal IBindingStrategy SourceStrategy => sourceStrategy;

        internal IBindingStrategy DestinationStrategy => destinationStrategy;

        internal IValueConverter Converter => converter;

        public event Action<ChangeOrigin> Changed;
            
        private Binding(object parent)
        {
            this.parent = parent;
        }

        internal void Release()
        {
            sourceStrategy?.Release();

            destinationStrategy?.Release();

            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].Release();
            }
        }
        
        internal void SetSource(IBindingStrategy strategy)
        {
            if (sourceStrategy != null)
            {
                sourceStrategy.GotDirty -= OnSourceGotDirty;
            }
            
            sourceStrategy = strategy;
            sourceStrategy.Evaluate();
            
            if (sourceStrategy != null)
            {
                sourceStrategy.GotDirty += OnSourceGotDirty;
            }
        }

        internal void SetDestination(IBindingStrategy strategy)
        {
            if (destinationStrategy != null)
            {
                destinationStrategy.GotDirty -= OnDestinationGotDirty;
            }
            
            destinationStrategy = strategy;
            destinationStrategy.Evaluate();
            
            if (destinationStrategy != null)
            {
                destinationStrategy.GotDirty += OnDestinationGotDirty;
            }
        }
        
        internal void SetConverter(IValueConverter converter)
        {
            this.converter = converter;
        }

        internal void SetDirection(BindingDirection direction)
        {
            this.direction = direction;
        }

        internal void Evaluate()
        {
            sourceStrategy.Evaluate();
            destinationStrategy.Evaluate();

            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].Evaluate();
            }
        }
        
        internal void SourceToDestination()
        {
            object value = sourceStrategy.Get();
            
            if (converter != null)
            {
                value = converter.Convert(value);
            }
            
            destinationStrategy.Set(value);
            
            Changed?.Invoke(ChangeOrigin.Source);
        }

        private void DestinationToSource()
        {
            object value = destinationStrategy.Get();
            
            if (converter != null)
            {
                value = converter.ConvertBack(value);
            }
            
            sourceStrategy.Set(value);
            
            Changed?.Invoke(ChangeOrigin.Destination);
        }

        internal void ConnectTo<T>(Expression<Func<T>> memberExpression, BindingConnectionDirection direction = BindingConnectionDirection.SourceToDestination)
        {
            var connectedProperty = new MemberConnection(() => parent, MemberPath.Get(memberExpression), direction);
            connectedProperty.Changed += () =>
            {
                OnBindingConnectionChanged(connectedProperty.Direction);
            };
            
            connections.Add(connectedProperty);
        }

        internal void ConnectTo(Func<INotifyPropertyChanged> getContextFunction, string propertyName, BindingConnectionDirection direction = BindingConnectionDirection.SourceToDestination)
        {
            var connectedProperty = new PropertyConnection(getContextFunction, propertyName, direction);
            connectedProperty.Changed += () =>
            {
                OnBindingConnectionChanged(connectedProperty.Direction);
            };
            
            connections.Add(connectedProperty);
        }

        internal void AddTags(params string[] tags)
        {
            this.tags.AddRange(tags);
        }

        private void OnSourceGotDirty()
        {
            SourceToDestination();
        }

        private void OnDestinationGotDirty()
        {
            if (direction == BindingDirection.TwoWay)
            {
                DestinationToSource();
            }
        }
        
        private void OnBindingConnectionChanged(BindingConnectionDirection direction)
        {
            switch (direction)
            {
                case BindingConnectionDirection.SourceToDestination:
                    Evaluate();
                    SourceToDestination();
                    break;
                case BindingConnectionDirection.DestinationToSource:
                    Evaluate();
                    DestinationToSource();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Creates a binding between a specified member of the given context and a parent object with the specified binding direction.
        /// </summary>
        /// <param name="parent">The object that will own the binding.</param>
        /// <param name="getContextFunction">A function that returns the context in which the binding member resides.</param>
        /// <param name="memberExpression">An expression that specifies the member to bind.</param>
        /// <param name="direction">The direction of the binding, either one-way or two-way.</param>
        /// <typeparam name="T">The type of the member being bound.</typeparam>
        /// <returns>A new binding object that represents the created binding.</returns>
        public static Binding BindMember<T>(object parent, Func<object> getContextFunction, Expression<Func<T>> memberExpression, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = new Binding(parent);

            binding.SetDestination(new MemberBindingStrategy(getContextFunction, MemberPath.Get(memberExpression)));
            binding.SetDirection(direction);
            
            return binding;
        }

        /// <summary>
        /// Creates a binding between a specified property of an object in a given context and a parent object with the specified binding direction.
        /// </summary>
        /// <param name="parent">The object that will own the binding.</param>
        /// <param name="getContextFunction">A function that returns the context in which the property resides.</param>
        /// <param name="propertyName">The name of the property to bind.</param>
        /// <param name="direction">The direction of the binding, either one-way or two-way.</param>
        /// <returns>A new binding object that represents the created binding.</returns>
        public static Binding BindProperty(object parent, Func<object> getContextFunction, string propertyName, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = new Binding(parent);

            binding.SetDestination(new ContextPropertyBindingStrategy(getContextFunction, propertyName));
            binding.SetDirection(direction);
            
            return binding;
        }

        /// <summary>
        /// Creates a binding between a specified context control and a parent object with the given binding direction.
        /// </summary>
        /// <param name="parent">The object that will own the binding.</param>
        /// <param name="getControlFunction">A function that retrieves the context control to bind to.</param>
        /// <param name="direction">The direction of the binding, either one-way or two-way.</param>
        /// <returns>A new binding object that represents the created binding.</returns>
        public static Binding BindContext(object parent, Func<UIContextControlBase> getControlFunction, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = new Binding(parent);

            binding.SetDestination(new ContextBindingStrategy(getControlFunction));
            binding.SetDirection(direction);

            return binding;
        }

        /// <summary>
        /// Creates a binding between a callback function and a parent object, allowing the callback to be invoked with specified data.
        /// </summary>
        /// <param name="parent">The object that will own the binding.</param>
        /// <param name="getFunction">A function that retrieves the value to be passed to the callback.</param>
        /// <param name="setCallback">The callback function to be invoked with the provided value.</param>
        /// <param name="direction">The direction of the binding, either one-way or two-way. Defaults to one-way.</param>
        /// <typeparam name="T">The type of the value used in the binding.</typeparam>
        /// <returns>A new binding object that represents the created callback binding.</returns>
        public static Binding BindCallback<T>(object parent, Action<T> setCallback)
        {
            return BindCallback<T>(parent, () => default, setCallback);
        }

        /// <summary>
        /// Creates a binding to a callback, allowing the binding system to invoke a specified callback function when data changes, with optional direction control.
        /// </summary>
        /// <param name="parent">The object that will own the binding.</param>
        /// <param name="getFunction">A function that retrieves the current value, used as the source in the binding.</param>
        /// <param name="setCallback">A callback function that accepts a value, invoked as the destination in the binding.</param>
        /// <param name="direction">The direction of the binding, either one-way or two-way. Defaults to one-way.</param>
        /// <typeparam name="T">The type of the value being passed to the callback.</typeparam>
        /// <returns>A new binding object representing the callback binding.</returns>
        public static Binding BindCallback<T>(object parent, Func<T> getFunction, Action<T> setCallback,
                                              BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = new Binding(parent);

            binding.SetDestination(new CallbackBindingStrategy<T>(getFunction, setCallback));
            binding.SetDirection(direction);
            
            return binding;
        }
    }
}