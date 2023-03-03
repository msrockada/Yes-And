using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource music;
    public Animator Radio;

    private bool intrigger =  false;
    private bool isplaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.K) && intrigger == true)
         {
            if (isplaying == false)
            {
                Radio.SetBool("MusicOn",true);
                music.Play();
                isplaying = true;
            }
            else{
                music.Pause();
                Radio.SetBool("MusicOn",false);
                isplaying = false;
            }

         }
    
    }

    void OnTriggerEnter(Collider other)
    {
        intrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        intrigger = false;
    }
}
