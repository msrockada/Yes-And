using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{

    public bool Intrigger;

    

    void OnTriggerEnter(Collider other)
    {
        Intrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        Intrigger = false;
    }
}
