using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items.Tools
{
    public class Pickaxe : IObject, ITool
    {
        public Pickaxe()
        {
            Durability = 100f;
            MiningLevel = 1.0f;
            ToolXp = 0.0f;
            ToolSpeed = 1.2f;
            Image = Resources.Load<Sprite>("Sprites/Items/pick");
            MaxStackSize = 1;
            UnlocalizedName = "iron_pickaxe";
        }

        public float Durability { get; set; }
        public float MiningLevel { get; protected set; }
        public float ToolXp { get; protected set; }
        public float ToolSpeed { get; protected set; }
        public Sprite Image { get; set; }
        public int MaxStackSize { get; private set; }
        public string UnlocalizedName { get; private set; }
    }
}
