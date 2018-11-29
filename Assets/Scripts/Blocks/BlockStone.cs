using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common.Static;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockStone : Block
    {
        void Start()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Blocks/stone");
            this.Hardness = 1.0f;
            this.UnlocalizedName = "stone";
            this.MaxStackSize = StaticData.DefaultStackMaxSize;
            Image = GetComponent<SpriteRenderer>().sprite;

            InvokeRepeating("UpdateOncePerSecond", 0f, 1.0f);
        }
    }
}
