using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public float sd;
    public int speed;
    private float attacktime;
    public float tba;
    public float attackspeed;
    public int damage;
    
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > sd)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attacktime)
                {
                    attacktime = Time.time + tba;
                    StartCoroutine(Attack());
                    
                }
            }
        }
    }
    IEnumerator Attack()
    {
        player.GetComponent<Player>().TakeDamage(damage);

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = player.transform.position;

        float percent = 0f;
        while (percent <= 1)
        {

            percent += Time.deltaTime * attackspeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, interpolation);
            yield return null;

        }
    }
}
