using System;
using System.Collections.Generic;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a strategy for managing multiple binding operations within the UI framework.
    /// This strategy allows the combination of multiple binding strategies and the manipulation
    /// of their combined values through a specified value combiner.
    /// </summary>
    public class MultiBindingStrategy : IBindingStrategy
    {
        private readonly List<IBindingStrategy> bindingStrategies = new List<IBindingStrategy>();

        private IValueCombiner valueCombiner;
        
        private object[] values;
        
        public event Action GotDirty;

        /// <summary>
        /// Sets the value combiner for the current multi-binding strategy.
        /// </summary>
        /// <param name="valueCombiner">An instance of <see cref="IValueCombiner"/> to combine or divide values.</param>
        /// <exception cref="NotSupportedException">
        /// Thrown if a value combiner has already been assigned to this strategy.
        /// </exception>
        public void SetCombiner(IValueCombiner valueCombiner)
        {
            if (this.valueCombiner != null)
            {
                throw new NotSupportedException("Setting multiple value combiners is not supported.");
            }
            
            this.valueCombiner = valueCombiner;
        }

        /// <summary>
        /// Adds a binding strategy to the current multi-binding strategy.
        /// </summary>
        /// <param name="bindingStrategy">An instance of <see cref="IBindingStrategy"/> to be added to the binding strategy collection.</param>
        public void AddBindingStrategy(IBindingStrategy bindingStrategy)
        {
            bindingStrategies.Add(bindingStrategy);
            bindingStrategy.GotDirty += OnBindingStrategyGotDirty;
            
            values = new object[bindingStrategies.Count];
        }

        public void Evaluate()
        {
            for (int i = 0; i < bindingStrategies.Count; i++)
            {
                bindingStrategies[i].Evaluate();
            }
        }

        public void Release()
        {
            for (int i = 0; i < bindingStrategies.Count; i++)
            {
                bindingStrategies[i].Release();
            }
        }

        public object Get()
        {
            for (int i = 0; i < bindingStrategies.Count; i++)
            {
                values[i] = bindingStrategies[i].Get();
            }

            return valueCombiner.Combine(values);
        }

        public void Set(object value)
        {
            values = valueCombiner.Divide(value);
            
            for (int i = 0; i < bindingStrategies.Count; i++)
            {
                bindingStrategies[i].Set(values[i]);
            }
        }
        
        private void OnBindingStrategyGotDirty()
        {
            GotDirty?.Invoke();
        }
        
        internal static void AddSourceStrategy(Binding binding, IBindingStrategy bindingStrategy)
        {
            if (binding.SourceStrategy == null)
            {
                binding.SetSource(bindingStrategy);
            }
            else if (binding.SourceStrategy is MultiBindingStrategy multiBindingStrategy)
            {
                multiBindingStrategy.AddBindingStrategy(bindingStrategy);
            }
            else
            {
                IBindingStrategy previousSourceStrategy = binding.SourceStrategy;
                
                multiBindingStrategy = new MultiBindingStrategy();
                multiBindingStrategy.AddBindingStrategy(previousSourceStrategy);
                multiBindingStrategy.AddBindingStrategy(bindingStrategy);

                binding.SetSource(multiBindingStrategy);
            }
        }

        internal static MultiBindingStrategy ReplaceSourceWithMultiBindingStrategy(Binding binding)
        {
            if (binding.SourceStrategy is MultiBindingStrategy multiBindingStrategy)
            {
                // Do nothing.
            }
            else if (binding.SourceStrategy != null)
            {
                IBindingStrategy previousSourceStrategy = binding.SourceStrategy;
                multiBindingStrategy = new MultiBindingStrategy();
                multiBindingStrategy.AddBindingStrategy(previousSourceStrategy);
                
                binding.SetSource(multiBindingStrategy);
            }
            else
            {
                multiBindingStrategy = new MultiBindingStrategy();
                
                binding.SetSource(multiBindingStrategy);
            }

            return multiBindingStrategy;
        }
        
        internal static void AddConverter(Binding binding, IValueConverter converter)
        {
            if (binding.Converter == null)
            {
                binding.SetConverter(converter);
            }
            else if (binding.Converter is MultiConverter multiConverter)
            {
                multiConverter.AddConverter(converter);
            }
            else
            {
                IValueConverter previousConverter = binding.Converter;
                
                multiConverter = new MultiConverter();
                multiConverter.AddConverter(previousConverter);
                multiConverter.AddConverter(converter);

                binding.SetConverter(multiConverter);
            }
        }
    }
}