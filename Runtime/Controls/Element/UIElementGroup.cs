using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a group of UI elements.
    /// The visibility state of this group is synchronized across all target UI elements.
    /// </summary>
    public class UIElementGroup : UIElementBase
    {
        [TextArea(1, 10)]
        [SerializeField] private string documentation;
        [SerializeField] private UIElementBase[] targets;

        private bool isEnabled;
        private bool isVisible;
        
        public override bool Enabled
        {
            get => isEnabled;
            set 
            { 
                isEnabled = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].Enabled = isEnabled;
                }
            }
        }
        
        public override bool IsVisible
        {
            get => isVisible;
            set 
            { 
                isVisible = value;
                for (int i = 0; i < targets.Length; i++)
                {
                    targets[i].IsVisible = isVisible;
                }
            }
        }
    }
}