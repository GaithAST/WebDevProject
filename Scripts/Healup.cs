using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healup : MonoBehaviour
{
    // Start is called before the first frame update
    public int Healthamount;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().Heal(Healthamount);
            Destroy(gameObject);
        }
    }
}
