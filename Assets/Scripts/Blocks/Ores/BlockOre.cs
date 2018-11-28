using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Blocks.Ores
{
    public class BlockOre : Block
    {

        void Start()
        {
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Blocks/stone");
            this.Hardness = 2.0f;
            this.MaxStackSize = 64;
            //Image = GetComponent<SpriteRenderer>().sprite;

            InvokeRepeating("UpdateOncePerSecond", 0f, 1.0f);
        }
    }
}
