using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Inventory.Slots;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    /// <inheritdoc cref="IInventory"/>
    class PlayerInventory : MonoBehaviour, IInventory
    {
        


        public GameObject inventory;
        public GameObject slotHolder;

        private int numSlots;
        private Transform[] slots;

        private bool invEnabled = false;

        public void Start()
        {
            numSlots = slotHolder.transform.childCount;
            slots = new Transform[numSlots];
            DetectInventorySlots();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                invEnabled = !invEnabled;
            }
            if (invEnabled)
                inventory.SetActive(true);
            else
                inventory.SetActive(false);
        }

        public void AddStack(ItemStack stack, int position)
        {
            try
            {
                stack.transform.SetParent(slots[position]);
                stack.transform.localScale = new Vector3(1, 1);
                

                print("Trying to add " + stack.Item.UnlocalizedName + " to inventory");
                if (slots[position].GetComponent<Slot>().Empty)
                {
                    slots[position].GetComponent<Slot>().Stack = stack;
                    slots[position].GetComponent<Slot>().Sprite = stack.Item.Image;
                    slots[position].GetComponent<Slot>().Empty = false;
                }
                else
                {
                    Type typeLocal = slots[position].GetComponent<Slot>().Stack.GetType();
                    Type typeRemote = stack.GetType();
                    if (typeLocal == typeRemote)
                    {
                        int rest = slots[position].GetComponent<Slot>().Stack.AddAmount(stack.Amount);

                        if (rest != 0)
                        {
                            //TODO: Send the stack to the user's cursor.
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                print(e.Message);
            }
        }

        public ItemStack RemoveStack(int position)
        {
            return null;
        }

        private void DetectInventorySlots()
        {
            for (int i = 0; i < numSlots; i++)
            {
                slots[i] = slotHolder.transform.GetChild(i);
                
                //DEBUG
                print(slots[i].name);
                print(slots[i].GetComponent<Slot>().Empty);
            }
        }
    }
}
