using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseControl : MonoBehaviour
{

    //PHASE 1 TRIGGERS
    public Text PhaseTip;
    public Collider DOOR1; //Tells us that we don't have the keys (MOVES to PHASE2)
    public Collider BATHSHELF1;//The Bathshelf is stuck
    public Collider DRAWER1;//Generic
    public Collider WINDOW;
    public Collider PHONE1;//Generic
    public Collider POLISH1;//Generic
    // PHASE 2 TRIGGERS
    public Collider DOOR2;//Generic (Closed)
    public Collider DRAWER2;//Generic + No keys -- Now that I remember.. (MOVES to PHASE3)
    //PHASE 3 TRIGGERS
    public Collider BOOK; //Item Interactable
    public Collider PHONE3;//GameOpen
    public Collider BATHSHELF3;//Stuck + I need something.. (OPEN = PHASE4)
    public Collider POLISH3; //Generic + Item Interactable
    //PHASE 4 TRIGGERS
    public Collider BATHSHELF4;
    public Collider PHONE5;//ADD beginning hint


    public Collider PHONE6;
    
    
    public int PhaseNumber;
    
//---------------------------------------------------------------------------
    
    void Start()
    {
        
    }
    void Update()
    {
        if ( PhaseNumber == 2)
        {
            PHASE2();
        }

        if ( PhaseNumber == 3)
        {
            PHASE3();
        }

        if ( PhaseNumber == 4)
        {
            PHASE4();
        }
        if ( PhaseNumber == 5)
        {
            PHASE5();
        }

        if ( PhaseNumber == 6)
        {
            PHASE6();
        }
    }

//---------------------------------------------------------------
    void PHASE2()
    {
        DOOR1.enabled = false;
        DRAWER1.enabled = false;

        DOOR2.enabled = true;
        DRAWER2.enabled = true;

        PhaseTip.text = " * If I recall correctly... I usually keep my keys in the BEDROOM dresser.";
    }

    void PHASE3()
    {
        DRAWER2.enabled = false;
        PHONE1.enabled = false;
        BATHSHELF1.enabled = false;
        POLISH1.enabled = false;

        PHONE3.enabled = true;
        BOOK.enabled = true;
        BATHSHELF3.enabled = true;
        POLISH3.enabled = true;
<<<<<<< HEAD
=======

        PhaseTip.text = " * Seems I've lost my keys. I need to call the landlord for a spare. I keep a number of contacts somewhere around the house...";
>>>>>>> df39ae9 (Added Interaction Outlines)
    }

    void PHASE4()
    {
        BATHSHELF3.enabled = false;
        POLISH3.enabled = false;

        BATHSHELF4.enabled = true;
    }

    void PHASE5() //finale
    {
        BATHSHELF4.enabled = false;
        PHONE5.enabled = true;
        PHONE3.enabled = false;
    }

    void PHASE6() //finale
    {
        PHONE6.enabled = true;
        PHONE5.enabled = false;
    }

    //button function
    public void Changer(int INTO)
    {
        PhaseNumber = INTO;
    }
    
}
