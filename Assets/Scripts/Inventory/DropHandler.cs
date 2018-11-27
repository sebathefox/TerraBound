using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Inventory.Slots;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Inventory
{
    public class DropHandler : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            RectTransform invPanel = transform as RectTransform;

            if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
            {
                if (invPanel.GetComponent<Slot>())
                {
                    Debug.Log("Drop item");
                }
            }
        }
    }
}
