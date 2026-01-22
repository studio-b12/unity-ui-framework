using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rehawk.UIFramework
{
    public interface IUIControl : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a binding between a property or field represented by the given expression and the current instance.
        /// The binding direction determines whether changes are tracked one-way or two-way.
        /// </summary>
        /// <typeparam name="T">The type of the property or field being bound.</typeparam>
        /// <param name="memberExpression">An expression representing the property or field to be bound.</param>
        /// <param name="direction">The direction of the binding. Defaults to one-way binding.</param>
        /// <returns>Returns a <see cref="Binding"/> object representing the created binding.</returns>
        Binding Bind<T>(Expression<Func<T>> memberExpression, BindingDirection direction = BindingDirection.OneWay);

        /// <summary>
        /// Creates a binding to a property specified by its name and resolves the property context dynamically through the provided context function.
        /// The binding allows tracking and synchronization of property changes based on the specified binding direction.
        /// </summary>
        /// <param name="getContext">A function providing the context object that contains the property to bind to.</param>
        /// <param name="propertyName">The name of the property to bind.</param>
        /// <param name="direction">The direction of the binding (e.g., OneWay or TwoWay). Defaults to OneWay binding.</param>
        /// <returns>Returns a <see cref="Binding"/> object representing the created binding.</returns>
        Binding BindProperty(Func<object> getContext, string propertyName,
                             BindingDirection direction = BindingDirection.OneWay);

        /// <summary>
        /// Binds the control context provided by the given callback function to the current instance,
        /// enabling data synchronization between the control context and the current instance based on the specified binding direction.
        /// </summary>
        /// <param name="getControlCallback">A function returning the control context to be bound.</param>
        /// <param name="direction">The direction of the binding, determining whether the synchronization is one-way or two-way. Defaults to one-way.</param>
        /// <returns>Returns a <see cref="Binding"/> object representing the created binding.</returns>
        Binding BindContext(Func<UIContextControlBase> getControlCallback,
                            BindingDirection direction = BindingDirection.OneWay);

        /// <summary>
        /// Creates a binding for a callback, allowing a value to be set through the specified callback action.
        /// This binding enables interaction between the current instance and external components or data.
        /// </summary>
        /// <typeparam name="T">The type of the value being bound and passed to the callback.</typeparam>
        /// <param name="setCallback">The callback action responsible for setting the value in the target binding.</param>
        /// <returns>Returns a <see cref="Binding"/> object representing the created binding.</returns>
        Binding BindCallback<T>(Action<T> setCallback);

        /// <summary>
        /// Creates a binding where a callback is triggered upon a change, enabling flexible handling of updates
        /// between the control and the bound data.
        /// </summary>
        /// <typeparam name="T">The type of the data value used in the binding.</typeparam>
        /// <param name="getCallback">A function used to retrieve the current value of the bound data.</param>
        /// <param name="setCallback">An action used to set or update the value of the bound data.</param>
        /// <returns>Returns a <see cref="Binding"/> instance representing the created callback binding.</returns>
        Binding BindCallback<T>(Func<T> getCallback, Action<T> setCallback);

        /// <summary>
        /// Marks the current control and its bindings as needing to be refreshed or updated.
        /// This method is commonly used to invalidate the state of the bindings, ensuring they
        /// are re-evaluated and properly synchronized during the next update cycle.
        /// </summary>
        void SetDirty();
    }

    /// <summary>
    /// Provides a base implementation for UI controls.
    /// This class is designed to manage UI component behavior, bindings, and notify upon property changes.
    /// </summary>
    public abstract class UIControlBase : UIBehaviour, IUIControl
    {
        private UIPanel parentPanel;
        
        private readonly List<Binding> bindings = new List<Binding>();
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void Awake()
        {
            base.Awake();
            
            parentPanel = GetComponentInParent<UIPanel>();

            if (parentPanel)
            {
                parentPanel.BecameVisible += OnPanelBecameVisible;
                parentPanel.BecameInvisible += OnPanelBecameInvisible;
            }
        }

        protected override void Start()
        {
            base.Start();
            
            SetupBindingsInternal();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            if (parentPanel)
            {
                parentPanel.BecameVisible -= OnPanelBecameVisible;
                parentPanel.BecameInvisible -= OnPanelBecameInvisible;
            }

            ReleaseBindings();
        }
        
        protected override void OnTransformParentChanged()
        {
            base.OnTransformParentChanged();

            if (parentPanel)
            {
                parentPanel.BecameVisible -= OnPanelBecameVisible;
                parentPanel.BecameInvisible -= OnPanelBecameInvisible;
            }
            
            parentPanel = GetComponentInParent<UIPanel>();
            
            if (parentPanel)
            {
                parentPanel.BecameVisible += OnPanelBecameVisible;
                parentPanel.BecameInvisible += OnPanelBecameInvisible;
            }
        }
        
        private void SetupBindingsInternal()
        {
            SetupBindings();
            SetDirty();
        }
        
        protected virtual void SetupBindings() { }
        
        public Binding Bind<T>(Expression<Func<T>> memberExpression, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = Binding.BindMember(this, () => this, memberExpression, direction);
            
            bindings.Add(binding);
            
            return binding;
        }

        public Binding BindProperty(Func<object> getContext, string propertyName, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = Binding.BindProperty(this, getContext, propertyName, direction);
            
            bindings.Add(binding);
            
            return binding;
        }

        public Binding BindContext(Func<UIContextControlBase> getControlCallback, BindingDirection direction = BindingDirection.OneWay)
        {
            var binding = Binding.BindContext(this, getControlCallback, direction);
            
            bindings.Add(binding);
            
            return binding;
        }
        
        public Binding BindCallback<T>(Action<T> setCallback)
        {
            var binding = Binding.BindCallback<T>(this, () => default, setCallback);
            
            bindings.Add(binding);
            
            return binding;
        }
        
        public Binding BindCallback<T>(Func<T> getCallback, Action<T> setCallback)
        {
            var binding = Binding.BindCallback<T>(this, getCallback, setCallback);
            
            bindings.Add(binding);
            
            return binding;
        }
        
        [ContextMenu("Set Dirty")]
        public void SetDirty()
        {
            for (int i = 0; i < bindings.Count; i++)
            {
                bindings[i].Evaluate();
                bindings[i].SourceToDestination();
            }
        }

        /// <summary>
        /// Marks bindings associated with the specified tags as dirty, causing them to be re-evaluated.
        /// </summary>
        /// <param name="tags">An array of tags used to identify which bindings should be marked as dirty.</param>
        protected void SetDirty(params string[] tags)
        {
            for (int i = 0; i < bindings.Count; i++)
            {
                if (bindings[i].Tags.Any(tag => tags.Contains(tag)))
                {
                    bindings[i].Evaluate();
                    bindings[i].SourceToDestination();
                }
            }
        }

        /// <summary>
        /// Called when the UI element or control parent panel becomes visible.
        /// This method can be overridden in derived classes to define custom behavior upon the control becoming visible.
        /// </summary>
        protected virtual void OnBecameVisible() {}

        /// <summary>
        /// Called when the UI element or control parent panel becomes invisible.
        /// This method can be overridden in derived classes to define custom behavior upon the control becoming invisible.
        /// </summary>
        protected virtual void OnBecameInvisible() {}
        
        private void ReleaseBindings()
        {
            for (int i = 0; i < bindings.Count; i++)
            {
                bindings[i].Release();
            }
        }
        
        private void OnPanelBecameVisible(UIPanel panel)
        {
            OnBecameVisible();
        }

        private void OnPanelBecameInvisible(UIPanel panel)
        {
            OnBecameInvisible();
        }

        /// <summary>
        /// Notifies listeners that a property value has changed.
        /// This method invokes the <see cref="PropertyChanged"/> event with the provided property name.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property that changed. This parameter is optional and can be automatically
        /// populated with the caller member name if not provided.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates the specified field with a new value if it differs from the current value. Raises the <see cref="PropertyChanged"/> event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the field to be updated.</typeparam>
        /// <param name="field">A reference to the field being updated.</param>
        /// <param name="value">The new value to set to the field.</param>
        /// <param name="propertyName">The name of the property invoking this method, automatically provided if called from a property setter.</param>
        /// <returns>Returns true if the field value was updated, otherwise returns false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            
            return true;
        }
    }
}