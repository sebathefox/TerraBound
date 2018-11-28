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
        // The root inventory object (Typically a canvas)
        public GameObject inventory;

        // The inventory's child made for holding the slots
        public GameObject slotHolder;

        // The number of slots
        public int numSlots;

        // The slots
        private Transform[] slots;

        // is the inventory overlay currently enabled
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



                //print("Trying to add " + stack.Item.UnlocalizedName + " to inventory, STATUS: " + slots[position].GetComponent<Slot>().Empty);
                if (slots[position].GetComponent<Slot>().Empty)
                {
                    stack.transform.SetParent(slots[position]);
                    stack.transform.localScale = new Vector3(1, 1);
                    stack.transform.position = slots[position].position;
                    slots[position].GetComponent<Slot>().Stack = stack;

                    slots[position].GetComponent<Slot>().Empty = false;
                }
                else
                {
                    Type typeLocal = slots[position].GetComponent<Slot>().Stack.Item.GetType();
                    Type typeRemote = stack.Item.GetType();
                    if (typeLocal == typeRemote)
                    {
                        slots[position].GetComponent<Slot>().Stack.AddAmount(stack.Amount);
                        print("PlayerInventory");
                        Destroy(stack.gameObject);

                        //if (rest != 0)
                        //{
                        //    //TODO: Send the stack to the user's cursor.
                        //}
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                print(e.Message);
            }
        }

        /// <summary>
        /// Removes the selected <see cref="ItemStack"/> from the inventory
        /// </summary>
        /// <param name="position">The index of the <see cref="ItemStack"/></param>
        /// <returns>Returns the <see cref="ItemStack"/> for further usage</returns>
        public ItemStack RemoveStack(int position)
        {
            //TODO: Implement the removestack function
            return null;
        }

        /// <summary>
        /// Detects how many slots that is available in the inventory
        /// </summary>
        private void DetectInventorySlots()
        {
            for (int i = 0; i < numSlots; i++)
            {
                slots[i] = slotHolder.transform.GetChild(i);
            }
        }
    }
}
