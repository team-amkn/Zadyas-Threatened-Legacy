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
    private Coroutine currentCoroutine; //To store the current running coroutine so it can be stopped using StopCoroutine easily if needed

    //setter and getter for currentCoroutine
    public Coroutine CurrentCoroutine { get => currentCoroutine; set => currentCoroutine = value; }

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
        continueButton.SetActive(true); //To be able to skip dialogue from the beginning if needed
        player.anim.SetFloat("Speed", 0f);
        player.enabled = false;

        foreach (char letter in dialogueSentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public virtual void SetSentences(string[] sentences)
    {
        this.dialogueSentences = sentences;
    }
    public virtual void NextSentence()
    {
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
            StopCoroutine(CurrentCoroutine); //To stop the final coroutine if the player clicks on skip before it actually finishes
        }
    }
}
