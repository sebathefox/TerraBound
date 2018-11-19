using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
using Assets.Scripts.Common;
using Assets.Scripts.Common.Registry;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer), typeof(Transform))]
public class Block : MonoBehaviour, IObject
{
    private float blockBreaked = 0.0f;
    public bool destroyed = false;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteLoader.GetSprite("grass");
        Hardness = 0.5f;
        this.UnlocalizedName = "grass";
    }

    public static void InitBlocks()
    {
        Registry.Instance.BlockRegistry.Add(typeof(Block));
        Registry.Instance.BlockRegistry.Add(typeof(BlockStone));
        Registry.Instance.BlockRegistry.Add(typeof(BlockIron));
    }

    public void Mine()
    {
        Destroy(gameObject);
    }

    void OnMouseOver()
    {
        if (blockBreaked >= Hardness)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            this.destroyed = true;
            //Destroy(gameObject);
        }

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

    public Image Image { get; set; }

    public int MaxStackSize { get; protected set; }

    public string UnlocalizedName { get; protected set; }
}
