using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Blocks;
using Assets.Scripts.Blocks.Ores;
using Assets.Scripts.Common;
using Assets.Scripts.Inventory;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteLoader.GetSprite("Blocks/grass");
        Hardness = 0.5f;
        this.UnlocalizedName = "grass";
        Image = GetComponent<SpriteRenderer>().sprite;
        MaxStackSize = 64;

        InvokeRepeating("UpdateOncePerSecond", 0f, 1.0f);
    }

    public static void InitBlocks()
    {
        Registry.Instance.BlockRegistry.Add(new GameObject("block_grass" ,typeof(Block)));
        Registry.Instance.BlockRegistry.Add(new GameObject("block_stone", typeof(BlockStone)));
        Registry.Instance.BlockRegistry.Add(new GameObject("block_ore", typeof(BlockOre)));
    }

    public void DropItemStack()
    {
        print(gameObject.GetComponent(GetType()).GetType());

        destroyed = false; // Stops the object from dropping more than one of itself
        GameObject stack = new GameObject("droppedItem", typeof(ItemStack));
        stack.GetComponent<ItemStack>().Item = (IObject)gameObject.GetComponent(GetType());
        stack.GetComponent<ItemStack>().Amount = 1;

        stack.AddComponent(GetType());

        stack.transform.position = this.transform.position;
        stack.GetComponent<RectTransform>().sizeDelta = new Vector2(32, 32);
        stack.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        stack.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        stack.transform.localScale = new Vector3(0.5f, 0.5f);
        stack.GetComponent<ItemStack>().Sprite = GetComponent<SpriteRenderer>().sprite;
        //stack.GetComponent<BoxCollider2D>().isTrigger = true;

        Destroy(gameObject);
    }

    void UpdateOncePerSecond()
    {
        if(destroyed)
            DropItemStack();
    }

    void OnMouseOver()
    {
        if (destroyed) return;
        if (blockBreaked >= Hardness)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            this.destroyed = true;
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

    public Block SetUnlocalizedName(string unlocalizedName)
    {
        this.UnlocalizedName = unlocalizedName;
        return this;
    }

    /// <summary>
    /// Sets the ore's sprite
    /// </summary>
    /// <param name="orePath">the path to the ore's sprite</param>
    /// <returns>Returns itself (Used for linking methods together)</returns>
    public Block SetOreSprite(string orePath)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Image = Sprite.Create(ImageHelper.AlphaBlend(Resources.Load<Sprite>("Sprites/Blocks/stone").texture,
            Resources.Load<Sprite>(orePath).texture), new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 32);
        return this;
    }

    /// <summary>
    /// The time it takes to mine the block
    /// </summary>
    public float Hardness { get; set; }

    /// <summary>
    /// The image of the object
    /// </summary>
    public Sprite Image
    {
        get;
        set;
    }

    /// <summary>
    /// The max number of blocks in a single stack
    /// </summary>
    public int MaxStackSize { get; protected set; }

    /// <summary>
    /// The <see cref="Registry"/>'s index of the block
    /// </summary>
    public string UnlocalizedName { get; protected set; }
}
