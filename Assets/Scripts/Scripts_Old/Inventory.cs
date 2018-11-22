using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Common;
using Assets.Scripts.Items;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Assets.Scripts.Inventory
{
    [RequireComponent(typeof(Image))]
    public class Inventory : MonoBehaviour
    {
        private Image background;

        public GameObject inventory;
        public GameObject slotHolder;

        private int slot;
        private Transform[] slots;

        private bool invEnabled = false;

        void Start()
        {
            Block.InitBlocks();

            slot = slotHolder.transform.childCount;
            slots = new Transform[slot];
            DetectInventorySlots();


        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                invEnabled = !invEnabled;
            }
            if(invEnabled)
                inventory.SetActive(true);
            else
                inventory.SetActive(false);
        }

        public void Add(GameObject item)
        {

            //for (int i = 0; i < slot; i++)
            //{
            //    if (slots[i].GetComponent<Slot>().empty)
            //    {
            //        Debug.Log("Added a new item: " + item.name);
            //        slots[i].GetComponent<Slot>().item = item;
            //        slots[i].GetComponent<Slot>().image = item.GetComponent<SpriteRenderer>().sprite;
            //    }
            //}
        }

        public ItemStack Remove(int amount, int position)
        {
            return null;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.GetComponent<Block>() && other.gameObject.GetComponent<Block>().destroyed == true)
            {
                print("AFTER");
                Add(other.gameObject);
                
            }
        }

        public void DetectInventorySlots()
        {
            for (int i = 0; i < slot; i++)
            {
                slots[i] = slotHolder.transform.GetChild(i);
                print(slots[i].name);
            }
        }
    }
}
