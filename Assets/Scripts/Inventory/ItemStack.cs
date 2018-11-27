using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ItemStack : MonoBehaviour //, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturnTo = null;
        public Transform placeHolderParent = null;

        private GameObject placeHolder = null;

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

        public Sprite Sprite
        {
            get { return GetComponent<Image>().sprite; }
            set { GetComponent<Image>().sprite = value; }
        }

        //public void OnBeginDrag(PointerEventData eventData)
        //{
        //    print("BEGIN DRAG");
        //    placeHolder = new GameObject();
        //    placeHolder.transform.SetParent(transform.parent);
        //    LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        //    le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        //    le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        //    le.flexibleWidth = 0;
        //    le.flexibleHeight = 0;

        //    placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        //    parentToReturnTo = this.transform.parent;
        //    placeHolderParent = parentToReturnTo;
        //    transform.SetParent(transform.parent.parent);

        //    GetComponent<CanvasGroup>().blocksRaycasts = false;
        //}

        //public void OnDrag(PointerEventData eventData)
        //{
        //    this.transform.position = eventData.position;
        //    if(placeHolder.transform.parent != placeHolderParent)
        //        placeHolder.transform.SetParent(placeHolderParent);

        //    int newSiblingIndex = placeHolderParent.childCount;

        //    for (int i = 0; i < placeHolderParent.childCount; i++)
        //    {
        //        if (transform.position.x < placeHolderParent.GetChild(i).position.x)
        //        {
        //            newSiblingIndex = i;
        //            if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
        //                newSiblingIndex--;
        //            break;
        //        }
        //    }

        //    placeHolder.transform.SetSiblingIndex(newSiblingIndex);
        //}

        //public void OnEndDrag(PointerEventData eventData)
        //{
        //    transform.SetParent(parentToReturnTo);
        //    transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        //    GetComponent<CanvasGroup>().blocksRaycasts = true;
        //    Destroy(placeHolder);
        //}
    }
}
