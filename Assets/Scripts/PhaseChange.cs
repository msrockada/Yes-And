using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseChange : MonoBehaviour
{
    private bool StartedDialogue;
    private bool InTrigger;
    public int ChangeTO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && InTrigger == true)
        {
            StartedDialogue = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
         InTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
         InTrigger = false;
         if(StartedDialogue == true)
         {
            FindObjectOfType<PhaseControl>().PhaseNumber = ChangeTO;
         }
    }

    
}
