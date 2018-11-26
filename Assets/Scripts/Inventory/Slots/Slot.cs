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
    [RequireComponent(typeof(Text))]
    public class Slot : MonoBehaviour
    {
        private GameObject child;

        void Awake()
        {
            child = new GameObject("ItemRenderer", typeof(Image));
            child.transform.parent = this.gameObject.transform;
            child.transform.position = gameObject.transform.position;
            child.transform.localScale = new Vector3(0.5f, 0.5f);
            child.transform.localRotation = gameObject.transform.localRotation;
            this.Empty = true;
        }

        /// <summary>
        /// The <see cref="UnityEngine.UI.Image"/> to show.
        /// </summary>
        public Sprite Sprite
        {
            get { return GetComponentInChildren<Image>().sprite;}
            set { GetComponentInChildren<Image>().sprite = value; }
        }

        /// <summary>
        /// The <see cref="ItemStack"/> to hold in the <see cref="Slot"/>
        /// </summary>
        public ItemStack Stack { get; set; }

        public bool Empty { get; set; }

        public void Update()
        {
            if (Empty == false)
            {
                GetComponent<Text>().text = Stack.Amount.ToString();
            }
        }
    }
}
