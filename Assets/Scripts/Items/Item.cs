using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : IObject
    {

        public Sprite Sprite { get; set; }

        public string UnlocalizedName { get; protected set; }
    }
}
