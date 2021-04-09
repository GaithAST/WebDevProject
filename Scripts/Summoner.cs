using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy

{
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    private Vector2 targetpos;
    private Animator anim;
    public float speed;
    private float SummonTime;
    public float tbs;
    public Enemy minions;
    public float sd;
    public float tba;
    public int damage;
    public float attaktime;
    public float attackspeed;
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(MinX, MaxX);
        float randomY = Random.Range(MinY, MaxY);
        targetpos = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < sd)
            {
                if (Time.time >= attaktime)
                {
                    attaktime = Time.time + tba;
                    StartCoroutine(Attack());
                }
                    
            }
            if (Vector2.Distance(transform.position,targetpos) > .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
                anim.SetBool("is running", true);
            }
            else
            {
                anim.SetBool("is running", false);
                if (Time.time >= SummonTime)
                {
                    anim.SetTrigger("isAttack");
                    SummonTime = Time.time + tbs;
                    StartCoroutine(Summon());
                    

                }
            }
        }
    }

    IEnumerator Summon()
    {
        if (player != null)
        {
            Instantiate(minions, transform.position, transform.rotation);
        }
        anim.SetBool("isAttack",true);
        SummonTime = Time.time + tbs;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isAttack", false);
        
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(Healt1h());

        }
    }
    IEnumerator Healt1h()
    {
        anim.SetTrigger("isHealthy");
        yield return new WaitForSeconds(2.1f);
        Destroy(this.gameObject);
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
