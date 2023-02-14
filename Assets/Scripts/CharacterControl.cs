using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public CharacterController controller;
    public GameObject reference;
    public GameObject triggeron;
    public GameObject DialogueBox;
    public Animator animator; 
    public Animator Danimator;
    
   

    public float speed = 6f;
    bool facingRight = true;
    bool TriggerSpace = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical= Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0f,vertical);
        

        if(direction.magnitude >= 0.1f)
        {
            
            controller.Move(direction * speed * Time.deltaTime);

        }

        if ( horizontal > 0 && !facingRight || horizontal <0 && facingRight)
        {
            Flip();
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Run();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Walk();
        }

        if (Input.GetKeyDown(KeyCode.K) && TriggerSpace == true)
        {
             FindObjectOfType<DialogueTrigger>().TriggerDialogue();
             triggeron.SetActive(false);
             DialogueBox.SetActive(true);
             FindObjectOfType<CharacterControl>().enabled = false;
             Danimator.SetBool("IsOpen",true);
             
        }

    }

    void Flip()
    {
        reference.transform.Rotate(0,180,0);

        facingRight = !facingRight;
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
        TriggerSpace = true;
        FindObjectOfType<DialogueTrigger>().enabled = true;
        
    }

    void OnTriggerExit(Collider other)
    {
        triggeron.SetActive(false);
        TriggerSpace = false;
        FindObjectOfType<DialogueTrigger>().enabled = false;
    }

}
