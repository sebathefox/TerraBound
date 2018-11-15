using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public static class SpriteLoader
    {
        public static Sprite GetSprite(string path)
        {
            return Resources.Load<Sprite>("Sprites/" + path);
        }
    }
}
