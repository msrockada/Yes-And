using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject MenuUI;

    bool MenuOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MenuOn == false)
        {
             MenuUI.SetActive(true);
             FindObjectOfType<CharacterControl>().enabled = false;
             FindObjectOfType<CharacterControl>().animator.SetFloat("Speed", 0);
             MenuOn = true;
             
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && MenuOn == true)
        {
             MenuUI.SetActive(false);
             FindObjectOfType<CharacterControl>().enabled = true;
             MenuOn = false;
             
        }
    }
}
