using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            float ClampedX = Mathf.Clamp(playerTransform.position.x, minx, maxx);
            float Clampedy = Mathf.Clamp(playerTransform.position.y, miny, maxy);
            transform.position = Vector2.Lerp(transform.position, new Vector2(ClampedX,Clampedy), speed);

        }
    }
}
