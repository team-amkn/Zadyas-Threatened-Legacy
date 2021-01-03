using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : Enemy
{

    public float lineOfSight;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public virtual void die()
    {
        Destroy(enemy.gameObject);
    }

    public bool isPlayerWithinLineOfSight()
    {
        if (lineOfSight >= Mathf.Abs(playerStats.transform.position.x - this.transform.position.x))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
