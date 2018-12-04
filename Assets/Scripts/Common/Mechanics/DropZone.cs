using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Common.Mechanics
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.parentToReturnTo = this.transform;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            print("Pointer Entered");
            if (eventData.pointerDrag == null)
                return;

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.placeHolderParent = transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && d.placeHolderParent == this.transform)
            {
                d.placeHolderParent = d.parentToReturnTo;
            }
        }
    }
}
