using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    protected Transform sourceGameObject;
    public float distanceTravelled;
    public float maximumTravelledDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    protected void shootProjectile()
    {

        if (sourceGameObject.transform.localScale.x < 0)
        {
            speed = -speed; // 
            this.transform.localScale = new Vector3(-(this.transform.localScale.x),
                                                 this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    protected void calcDistance() {
        if (this.transform == null) return;
        distanceTravelled = Mathf.Abs(this.transform.position.x - sourceGameObject.transform.position.x);

        if (distanceTravelled >= maximumTravelledDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
