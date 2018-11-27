using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Inventory;
using UnityEngine;

//TODO: Rewrite the player class as multiple components eg. a 'health' component and a 'movement' component

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IHealth
{
    private float speed = 10.0f;
    
    protected int maxHealth = 100;

    protected int defence = 0;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<ItemStack>())
        {
            GetComponent<PlayerInventory>().AddStack(collider.gameObject.GetComponent<ItemStack>(), 1);
            //collider.gameObject.SetActive(false);
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
    }

    public int Health { get; private set; }

    public int GetMaxHp()
    {
        return maxHealth;
    }

    public void TakeDamage(double damage)
    {
        System.Random rnd = new System.Random();

        this.Health = (int)((damage - (double)defence) * rnd.NextDouble());
    }

    public void AddHp(int hp)
    {
        this.Health += hp;
    }

    public void SetHp(int hp)
    {
        this.Health = hp;
    }

    public void SubtractHp(int hp)
    {
        this.Health -= hp;
    }
}
