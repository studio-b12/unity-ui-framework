using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for UI image components.
    /// Provides foundational functionality and properties specific to UI image rendering,
    /// including sprite handling, fill amount, and override sprite.
    /// </summary>
    public abstract class UIImageBase : UIGraphicBase
    {
        public abstract Sprite Sprite { get; set; }
        public abstract Sprite OverrideSprite { get; set; }

        public abstract float FillAmount { get; set; }
    }
}