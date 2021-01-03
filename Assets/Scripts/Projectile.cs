using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float speed;
    private Transform sourceGameObject;
    protected float distanceTravelled;
    public float maximumTravelledDistance;
    private Vector3 sourcePosition;

    public Transform SourceGameObject { get => sourceGameObject; set => sourceGameObject = value; }
    public Vector3 SourcePosition { get => sourcePosition; set => sourcePosition = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void shootProjectile()
    {
        if (SourceGameObject.transform.localScale.x < 0)
        {
            speed = -speed;
            this.transform.localScale = new Vector3(-(this.transform.localScale.x),
                                                 this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    protected virtual void calculateTravelDistance()
    {
        if (this.transform == null) return;
        distanceTravelled = Mathf.Abs(this.transform.position.x - sourcePosition.x);

        if (distanceTravelled >= maximumTravelledDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
