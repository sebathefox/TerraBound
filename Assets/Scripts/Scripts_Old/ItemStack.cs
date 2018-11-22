using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Common
{
    public class ItemStack
    {
        private Type item;
        private int amount;
        

        public ItemStack(Type obj)
        {
            this.item = obj;
        }

        public void SetAmount(int amount)
        {
            this.amount = amount;
        }

        public void AddAmount(int amount)
        {
            //if()
            this.amount += amount;
        }
    }
}
