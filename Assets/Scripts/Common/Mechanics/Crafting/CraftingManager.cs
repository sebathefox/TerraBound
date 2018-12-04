using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Common.Mechanics.Crafting
{
    public class CraftingManager
    {

        public void AddShaped()
        {
            Recipe furnace = new Recipe(false, new []{ 'x', 'x', 'x',
                                                       'x', ' ', 'x',
                                                       'x', 'x', 'x' },
                new KeyValuePair<char, GameObject>[] { new KeyValuePair<char, GameObject>('x', Registry.Registry.Instance.BlockRegistry[1]) });
        }

    }

    public struct Recipe
    {
        public Recipe(bool shapeless, char[] shape, KeyValuePair<char, GameObject>[] materials)
        {
            Shapeless = shapeless;
            Shape = shape;
            Materials = materials;
        }

        public bool Shapeless { get; private set; }

        public char[] Shape { get; private set; }

        public KeyValuePair<char, GameObject>[] Materials { get; private set; }
    }
}
