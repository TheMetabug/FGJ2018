﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingSpot : MonoBehaviour
{
   public string pointID;
   public bool hacked;
    public Material[] Materials;
    Renderer rd;

    void Start()
    {
        rd = GetComponent<Renderer>();
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