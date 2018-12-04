using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Inventory.Slots;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Inventory : MonoBehaviour
    {
        public GameObject inventory;
        private GameObject background;
        //public GameObject slotHolder;

        void Awake()
        {
            background = new GameObject("InventoryBackground", typeof(Image));
            //slotHolder = new GameObject("SlotHolder");


            background.GetComponent<Image>().sprite = Sprite.Create(Resources.Load<Texture2D>("Sprites/Inventory"), new Rect(0, 0, 1920, 1080), new Vector2(0.5f, 0.5f));

            background.transform.SetParent(inventory.transform);
            //slotHolder.transform.SetParent(inventory.transform);

            //background.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            background.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            background.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            background.layer = 5;
            background.GetComponent<RectTransform>().sizeDelta = new Vector2(1, 1);
            background.transform.localScale = new Vector3(0.9f, 0.9f);
            background.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);


            AddSlot(new Vector2(32, 32), "SLOT");
        }

        public void AddSlot(Vector2 position, string name = "")
        {
            GameObject slot = new GameObject(name, typeof(Slot));
            slot.transform.SetParent(background.transform);
            slot.layer = 5;
        }
    }
}
