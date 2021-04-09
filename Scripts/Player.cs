using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 moveAmount;
    private Rigidbody2D rb;
    private Animator anim;
    public int health;
    public Transform SpawnPoint;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite DeadHeart;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

// Update is called once per frame
void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (moveAmount != Vector2.zero)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        UpdateHealthUI(health);
        if (health <= 0)
        {
            Destroy(this.gameObject);
            
        }
    }
    public void Pickup(Weapon WeaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(WeaponToEquip,SpawnPoint.position, transform.rotation,transform);
    }
    public void Heal(int HealAmount)
    {
        health += HealAmount;
        UpdateHealthUI(health);
    }
    
    public  void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = DeadHeart;
            }

        }
    }

    public void Healup(int Heal)
    {

    }
}
