using System.Collections.Generic;
using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Defines the interface for a strategy to manage and manipulate UI list items.
    /// Implementations of this interface provide methods for handling the lifecycle of
    /// list item objects, including creation, updating, activation, deactivation, and removal.
    /// </summary>
    public interface IUIListItemStrategy
    {
        /// <summary>
        /// Gets a read-only list of GameObject instances that represent the item objects
        /// managed by the current UI list item strategy. These item objects are typically
        /// used to render and represent data in a UI list.
        /// </summary>
        IReadOnlyList<GameObject> ItemObjects { get; }

        /// <summary>
        /// Retrieves the GameObject associated with a specific index in the UI list.
        /// </summary>
        /// <param name="index">The zero-based index of the item to retrieve.</param>
        /// <returns>The GameObject associated with the specified index, or null if the index is out of range or the item does not exist.</returns>
        GameObject GetItemObject(int index);

        /// <summary>
        /// Assigns or updates the GameObject and its associated data at a specific index in the UI list.
        /// </summary>
        /// <param name="index">The zero-based index of the item to assign or update.</param>
        /// <param name="data">The data to associate with the GameObject at the specified index.</param>
        /// <returns>An ItemReport containing details about the updated or newly created GameObject.</returns>
        ItemReport SetItemObject(int index, object data);

        /// <summary>
        /// Assigns a GameObject to a specific index in the UI list and updates it with the provided data.
        /// </summary>
        /// <param name="index">The zero-based index where the GameObject should be placed within the list.</param>
        /// <param name="itemObject">The GameObject to be assigned and activated in the list.</param>
        /// <param name="data">The data used to update the GameObject at the specified index.</param>
        /// <returns>An ItemReport containing the GameObject and a flag indicating whether it is a new addition.</returns>
        ItemReport SetItemObject(int index, GameObject itemObject, object data);

        /// <summary>
        /// Creates a new UI list item object at the specified index and associates it with the provided data.
        /// </summary>
        /// <param name="index">The zero-based index at which the new item object will be added.</param>
        /// <param name="data">The data to associate with the newly created item object.</param>
        /// <returns>A report containing the created item object and a flag indicating whether it is newly created.</returns>
        ItemReport AddItemObject(int index, object data);

        /// <summary>
        /// Deactivates a specified UI list item object, typically by marking it as inactive
        /// and potentially moving it to a pool for reuse.
        /// </summary>
        /// <param name="itemObject">The GameObject representing the UI list item to be deactivated.</param>
        void DeactivateItemObject(GameObject itemObject);

        /// <summary>
        /// Removes all inactive GameObjects from the list of managed item objects.
        /// This method is used to clean up and remove any UI list item objects that are no longer active,
        /// ensuring that the list only retains currently active elements.
        /// </summary>
        void RemoveInactiveItemObjects();

        /// <summary>
        /// Removes all item GameObjects from the UI list, clearing the list of managed items.
        /// This operation will typically deactivate or destroy all associated GameObjects
        /// as part of the removal process.
        /// </summary>
        void RemoveAllItemObjects();
    }
}