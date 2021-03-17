using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public PlayerStats playerStats;
    public float damage;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Destroy());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerStats.TakeDamage(damage);
            Destroy(gameObject, 0.0f);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject, 0.0f);

    }

}
