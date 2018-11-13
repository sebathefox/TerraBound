using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer), typeof(Transform))]
public class Block : MonoBehaviour
{
    private float blockBreaked = 0.0f;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/grass");
        Hardness = 1.0f;
    }

    void OnMouseOver()
    {
        if(blockBreaked >= Hardness)
            Destroy(gameObject);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            blockBreaked += Time.deltaTime;    
        }
        else
            this.blockBreaked = 0.0f;
    }

    void OnMouseExit()
    {
        this.blockBreaked = 0.0f;
    }

    public float Hardness { get; protected set; }
}
