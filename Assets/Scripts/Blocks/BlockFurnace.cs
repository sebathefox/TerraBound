using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common.Static;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockFurnace : Block
    {
        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Blocks/furnace");
            this.Hardness = 1.5f;
            this.MaxStackSize = StaticData.DefaultStackMaxSize;
            Image = GetComponent<SpriteRenderer>().sprite;

            InvokeRepeating("UpdateOncePerSecond", 0f, 1.0f);
        }
    }
}
