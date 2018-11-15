using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    public class Inventory : MonoBehaviour
    {
        public Text InventoryText;

        private int[] counts = new int[7];

        void Update()
        {
            //InventoryText.text 
        }

        public void Add(int tileType, int count)
        {

        }
    }
}
