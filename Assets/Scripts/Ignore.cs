using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    public Collider Box;
    public Collider Player;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(Player, Box);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
