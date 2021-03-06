﻿using Assets.Scripts.Inventory.Slots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Inventory
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SelectedOnHud : MonoBehaviour
    {
        void Awake()
        {
            Image = Resources.Load<Image>("Sprites/player");
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/player");
        }

        private Image Image { get; set; }

        void Update()
        {
            int sibling = gameObject.transform.parent.GetSiblingIndex();

            //TODO: Fix this part of the input
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Forward
            {
                print("FIRST");
                if(sibling > gameObject.transform.parent.childCount)
                    gameObject.transform.GetComponent<Slot>().SetComponentOnSisterObject(sibling);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // Backwards
            {
                int tmp = gameObject.transform.parent.childCount;
                print(tmp);
                if(0 >= gameObject.transform.GetSiblingIndex())
                gameObject.transform.GetComponent<Slot>()
                    .SetComponentOnSisterObject(--tmp);
                else
                {
                    gameObject.transform.GetComponent<Slot>()
                        .SetComponentOnSisterObject(gameObject.transform.GetSiblingIndex() - 1);
                }
            }
        }
    }
}
