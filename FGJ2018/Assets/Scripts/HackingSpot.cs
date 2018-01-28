using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HackingSpot : NetworkBehaviour
{
    [SyncVar]
    public bool hacked;

    public string pointID;
    public float HackTime;
    public float hackTimeLeft;
    public Material[] Materials;
    public Alert AlertSystem;
    Renderer rd;
    private bool hasUpdatedHacked;
    void Start()
    {
        rd = GetComponent<Renderer>();
        hasUpdatedHacked = false;
    }

    void Update()
    {
        if(!hasUpdatedHacked && hacked)
        {
            changeMaterial(1);
            hasUpdatedHacked = true;
        }
    }

   void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Player")
        {
            Debug.Log("hacker in point " + pointID);
            
        }
    }

    public void changeMaterial(int state)
    {
        rd.material = Materials[state];
    }
}
