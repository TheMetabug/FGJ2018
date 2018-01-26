using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacking : MonoBehaviour
{
    public int hackScore; //random score from succesful hacks
    public KeyCode hackButton; // button for hackking
    public bool hackable; // sneaker can hack the point: 1)player is in hackpoint 2) hackpoint is not yet hacked
    public HackingSpot hackSpot; // last visited/current hackpoint
    public GameObject asdfg;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "hackSpot")
        {
            hackSpot = col.gameObject.GetComponent<HackingSpot>();
            if (hackSpot.hacked == false) //hackpoint hasn't been hacked 
            { 
                hackable = true;
            }         
        }
    }
    void OnTriggerExit(Collider col)
    {
       hackable = false; // player leaves the hackpoint
 
    }
    void Update()
    {
        if (hackable)
        {
            if (Input.GetKeyUp(hackButton))
            {
                hackable = false;
                hackSpot.changeMaterial(1);
                hackSpot.hacked = true;            
                Debug.Log("hacker hacked point " + hackSpot.pointID);
                hackScore++;
            }
        }
    }
}
