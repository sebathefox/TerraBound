using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : IObject
    {
        public static List<Item> items = new List<Item>();

        public Item(string uName)
        {
            this.UnlocalizedName = uName;
        }

        public static void InitItems()
        {
            items.Add(new Item("kek"));
        }

        public Sprite Sprite { get; set; }

        public string UnlocalizedName { get; protected set; }
    }
}
