using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for all graphical UI elements.
    /// This abstract class provides foundational functionality for rendering and
    /// controlling graphic properties such as material, color, alpha transparency,
    /// and enablement state.
    /// </summary>
    public abstract class UIGraphicBase : UIElementBase
    {
        public abstract Material Material { get; set; }
        public abstract Color Color { get; set; }
        public abstract float Alpha { get; set; }
    }
}