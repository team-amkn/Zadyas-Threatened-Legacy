using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public int speed;
    public Transform sourceGameObject;
    public float distanceTravelled;
    public float maximumTravelledDistance;

    // Start is called before the first frame update
    protected virtual void Start()
    {

        if (sourceGameObject.transform.localScale.x < 0)
        {
            speed = -speed;
            this.transform.localScale = new Vector3(-(this.transform.localScale.x),
                                                 this.transform.localScale.y, this.transform.localScale.z);
        }

    }

    // Update is called once per frame
   protected virtual void Update()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        distanceTravelled = this.transform.position.x - sourceGameObject.transform.position.x;

        if (distanceTravelled > maximumTravelledDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
