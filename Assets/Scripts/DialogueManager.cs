using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
   

    private Queue<string> sentences;

    


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

    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log ("This is"+ dialogue.log);
        sentences.Clear();
        
        nameText.text = dialogue.name;

        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
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

    void EndDialogue()
    {
        
        FindObjectOfType<CharacterControl>().enabled = true;
        FindObjectOfType<TriggerManager>().enabled = true;
        FindObjectOfType<TriggerManager>().DialogueBox.SetActive(false);

    }
}
