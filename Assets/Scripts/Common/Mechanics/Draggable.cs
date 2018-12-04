using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Common.Mechanics
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturnTo = null;

        public Transform placeHolderParent = null;

        private GameObject placeHolder = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            print("Tried To Drag");

            placeHolder = new GameObject();
            placeHolder.transform.SetParent(transform.parent);
            LayoutElement le = placeHolder.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;

            placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeHolderParent = parentToReturnTo;
            this.transform.SetParent(this.transform.parent.parent);

            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;

            if (placeHolder.transform.parent != placeHolderParent)
            {
                placeHolder.transform.SetParent(placeHolderParent);
            }

            int newSiblingIndex = placeHolderParent.childCount;

            for (int i = 0; i < placeHolderParent.childCount; i++)
            {
                if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                        newSiblingIndex--;

                    break;
                }
            }

            placeHolder.transform.SetSiblingIndex(newSiblingIndex);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            this.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Destroy(placeHolder);
        }
    }
}
