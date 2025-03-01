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
            StopCoroutine(CurrentCoroutine); //To stop the previous coroutine if it was running
            textDisplay.text = "";
            CurrentCoroutine = StartCoroutine(TypeDialogue()); //Set the current working coroutine to a new coroutine with new sentence since we did index++
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogueBox.SetActive(false);
            Speaker.enabled = false;
            this.dialogueSentences = null;
            index = 0;
            player.GetComponent<Player>().enabled = true;
            aravos.enabled = true;
            StopCoroutine(CurrentCoroutine); //To the final coroutine if the player clicks on skip before it actually finishes
        }
    }

}
