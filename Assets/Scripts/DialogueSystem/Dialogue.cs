using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public bool interactable;
    public bool game;
    public GameObject gameUI;
    public string itemname;
    public int emotion;
    public int cutsceneno;
    [TextArea(3,10)]
    public string[] sentences;
    
}
