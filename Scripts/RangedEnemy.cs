using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy

{
    public float sd;
    public int speed;
    private float attacktime;
    public float tba;
    public int damage;
    public Animator anim;
    public Transform shotpoint;
    public GameObject bullet;
    public float lifetime;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > sd)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            if (Time.time >= attacktime)
            {
                anim.SetBool("attack",true);
                attacktime = Time.time + tba;

            }
        }
    }
    public void Attack()
    {
        Vector2 direction = player.transform.position - shotpoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shotpoint.rotation = rotation;
        Instantiate(bullet,shotpoint.position,shotpoint.rotation);
        anim.SetBool("attack", false);

    }
}
