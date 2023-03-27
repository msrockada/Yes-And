using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroControl : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject CutScene;
    public AudioSource PhoneSound;
=======
    public AudioSource PhoneSound;
    public Animator Scene;
>>>>>>> df39ae9 (Added Interaction Outlines)

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
<<<<<<< HEAD

=======
        Scene.SetInteger("Scene",linecountmanager);
>>>>>>> df39ae9 (Added Interaction Outlines)

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
