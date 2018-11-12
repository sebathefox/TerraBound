using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    private Collider2D coll;

    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float translation = Input.GetAxis("Horizontal") * speed;

        coll.

        float js = Input.GetAxis("Jump") * speed;

        translation *= Time.fixedDeltaTime;

        js *= Time.fixedDeltaTime;

        transform.Translate(translation, js, 0);
        
    }
}
