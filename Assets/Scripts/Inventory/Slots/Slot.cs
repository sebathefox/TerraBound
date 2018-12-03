using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory.Slots
{
    /// <inheritdoc />
    /// <summary>
    /// Defines a simple storage capable of storing a single <see cref="T:Assets.Scripts.Inventory.ItemStack" />
    /// </summary>
    
    public class Slot : MonoBehaviour
    {

        void Awake()
        {
            this.Empty = true;
        }

        /// <summary>
        /// The <see cref="ItemStack"/> to hold in the <see cref="Slot"/>
        /// </summary>
        public ItemStack Stack { get; set; }

        /// <summary>
        /// true if the <see cref="Slot"/> is empty otherwise false
        /// </summary>
        public bool Empty { get; set; }

        public void SetComponentOnSisterObject(int index)
        {
            //GameObject selected = new GameObject("Selected", typeof(SelectedOnHud));

            //selected.transform.SetParent(gameObject.transform.parent.GetChild(index).gameObject.transform);

            transform.parent.GetChild(index).gameObject.AddComponent<SelectedOnHud>();
            Destroy(gameObject.GetComponent<SelectedOnHud>());
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            
        }
    }
}
