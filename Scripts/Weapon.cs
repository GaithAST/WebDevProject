using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;
    private float shotTime;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private IEnumerator Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
        shotTime = Time.time + timeBetweenShots;
        yield return null;
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
        if (Input.GetMouseButton(0))
        {
            
            if (Time.time >= shotTime)
            {

                StartCoroutine(Shoot());

            }
            
        }

    }
}
