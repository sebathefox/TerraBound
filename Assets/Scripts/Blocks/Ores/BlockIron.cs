using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Blocks.Ores
{
    public class BlockIron : Block
    {
        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/iron_ore");
            this.Hardness = 1.5f;
            this.UnlocalizedName = "ore_iron";
        }

        public static float NaturalSpawnChance
        {
            get { return 2f; }
            protected set {  }
        }
    }
}
