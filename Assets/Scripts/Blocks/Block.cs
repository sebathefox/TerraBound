using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Blocks;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer), typeof(Transform))]
public class Block : MonoBehaviour
{
    public static List<KeyValuePair<string, Block>> blocks = new List<KeyValuePair<string, Block>>();

    private float blockBreaked = 0.0f;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/grass");
        Hardness = 0.5f;
    }

    public static void InitBlocks()
    {
        blocks.Add(new KeyValuePair<string, Block>("grass", new Block()));
        blocks.Add(new KeyValuePair<string, Block>("stone", new BlockStone()));
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
