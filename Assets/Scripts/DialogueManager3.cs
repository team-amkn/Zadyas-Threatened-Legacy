using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager3 : Dialogue
{
    public Aravos aravos;
    
    protected override void  Start()
    {
        base.Start();
        aravos = FindObjectOfType<Aravos>();
    }

    
    void Update()
    {
        
    }
   
    public override void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < (dialogueSentences.Length - 1))
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);

            this.dialogueSentences = null;
            index = 0;

            player.GetComponent<Player>().enabled = true;
            
            aravos.enabled = true;
            

        }
    }

}
