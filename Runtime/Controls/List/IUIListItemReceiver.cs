namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents an interface that defines the contract for receiving list item data
    /// in a UI list. Implementations of this interface should be a <see cref="UnityEngine.MonoBehaviour"/>
    /// and are received via GetComponent during the lifecycle of a list element.
    /// </summary>
    public interface IUIListItemReceiver
    {
        /// <summary>
        /// Sets the list item data for the implementing component.
        /// </summary>
        /// <param name="listItem">The <see cref="ListItem"/> containing the index and data associated with the list element.</param>
        void SetListItem(ListItem listItem);
    }
}