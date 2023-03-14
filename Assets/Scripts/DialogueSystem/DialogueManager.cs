using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Text ItemList;
    public Animator Portrait;
    public string Scene;
    public AudioSource soundfont;
    public GameObject cutscene;
    public GameObject PhoneUI;
    
    


   private int animationnumber;
   public int linecount;
   private int itemcount = 0;
   private bool minigame;
   private GameObject miniUI; 
   private bool canpickup;
   private string newitem;
   private int cutnumber;

    private Queue<string> sentences;
    private Queue<string> items;

    


    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayNextSentence();

        }
        if(Scene == "main")
        {
            Portrait.SetInteger("Emotion",animationnumber);
        }
        
        if (Scene == "intro")
        {
            if(linecount == cutnumber)
            {
                cutscene.SetActive(true);
            }
        }

    }

    public void StartDialogue (Dialogue dialogue)
    {
        if (Scene == "main")
        {
        FindObjectOfType<CharacterControl>().DialogueBox.SetActive(true);
        FindObjectOfType<CharacterControl>().enabled = false;
        FindObjectOfType<Pause>().enabled = false;
        }

        sentences.Clear();
        linecount = -1;
        animationnumber = dialogue.emotion;
        cutnumber = dialogue.cutsceneno;
        

        if(Scene == "main"){
            nameText.text = dialogue.name;
            minigame = dialogue.game;
            miniUI = dialogue.gameUI;
        }
        

        

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
        linecount += 1;
        soundfont.Play();
        if (sentences.Count == 0)
        {
            soundfont.Pause();
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
        if(Scene == "main")
        {
            if (minigame ==  true)
            {
                miniUI.SetActive(true);
                FindObjectOfType<Pause>().enabled = false;
                FindObjectOfType<CharacterControl>().DialogueBox.SetActive(false);
            }
            
            else
            {
                FindObjectOfType<CharacterControl>().enabled = true;
                FindObjectOfType<Pause>().enabled = true;
                FindObjectOfType<CharacterControl>().DialogueBox.SetActive(false);
                AddItem();
                
            }

            newitem = null;
            minigame = false;
        
        }



        else
        {
            SceneManager.LoadScene("Sample");
        }

        
        
        
        
        

    }
}
