using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Inventory.Slots;

namespace Assets.Scripts.Inventory
{
    /// <inheritdoc cref="IInventory"/>
    class PlayerInventory : MonoBehaviour, IInventory
    {
        public GameObject inventory;
        public GameObject slotHolder;

        private int numSlots;
        private Transform[] slots;

        public void Start()
        {
            numSlots = slotHolder.transform.childCount;
            slots = new Transform[numSlots];
            DetectInventorySlots();
        }

        public void AddStack(ItemStack stack, int position)
        {
            throw new NotImplementedException();
        }

        public void AddToStack(ItemStack stack, int position)
        {
            try
            {
                if (slots[position].GetComponent<Slot>().Empty)
                {
                    slots[position].GetComponent<Slot>().Stack = stack;
                    slots[position].GetComponent<Slot>().Image = stack.Item.Image;
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
            throw new NotImplementedException();
        }

        private void DetectInventorySlots()
        {
            for (int i = 0; i < numSlots; i++)
            {
                slots[i] = slotHolder.transform.GetChild(i);
                
                //DEBUG
                print(slots[i].name);
            }
        }
    }
}
