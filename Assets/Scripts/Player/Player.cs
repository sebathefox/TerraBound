using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Registry;
using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

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

            if(!Physics2D.Raycast(rp, Vector2.zero, 0.1f))
                Instantiate(Registry.Instance.BlockRegistry[0], gridPosition, Quaternion.identity);
        }
    }
}
