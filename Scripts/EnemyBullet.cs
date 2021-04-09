using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour

{
    public float speed;
    public float Lifetime;
    public int damage;
    private Vector2 TargetPosition;
    public Player playerscript; 
    // Start is called before the first frame update
    private void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        TargetPosition = playerscript.transform.position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position,TargetPosition) > .1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, speed * Time.fixedDeltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerscript.TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }
}
