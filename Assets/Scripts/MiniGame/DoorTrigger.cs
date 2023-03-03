using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject triggeron;
    public Animator dooranimation;

    private bool triggerspace = false;
    private bool closed = true;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && triggerspace == true )
        {
             triggeron.SetActive(false);
             if (closed == true)
             {
                dooranimation.SetBool("IsClosed", false);
                closed = false;
             }
             else
             {
                dooranimation.SetBool("IsClosed", true);
                closed = true;
             }
             
             
             
        }
    }

    void OnTriggerEnter(Collider other)
    {
        triggeron.SetActive(true);  
        triggerspace = true;
              
    }

    void OnTriggerExit(Collider other)
    {
        triggeron.SetActive(false);
        triggerspace = false;

    }
}
