using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerManager : MonoBehaviour
{


    public GameObject triggeron;
    public GameObject DialogueBox;
    public Animator Danimator;
    

    bool TriggerSpace = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && TriggerSpace == true)
        {
             FindObjectOfType<DialogueTrigger>().TriggerDialogue();
             triggeron.SetActive(false);
             DialogueBox.SetActive(true);
             FindObjectOfType<CharacterControl>().enabled = false;
             FindObjectOfType<TriggerManager>().enabled = false;
             Danimator.SetBool("IsOpen",true);
             
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        triggeron.SetActive(true);
        TriggerSpace = true;
        FindObjectOfType<DialogueManager>().enabled = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        triggeron.SetActive(false);
        TriggerSpace = false;
        FindObjectOfType<DialogueManager>().enabled = false;
    }
}
