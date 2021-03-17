using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AravosDialogue : MonoBehaviour
{
   public DialogueManager3 dialogueManager;
    public Aravos aravos;
    
    void Start()
    {
        dialogueManager.dialogueBox.SetActive(false);
        aravos = FindObjectOfType<Aravos>();
        dialogueManager.aravos.enabled = false;
        
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
                "Aravos: I am impressed little boy but you will never stand a chance against ME!\n"+
                 "Axel: You will not get away with this! I'll save you Alex!"
            };
         
            dialogueManager.SetSentences(dialogue);
            dialogueManager.CurrentCoroutine = dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            GetComponent<BoxCollider2D>().enabled = false;


        }
    }
}
