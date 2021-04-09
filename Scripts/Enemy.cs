using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int health = 3;
    public int PickupChance;
    public int HealthPickupChance;
    public GameObject[] Pickups;
    public GameObject Health;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            int x = Random.Range(0, 101);
            if (x < PickupChance)
            {
                Instantiate(Pickups[Random.Range(0,Pickups.Length)], transform.position, transform.rotation);
            }
            int y = Random.Range(0, 101);
            if (y < HealthPickupChance)
            {
                Instantiate(Health, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
