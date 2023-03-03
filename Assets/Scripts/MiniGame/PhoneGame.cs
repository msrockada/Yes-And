using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneGame : MonoBehaviour
{


    public Text NumberDialed;
    public GameObject GameUI;
    private Queue<string> pnumber;
    public string keynumber;
    public Collider trigger1;
    public Collider trigger2;

    public DialogueTrigger Hint; //The Collider we use to give a hint
    public AudioSource PhoneRing;
    public Animator RingAnimation;

    private bool HadWon = false;

    // Start is called before the first frame update
    void Start()
    {
        pnumber = new Queue<string>(0);
    }

    // Update is called once per frame
    void Update()
    {
        NumberDialed.text = "";

        
        foreach ( string item in pnumber)
        {
            NumberDialed.text += item ;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pnumber.Clear();
            GameUI.SetActive(false);
            FindObjectOfType<Pause>().enabled = true;

            if(HadWon == false)
            {
                Hint.TriggerDialogue();
            }
            else{

                FindObjectOfType<PhaseControl>().PhaseNumber = 5;
                FindObjectOfType<CharacterControl>().enabled = true;

            }
            
        }

        if (NumberDialed.text == keynumber)
        {
            Win();
        }
        
        
        
    }

    public void AddNumber(string bnumber)
    {

        pnumber.Enqueue(bnumber);
        
    }

    public void ClearNumber()
    {
        pnumber.Clear();
    }

    void Win()
    {
        NumberDialed.text = "Correct! - Press ESC to close";
        FindObjectOfType<PhaseControl>().PhaseNumber = 5;
        trigger1.enabled = false;
        HadWon = true;
        PhoneRing.Play();
        RingAnimation.SetBool("Ringing", true);
        
    }
}
