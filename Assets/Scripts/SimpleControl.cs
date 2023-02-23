using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleControl : MonoBehaviour
{

    public DialogueTrigger DialogueStart;
    // Start is called before the first frame update
    void Start()
    {
        DialogueStart.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
