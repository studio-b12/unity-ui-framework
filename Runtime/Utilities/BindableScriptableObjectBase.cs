using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// An abstract base class for ScriptableObject that implements
    /// the INotifyPropertyChanged interface. This class provides
    /// functionality to signal changes in the properties of the derived
    /// classes, supporting data binding and ensuring UI updates
    /// when property values are modified.
    /// </summary>
    public abstract class BindableScriptableObjectBase : ScriptableObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event to notify subscribers of a change to a property's value.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property that changed. This parameter is optional and will
        /// default to the caller's member name if not provided.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates the backing field with a new value if it is different from the current value and raises the PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the field and value.</typeparam>
        /// <param name="field">A reference to the backing field to be updated.</param>
        /// <param name="value">The new value to be assigned to the field.</param>
        /// <param name="propertyName">The name of the property that has changed. If not provided, the caller member name will be used automatically.</param>
        /// <returns>True if the field was updated; otherwise, false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }
    }
}