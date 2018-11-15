using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer), typeof(Transform))]
public class Block : MonoBehaviour
{
    public static List<KeyValuePair<string, Type>> blocks = new List<KeyValuePair<string, Type>>();

    private float blockBreaked = 0.0f;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteLoader.GetSprite("grass");
        Hardness = 0.5f;
        this.UnlocalizedName = "grass";
    }

    public static void InitBlocks()
    {
        blocks.Add(new KeyValuePair<string, Type>("grass", typeof(Block)));
        blocks.Add(new KeyValuePair<string, Type>("stone", typeof(BlockStone)));
        blocks.Add(new KeyValuePair<string, Type>("ore_iron", typeof(BlockIron)));
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

    public string UnlocalizedName { get; protected set; }
}
