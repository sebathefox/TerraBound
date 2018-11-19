using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Items;

namespace Assets.Scripts.Inventory
{
    /// <summary>
    /// A holder class for <see cref="Inventory"/> storage.
    /// </summary>
    public class ItemStack
    {
        /// <summary>
        /// The <see cref="IObject"/> to store a stack of.
        /// </summary>
        public IObject Item { get; set; }

        /// <summary>
        /// The amount of items to store.
        /// </summary>
        public int Amount { get; set; }

        public int AddAmount(int amount)
        {
            if (Item.MaxStackSize >= Amount + amount)
                this.Amount += amount;
            else if (Item.MaxStackSize < Amount + amount)
            {
                this.Amount = Item.MaxStackSize;
                return Item.MaxStackSize - (Amount + amount);
            }

            return 0;
        }
    }
}
