using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControl : MonoBehaviour
{
    public string Scene;

    public DialogueTrigger DialogueStart;
    // Start is called before the first frame update
    void Start()
    {
        if (Scene == "main")
        {
            FindObjectOfType<CharacterControl>().enabled = false;
        }
        DialogueStart.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
