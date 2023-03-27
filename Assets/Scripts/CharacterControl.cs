using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public CharacterController controller;
    public GameObject reference;
    public GameObject triggeron;
    public GameObject triggeron2;
    public GameObject DialogueBox;
    public Animator animator; 
    public Animator Danimator;
    public AudioSource Step;
<<<<<<< HEAD
=======


>>>>>>> df39ae9 (Added Interaction Outlines)
    private DialogueTrigger currentFocus;
    
   

    public float speed = 6f;
    
   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

         
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        float walkingspeed = Mathf.Abs(horizontal + vertical);
        Vector3 direction = new Vector3(horizontal,0f,vertical);
    
        

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x*(-1), direction.z*(-1)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
            

        }
       
<<<<<<< HEAD
        animator.SetFloat("Speed", walkingspeed);
=======
        if (horizontal != 0 || vertical != 0){

            animator.SetFloat("Speed", 1);

        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        
>>>>>>> df39ae9 (Added Interaction Outlines)
       
    
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Run();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Walk();
        }

        if (Input.GetKeyDown(KeyCode.K) && currentFocus!= null)
        {
             currentFocus.TriggerDialogue();
             triggeron.SetActive(false);
             triggeron2.SetActive(false);
             DialogueBox.SetActive(true);
             FindObjectOfType<CharacterControl>().enabled = false;
             Danimator.SetBool("IsOpen",true);
             
        }

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
 {
     if (!Step.isPlaying)
     {
         Step.Play();
     }
 }
 else
 {
     // Always stop the audio if the player is not inputting movement.
     Step.Stop();
 }
        

    }


    void Run()
    {
        speed = speed*3;
        animator.SetBool("Run",true);
    }
    void Walk()
    {
        speed = speed/3;
        animator.SetBool("Run",false);
        
    }

    void OnTriggerEnter(Collider other)
    {
        triggeron.SetActive(true);
        triggeron2.SetActive(true);
        currentFocus = other.GetComponent<DialogueTrigger>();

<<<<<<< HEAD
=======
        if ( other.isTrigger == true)
        {
            other.GetComponent<Outline>().enabled = true;
        }
        


>>>>>>> df39ae9 (Added Interaction Outlines)
        
    }

    void OnTriggerExit(Collider other)
    {
        triggeron.SetActive(false);
        triggeron2.SetActive(false);
        currentFocus = null;

<<<<<<< HEAD
=======
        if ( other.isTrigger == true)
        {
            other.GetComponent<Outline>().enabled = false;
        }

>>>>>>> df39ae9 (Added Interaction Outlines)
    }

}
