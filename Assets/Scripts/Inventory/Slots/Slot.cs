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
    
    public class Slot : MonoBehaviour//, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private GameObject child;

        void Awake()
        {
            child = new GameObject("ItemRenderer", typeof(Text));
            child.transform.SetParent(gameObject.transform);
            child.GetComponent<RectTransform>().position = gameObject.transform.position;
            child.GetComponent<RectTransform>().sizeDelta = new Vector2(1.9f, 1.9f);
            child.GetComponent<Text>().font = Resources.Load<Font>("fonts/Adventure ReQuest");
            child.GetComponent<Text>().fontSize = 1;
            child.GetComponent<Text>().resizeTextMaxSize = 1;
            child.GetComponent<Text>().resizeTextForBestFit = true;
            child.GetComponent<Text>().alignByGeometry = true;
            child.GetComponent<Text>().alignment = TextAnchor.LowerRight;



            this.Empty = true;
        }

        /// <summary>
        /// The <see cref="UnityEngine.UI.Image"/> to show.
        /// </summary>
        public Sprite Sprite
        {
            get { return Stack.Sprite;}
            set { Stack.Sprite = value; }
        }

        /// <summary>
        /// The <see cref="ItemStack"/> to hold in the <see cref="Slot"/>
        /// </summary>
        public ItemStack Stack { get; set; }

        /// <summary>
        /// true if the <see cref="Slot"/> is empty otherwise false
        /// </summary>
        public bool Empty { get; set; }

        public void Update()
        {
            if (!Empty)
            {
                child.GetComponent<Text>().text = Stack.Amount.ToString();
            }
        }

        //public void OnPointerEnter(PointerEventData eventData)
        //{

        //    if (eventData.pointerDrag == null)
        //        return;

        //    ItemStack d = eventData.pointerDrag.GetComponent<ItemStack>();
        //    if (d != null)
        //    {
        //        d.placeHolderParent = this.transform;
        //    }
        //}

        //public void OnPointerExit(PointerEventData eventData)
        //{

        //    if (eventData.pointerDrag == null)
        //        return;

        //    ItemStack d = eventData.pointerDrag.GetComponent<ItemStack>();
        //    if (d != null && d.placeHolderParent == this.transform)
        //    {
        //        d.placeHolderParent = d.parentToReturnTo;
        //    }
        //}

        //public void OnDrop(PointerEventData eventData)
        //{
        //    Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        //    ItemStack d = eventData.pointerDrag.GetComponent<ItemStack>();
        //    if (d != null)
        //    {
        //        d.parentToReturnTo = this.transform;
        //    }
        //}
    }
}
