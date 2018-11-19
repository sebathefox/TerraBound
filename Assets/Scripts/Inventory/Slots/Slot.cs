using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Slots
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a simple storage capable of storing a single <see cref="T:Assets.Scripts.Inventory.ItemStack" />
    /// </summary>
    public class Slot : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="UnityEngine.UI.Image"/> to show.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// The <see cref="ItemStack"/> to hold in the <see cref="Slot"/>
        /// </summary>
        public ItemStack Stack { get; set; }

        public bool Empty { get; set; }

        public void Update()
        {

        }
    }
}
