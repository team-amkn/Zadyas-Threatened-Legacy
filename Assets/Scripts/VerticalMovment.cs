using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovment : MonoBehaviour
{
    public float radius = 3f;
    private float minY, maxY;
    public float speed = 3f;

    // Use this for initialization
    void Start()
    {

        minY = transform.position.y - radius;
        maxY = transform.position.y + radius;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3( transform.position.x, Mathf.PingPong(Time.time * speed, maxY - minY) + minY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.transform.position.y > gameObject.transform.position.y)
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.parent = null;
        }
    }

}
