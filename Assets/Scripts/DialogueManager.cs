using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Text ItemList;
    public Animator Portrait;
    
   private int animationnumber;
   private int itemcount = 0;
   private bool canpickup;
   private string newitem;

    private Queue<string> sentences;
    private Queue<string> items;

    


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayNextSentence();
        }
        Portrait.SetInteger("Emotion",animationnumber);

    }

    public void StartDialogue (Dialogue dialogue)
    {
        sentences.Clear();
        animationnumber = dialogue.emotion;
        nameText.text = dialogue.name;

        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        if (dialogue.interactable == true)
        {
            newitem = dialogue.itemname;
            dialogue.interactable = false;
            itemcount += 1;
            sentences.Enqueue("[You've got " + newitem + "]");
        }

    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void AddItem()
    {
        if ( newitem != null  && itemcount <= 1)
        {
            ItemList.text = "*" + newitem;
        }

        else if ( newitem!=null && itemcount > 1)
        {
            ItemList.text = ItemList.text + "\n*" + newitem;
        }
            
    }

    void EndDialogue()
    {
        
        FindObjectOfType<CharacterControl>().enabled = true;
        FindObjectOfType<CharacterControl>().DialogueBox.SetActive(false);
        AddItem();
        newitem = null;
        
        

    }
}
