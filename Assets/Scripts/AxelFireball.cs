using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxelFireball : Projectile
{

    private Transform axel;

    protected void Start()
    {
        axel = FindObjectOfType<Player>().GetComponent<Transform>();
        SourceGameObject = axel;
        shootProjectile();
    }

    protected override void shootProjectile()
    {

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (axel.position.x < worldPosition.x)
        {
            axel.GetComponent<Player>().isFacingRight = true;
            axel.localScale = new Vector3(Mathf.Abs(axel.localScale.x), axel.localScale.y, axel.localScale.z);
        }
        else
        {
            axel.GetComponent<Player>().isFacingRight = false;
            axel.localScale = new Vector3(-Mathf.Abs(axel.localScale.x), axel.localScale.y, axel.localScale.z);
        }
        Vector2 direction = (worldPosition - (Vector2)this.transform.position);
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Quaternion newRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        this.transform.rotation = newRotation;
    }

    protected override void calculateTravelDistance()
    {
        if (this.transform == null) return;
        distanceTravelled = Mathf.Abs(this.transform.position.x - SourceGameObject.transform.position.x);

        if (distanceTravelled >= maximumTravelledDistance)
        {
            Destroy(this.gameObject);
        }
    }

}
