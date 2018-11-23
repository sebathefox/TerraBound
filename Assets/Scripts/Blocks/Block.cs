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
    }

    public static void InitBlocks()
    {
        Registry.Instance.BlockRegistry.Add(new GameObject("" ,typeof(Block)));
        Registry.Instance.BlockRegistry.Add(new GameObject("", typeof(BlockStone)));
        Registry.Instance.BlockRegistry.Add(new GameObject("", typeof(BlockOre)));
    }

    public void DropItemStack()
    {
        //TODO: Find a way to put an ItemStack on the ground for the player to pickup.
        GameObject stack = new GameObject("droppedItem", typeof(ItemStack));
        stack.GetComponent<ItemStack>().Item = this;
        stack.GetComponent<ItemStack>().Amount = 1;

        stack.AddComponent(GetType());

        stack.transform.position = this.transform.position;
        stack.transform.localScale = new Vector3(0.5f, 0.5f);
        //stack.AddComponent<SpriteRenderer>();
        stack.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        //stack.GetComponent<ItemStack>()
        //stack.AddComponent<Rigidbody2D>();
        //stack.AddComponent<BoxCollider2D>();
        stack.GetComponent<BoxCollider2D>().isTrigger = true;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //Destroy(this.gameObject);
    }

    void Update()
    {
        if(destroyed)
            DropItemStack();
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

    public Block SetUnlocalizedName(string unlocalizedName)
    {
        this.UnlocalizedName = unlocalizedName;
        return this;
    }

    public Block SetOreSprite(string orePath)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(ImageHelper.AlphaBlend(Resources.Load<Sprite>("Sprites/Blocks/stone").texture,
            Resources.Load<Sprite>(orePath).texture), new Rect(0, 0, 32, 32), new Vector2(0.5f, 0.5f), 32);

        //Image.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;


        return this;
    }

    public float Hardness { get; set; }

    public Sprite Image
    {
        get { return GetComponent<SpriteRenderer>().sprite; }
        set { GetComponent<SpriteRenderer>().sprite = value; }
    }

    public int MaxStackSize { get; protected set; }

    public string UnlocalizedName { get; protected set; }
}
