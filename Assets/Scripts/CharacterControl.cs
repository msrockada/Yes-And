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
        Vector3 direction = new Vector3(horizontal,0f,vertical);
        

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x*(-1), direction.z*(-1)) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);

        }


        animator.SetFloat("Speed", Mathf.Abs(horizontal + vertical));
    
        

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
             DialogueBox.SetActive(true);
             FindObjectOfType<CharacterControl>().enabled = false;
             Danimator.SetBool("IsOpen",true);
             
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
        currentFocus = other.GetComponent<DialogueTrigger>();

        
    }

    void OnTriggerExit(Collider other)
    {
        triggeron.SetActive(false);
        currentFocus = null;

    }

}
