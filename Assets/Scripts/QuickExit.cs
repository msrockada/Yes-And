using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickExit : MonoBehaviour
{
    public GameObject PictureUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.K))
        {
            
            PictureUI.SetActive(false);
            FindObjectOfType<Pause>().enabled = true;
            FindObjectOfType<CharacterControl>().enabled = true;
            
        }
    }
}
