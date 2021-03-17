using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Dialogue : MonoBehaviour
{
    public Dialogue dialogueManager;

    void Start()
    {

        dialogueManager.dialogueBox.SetActive(false);

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
                "Jareth: You and your brother have always had faint traces of the ancient's bloodline.\nI sensed that in both of you when I saw you and your mother that night in the forest.\n" +
                "So, I decided to transfer my powers to you and your brother to save your lives" +
                "\nand what's left of the Ancients' heritage.",
                "Axel: How!? It has been known that the Ancients are extinct!\n"+
                "Jareth: Hahaha, that’s not true. I thought I was the one and only Ancient. But apparently,\nyou guys are Ancients too. " +
                "I have kept my real identity hidden all " +
                "that time as I knew\nabout Aravos’s evil plans, " +
                "and I knew that an old man like me can never stop him.",
                "Axel: Evil plans? I thought Aravos was one of the elder council protecting our beloved Zadya\n"+
                "Jareth: Hahaha, a good man!? Very funny. Aravos has always planned to take over Zadya\nand step over the" +
                " other members of the elder council by exploiting the powers\nof the Ancients.\n",
                " Jareth: As he knew that both of you are Ancients too, " +
                "he thought what an easy prey\nto catch, hahaha",
                "Axel: Hey, that’s not funny! I must save my brother and find a cure for my mother.\n" +
                "Jareth: Here, take this. This grimoire will help you use your Ancient powers. Forgive me\nyoung fella, " +
                "I have become too old to do anything to stop Aravos."
            };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.CurrentCoroutine = dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
