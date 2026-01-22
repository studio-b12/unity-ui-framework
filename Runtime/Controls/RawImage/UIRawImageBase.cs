using UnityEngine;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents the base class for UI elements that utilize a raw image.
    /// This abstract class extends from <see cref="UIGraphicBase"/>, and it provides
    /// functionality for handling textures in UI elements.
    /// </summary>
    public abstract class UIRawImageBase : UIGraphicBase
    {
        /// <summary>
        /// Gets or sets the texture used by the UI element.
        /// This property allows for defining or modifying the visual appearance
        /// of the underlying raw image component through a texture.
        /// </summary>
        public abstract Texture Texture { get; set; }
    }
}