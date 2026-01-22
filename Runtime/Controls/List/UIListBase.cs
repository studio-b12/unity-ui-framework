using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rehawk.UIFramework
{
    public delegate void UIListItemCallbackDelegate(int index, GameObject item, object data);

    /// <summary>
    /// An abstract base class for managing dynamic UI lists.
    /// Provides functionality for handling items, managing item objects, and setting item-related strategies and callbacks.
    /// </summary>
    public abstract class UIListBase : UIControlBase
    {
        /// <summary>
        /// Represents a collection of items handled by the list.
        /// This property allows getting and setting the data source
        /// for the dynamic UI list, typically used for binding or data manipulation.
        /// </summary>
        public abstract IEnumerable Items { get; set; }

        /// <summary>
        /// Gets or sets the number of items in the UI list.
        /// This property is used to define or retrieve the count of items managed and displayed by the dynamic list.
        /// </summary>
        public abstract int Count { get; set; }

        /// <summary>
        /// Provides a read-only collection of GameObject instances representing the items
        /// currently managed by the dynamic UI list. This property facilitates access to
        /// the instantiated UI elements for the list, typically utilized for rendering or interaction purposes.
        /// </summary>
        public abstract IReadOnlyList<GameObject> ItemObjects { get; }

        /// <summary>
        /// Sets the strategy for managing and manipulating the items in the UI list.
        /// This method allows assigning an instance of a class implementing the <see cref="IUIListItemStrategy"/>
        /// interface to define custom behaviors for handling item objects and their lifecycle in the list.
        /// </summary>
        /// <param name="itemStrategy">An object implementing the <see cref="IUIListItemStrategy"/> interface,
        /// representing the desired item management strategy.</param>
        public abstract void SetItemStrategy(IUIListItemStrategy itemStrategy);

        /// <summary>
        /// Sets the type of item receiver to be used by the UI list.
        /// This method defines which implementation of the <see cref="IUIListItemReceiver"/> interface
        /// should be associated with the items in the list. The specified type determines how list items
        /// interact with their assigned receiver logic.
        /// </summary>
        /// <typeparam name="T">The type of the item receiver, which must implement <see cref="IUIListItemReceiver"/>.</typeparam>
        public abstract void SetItemReceiverType<T>() where T : IUIListItemReceiver;

        /// <summary>
        /// Sets a callback for handling specific list item events. This method assigns a delegate
        /// to be executed when the specified event type occurs for items in the UI list.
        /// </summary>
        /// <param name="type">The type of the list item event for which the callback should be registered.
        /// It specifies the stage in the item's lifecycle, such as <see cref="UIListItemCallback.Initialized"/> or others.</param>
        /// <param name="callback">The delegate to be executed when the specified event type is triggered.
        /// The delegate should accept the item's index, the associated <see cref="GameObject"/>, and any relevant data as parameters.</param>
        public abstract void SetItemCallback(UIListItemCallback type, UIListItemCallbackDelegate callback);
    }
}