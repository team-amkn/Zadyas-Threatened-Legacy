using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
   
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            string[] dialogue =
            {
            "Jareth: Well done my son! Now this portal will lead you to a cave where Zadya’s apex predatory\nfrog lives. " +
            "Be careful young fella, all the courageous men who have tried to enter this cave \nbefore never came back. But that is the only way to Aravos’s lair."
        };

            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
