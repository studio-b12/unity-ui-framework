namespace Rehawk.UIFramework
{
    /// <summary>
    /// Is used to inform a <see cref="IUIListItemReceiver"/> about their associated index and data. 
    /// </summary>
    public struct ListItem
    {
        public int Index { get; }
        public object Data { get; }

        public ListItem(int index, object data)
        {
            Index = index;
            Data = data;
        }
    }
}