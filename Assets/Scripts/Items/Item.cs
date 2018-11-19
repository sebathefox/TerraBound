using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common.Registry;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{

    //TODO: Find a way to implement the items into the game
    public class Item : IObject
    {

        public Item(string uName)
        {
            this.UnlocalizedName = uName;
        }

        public static void InitItems()
        {
            Registry.Instance.ItemRegistry.Add(new KeyValuePair<string, Type>("item_beef", typeof(Item)));
        }

        public Image Image { get; set; }

        public int MaxStackSize { get; protected set; }

        public string UnlocalizedName { get; protected set; }
    }
}
