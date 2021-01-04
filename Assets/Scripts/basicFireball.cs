using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicFireball : Projectile
{

    private Transform axel;

    private bool hasCollided = false;

    void Start()
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
        Vector2 direction = (worldPosition - (Vector2) this.transform.position);
        direction.Normalize();
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        Quaternion newRotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        this.transform.rotation = newRotation;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        this.calculateTravelDistance();
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (this.hasCollided)
        {
            return;
        }

        if (other.tag == "Wraith")
        {
            other.GetComponent<Wraith>().die();
            Destroy(this.gameObject, 0f);
            this.hasCollided = true;

        }
        else if (other.tag == "GolemHitbox")
        {
            other.GetComponentInParent<Golem>().die();
            Destroy(this.gameObject, 0f);
            this.hasCollided = true;
        }

        else if (other.tag == "Aravos")
        {
            other.GetComponent<Aravos>().TakeDamage(damage);
            Destroy(this.gameObject);
            this.hasCollided = true;
        }
        else if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
            this.hasCollided = true;
        }
    }
}
