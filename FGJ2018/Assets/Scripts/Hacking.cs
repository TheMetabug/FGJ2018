using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Hacking : NetworkBehaviour
{
    [SyncVar]
    public int hackScore; //random score from succesful hacks
    [SyncVar]
    public bool hacking; // payer is hacking the PC

    public KeyCode hackButton; // button for hackking
    public bool hackable; // sneaker can hack the point: 1)player is in hackpoint 2) hackpoint is not yet hacked
    public HackingSpot hackSpot; // last visited/current hackpoint
    public GameObject asdfg;
    public Alert AlertSystem;

    private bool isAlerted;

    void Start()
    {
        AlertSystem = GameObject.Find("AlertSystem").GetComponent<Alert>();
        isAlerted = false;
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
                if (hackSpot.hackTimeLeft < 0)
                {
                    hackable = false;
                    hackSpot.hacked = true;
                    Debug.Log("hacker hacked point " + hackSpot.pointID);
                    hackScore++;
                    GameObject.Find("GameState").GetComponent<GameStateManager>().hackerScore++;
                }
            }
            if (Input.GetKeyUp(hackButton))
            {
                hacking = false;
                hackSpot.hackTimeLeft = hackSpot.HackTime;
                /*hackSpot.changeMaterial(1);
                hackSpot.hacked = true;            
                Debug.Log("hacker hacked point " + hackSpot.pointID);
                hackScore++; */
            }
        }
        
        StartAlert();
        StopAlert();
    }

    void StartAlert()
    {
        if (!isAlerted && hacking)
        {
            AlertSystem.StartWarning();
            isAlerted = true;
        }
    }

    void StopAlert()
    {
        if (isAlerted && hackSpot.hacked && !hacking)
        {
            AlertSystem.StopWarning();
            isAlerted = false;
        }
    }
}
