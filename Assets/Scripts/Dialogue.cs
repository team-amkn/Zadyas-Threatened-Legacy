using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    protected string[] dialogueSentences;
    protected int index = 0;
    public float typingSpeed;
    public GameObject continueButton;
    public GameObject dialogueBox; //panel
    public Player player;
    public Image Speaker;


    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
        Speaker.enabled = false;
        dialogueBox.SetActive(false);
        continueButton.SetActive(false);
    }

   
    void Update()
    {

    }

    public IEnumerator TypeDialogue()
    {
        dialogueBox.SetActive(true);
        Speaker.enabled = true;
        player.anim.SetFloat("Speed", 0f);
        player.enabled = false;

        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            if (textDisplay.text == dialogueSentences[index])
                continueButton.SetActive(true);
        }
    }

    public virtual void SetSentences(string[] sentences)
    {
        this.dialogueSentences = sentences;
    }
    public virtual void NextSentence()
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
            Speaker.enabled = false;
            this.dialogueSentences = null;
            index = 0;

            player.GetComponent<Player>().enabled = true;
         

        }
    }
}
