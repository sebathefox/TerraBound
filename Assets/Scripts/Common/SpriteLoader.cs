using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Common
{
    /// <summary>
    /// Used for graphical asset handling.
    /// </summary>
    public static class SpriteLoader
    {
        /// <summary>
        /// Gets the sprite at the selected path in the sprites folder
        /// </summary>
        /// <param name="path">The name/path of the sprite</param>
        /// <returns>Returns the sprite if any</returns>
        public static Sprite GetSprite(string path)
        {
            return Resources.Load<Sprite>("Sprites/" + path);
        }

        public static Image GetImage(string path)
        {
            return Resources.Load<Image>("Sprites/" + path);
        }
    }
}
