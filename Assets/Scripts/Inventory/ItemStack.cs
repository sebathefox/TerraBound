using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common.Mechanics;
using Assets.Scripts.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    /// <summary>
    /// A holder class for <see cref="Inventory"/> storage.
    /// </summary>
    [RequireComponent(typeof(Image))]
    public class ItemStack : MonoBehaviour
    {

        private GameObject child;

        void Awake()
        {
            Amount = 1;

            child = new GameObject("ItemAmountRenderer", typeof(Text));
            child.transform.SetParent(gameObject.transform);
            child.GetComponent<RectTransform>().position = gameObject.transform.position;
            child.GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
            child.transform.localScale = new Vector3(1, 1);
            child.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            child.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            child.GetComponent<Text>().font = Resources.Load<Font>("fonts/Adventure ReQuest");
            child.GetComponent<Text>().fontSize = 15;
            child.GetComponent<Text>().resizeTextMaxSize = 15;
            child.GetComponent<Text>().resizeTextForBestFit = true;
            child.GetComponent<Text>().alignByGeometry = true;
            child.GetComponent<Text>().alignment = TextAnchor.LowerRight;
            child.GetComponent<Text>().text = Amount.ToString();
        }

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
                print("YELLO");
                this.Amount = Item.MaxStackSize;
                return (Amount + amount) - Item.MaxStackSize;
            }

            child.GetComponent<Text>().text = Amount.ToString();
            return 0;
        }

        public int RemoveAmount(int amount)
        {
            Amount -= amount;

            child.GetComponent<Text>().text = Amount.ToString();
            return Amount;
        }

        public void SetStack()
        {

        }

        public Sprite Sprite
        {
            get { return GetComponent<Image>().sprite; }
            set { GetComponent<Image>().sprite = value; }
        }
    }
}
