using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }
    }
}
