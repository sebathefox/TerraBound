using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Inventory.Slots;
using Assets.Scripts.Items.Tools;
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

        public bool AddStack(ItemStack stack, int position)
        {
            try
            {
                stack.gameObject.GetComponent<BoxCollider2D>().enabled = false;

                print("Trying to add " + stack.Item.UnlocalizedName + " to inventory, at position " + position);
                if (slots[position].GetComponent<Slot>().Empty)
                {
                    stack.transform.SetParent(slots[position]);
                    stack.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f);
                    stack.transform.position = slots[position].position;
                    slots[position].GetComponent<Slot>().Stack = stack;

                    slots[position].GetComponent<Slot>().Empty = false;
                    return true;
                }
                else
                {
                    string blockUnlocalizedName = slots[position].GetComponent<Slot>().Stack.Item.UnlocalizedName;
                    
                    string unlocalizedNameOfRemote = stack.Item.UnlocalizedName;
                    if (blockUnlocalizedName == unlocalizedNameOfRemote)
                    {
                        int rest = slots[position].GetComponent<Slot>().Stack.AddAmount(stack.Amount);
                        print("PlayerInventory");

                        if ((rest + slots[position].GetComponent<Slot>().Stack.Amount) > slots[position].GetComponent<Slot>().Stack.Item.MaxStackSize)
                            return false;

                        if (rest > 0)
                        {
                            
                            print(rest);
                            stack.Amount = rest;
                            AddStack(stack, (++position));
                            return true;
                        }

                        Destroy(stack.gameObject);
                        return true;
                    }
                    else
                    {
                        //++position;
                        print("Slot already occupied by: " + slots[position].GetComponent<Slot>().Stack.Item.UnlocalizedName);

                        //AddStack(stack, position);

                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                print(e.Message);
                return false;
            }
        }

        public void AddStack(ItemStack stack)
        {
            print("SLOTS: " + numSlots);
            for (int i = 0; i < numSlots; i++)
            {
                if(AddStack(stack, i))
                    return;
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

            slots[0].gameObject.AddComponent<SelectedOnHud>();

            slots[1].GetComponent<Slot>().Empty = false;
            GameObject gob = new GameObject("", typeof(ItemStack));
            gob.GetComponent<ItemStack>().Item = new Pickaxe();
            gob.transform.SetParent(slots[1].transform);
            gob.GetComponent<ItemStack>().Sprite = gob.GetComponent<ItemStack>().Item.Image;
            gob.transform.localScale = new Vector3(1, 1);
            gob.transform.localPosition = new Vector3(0, 0);

            slots[1].GetComponent<Slot>().Stack = gob.GetComponent<ItemStack>();
        }

        public bool IsSlotEmpty(int position)
        {
            return slots[position].GetComponent<Slot>().Empty;
        }
    }
}
