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
    public bool hacking; // payer is hacking the PC
    public Alert AlertSystem;

    void Start()
    {
        AlertSystem = GameObject.Find("AlertSystem").GetComponent<Alert>();
    }


    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "hackSpot")
        {
            hackSpot = col.gameObject.GetComponent<HackingSpot>();
            if (hackSpot.hacked == false) //hackpoint hasn't been hacked 
            { 
                hackable = true;
            }  
            else
            {
                hackable = false;
            }       
        }
    }
    void OnTriggerExit(Collider col)
    {
        hackable = false; // player leaves the hackpoint
        AlertSystem.StopWarning();
        hacking = false;
        hackSpot.hackTimeLeft = hackSpot.HackTime;



    }
    void Update()
    {
        if (hackable)
        {
            if (Input.GetKey(hackButton))
            {
                hackSpot.hackTimeLeft -= Time.deltaTime;
                hacking = true;
                AlertSystem.StartWarning();
                if (hackSpot.hackTimeLeft < 0)
                {
                    AlertSystem.StopWarning();
                    hackable = false;
                    hackSpot.changeMaterial(1);
                    hackSpot.hacked = true;
                    Debug.Log("hacker hacked point " + hackSpot.pointID);
                    hackScore++;
                }
            }
            if (Input.GetKeyUp(hackButton))
            {
                AlertSystem.StopWarning();
                
                hacking = false;
                hackSpot.hackTimeLeft = hackSpot.HackTime;
                /*hackSpot.changeMaterial(1);
                hackSpot.hacked = true;            
                Debug.Log("hacker hacked point " + hackSpot.pointID);
                hackScore++; */
            }

        }
    }
}
