using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;

namespace Assets.Scripts.Inventory
{
    /// <summary>
    /// The interface of all inventories in the game.
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Adds a <see cref="ItemStack"/> to the selected slot
        /// </summary>
        /// <param name="stack">The <see cref="ItemStack"/> to add</param>
        /// <param name="position">The inventory's position to occupy</param>
        void AddStack(ItemStack stack, int position);

        /// <summary>
        /// Adds a <see cref="ItemStack"/> to another <see cref="ItemStack"/> of the same type.
        /// </summary>
        /// <param name="stack">The <see cref="ItemStack"/> to add</param>
        /// <param name="position">The position of the <see cref="ItemStack"/></param>
        void AddToStack(ItemStack stack, int position);

        /// <summary>
        /// Removes a full <see cref="ItemStack"/> from the inventory.
        /// </summary>
        /// <param name="position">the position of the <see cref="ItemStack"/></param>
        /// <returns>Returns the selected <see cref="ItemStack"/></returns>
        ItemStack RemoveStack(int position);
    }
}
