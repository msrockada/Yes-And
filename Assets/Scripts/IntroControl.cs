using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroControl : MonoBehaviour
{
    public GameObject CutScene;
    public AudioSource PhoneSound;

    private int linecountmanager;
    private bool hasplayed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        linecountmanager = FindObjectOfType<DialogueManager>().linecount;


        if (linecountmanager == 4)
        {
            if(hasplayed == false)
            {
                PhoneSound.Play();
                hasplayed = true;
            }
            
        }
        
    }
}
