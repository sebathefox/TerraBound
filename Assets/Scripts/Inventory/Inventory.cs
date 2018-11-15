using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour, IInventory
    {
        public Image background;

        private ItemStack[] counts = new ItemStack[18];

        void Update()
        {
            //InventoryText.text 

            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }

        public void Add(ItemStack items, int count)
        {

        }

        public ItemStack Remove(int amount, int position)
        {
            return null;
        }
    }
}
