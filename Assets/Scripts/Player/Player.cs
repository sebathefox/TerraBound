using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Registry;
using Assets.Scripts.Inventory;
using Assets.Scripts.Inventory.Slots;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

//TODO: Rewrite the player class as multiple components eg. a 'health' component and a 'movement' component

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // THe speed of the player character
    private float speed = 10.0f;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        // If the object is able to be picked up
        if (collider.gameObject.GetComponent<ItemStack>())
        {
            GetComponent<PlayerInventory>().AddStack(collider.gameObject.GetComponent<ItemStack>());
        }
    }



    void FixedUpdate()
    {
        float translation = Input.GetAxis("Horizontal") * speed;

        float js = Input.GetAxis("Jump") * speed;

        translation *= Time.fixedDeltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        js *= Time.fixedDeltaTime;

        transform.Translate(translation, js, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            ray.z = 0;

            Vector3 gridPosition = new Vector3(Mathf.Round(ray.x),
                                                Mathf.Round(ray.y));

            Vector2 rp = new Vector2(gridPosition.x, gridPosition.y);

            if (!Physics2D.Raycast(rp, Vector2.zero, 0.1f))
            {
                //GameObject dropped = Instantiate(Registry.Instance.BlockRegistry[0], gridPosition, Quaternion.identity);

                GameObject hud = transform.GetChild(3).GetChild(0).gameObject;

                if (!hud.GetComponentInChildren<SelectedOnHud>().gameObject.transform.GetChild(0).gameObject)
                    return;

                

                

                GameObject selectedInHud = hud.GetComponentInChildren<SelectedOnHud>().gameObject.transform.GetChild(0).gameObject;


                if (selectedInHud.GetComponent<ItemStack>().RemoveAmount(1) <= 0)
                {
                    Destroy(selectedInHud.GetComponent<ItemStack>());
                    selectedInHud.transform.position = gridPosition;
                    selectedInHud.transform.parent = null;
                    selectedInHud.GetComponent<BoxCollider2D>().enabled = true;
                    Destroy(selectedInHud.transform.GetChild(0).gameObject);
                    Destroy(selectedInHud.transform.GetChild(1).gameObject);
                    Destroy(selectedInHud.GetComponent<CanvasRenderer>());
                    Destroy(selectedInHud.GetComponent<Image>());
                    GameObject dropped = Instantiate(selectedInHud, gridPosition, Quaternion.identity);
                    Destroy(selectedInHud);
                    dropped.transform.localScale = new Vector3(1, 1);
                    hud.GetComponentInChildren<SelectedOnHud>().gameObject.GetComponent<Slot>().Empty = true;
                }
                else
                {
                    selectedInHud.GetComponent<ItemStack>().RemoveAmount(1);
                    GameObject dropped = Instantiate(selectedInHud, gridPosition, Quaternion.identity);
                    Destroy(dropped.GetComponent<ItemStack>());
                    dropped.GetComponent<BoxCollider2D>().enabled = true;
                    dropped.transform.localScale = new Vector3(1, 1);
                    Destroy(dropped.transform.GetChild(0).gameObject);
                    Destroy(dropped.transform.GetChild(1).gameObject);
                }

                

                


                //gameObject.transform.GetChild(3).gameObject.GetComponent<ItemStack>().Amount--;
                //if(gameObject.transform.GetChild(3).gameObject.GetComponent<ItemStack>().Amount <= 0)

                //gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }
}
