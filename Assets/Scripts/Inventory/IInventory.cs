using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using Assets.Scripts.Items;

namespace Assets.Scripts.Inventory
{
    public interface IInventory
    {
        void Add(ItemStack item, int position);

        ItemStack Remove(int amount, int position);
    }
}
