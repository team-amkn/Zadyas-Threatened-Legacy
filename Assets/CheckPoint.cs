using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Player")){

            if (gameObject.transform.position.x > LevelManger.CurrCheckPoint.transform.position.x)
            {
                LevelManger.CurrCheckPoint = gameObject; 
            }

        }
    }
}
