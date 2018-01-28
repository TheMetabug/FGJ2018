using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        if (!isLocalPlayer)
        {
            return;
        }
        GameObject.Find("Camera_sneaker").transform.parent = this.transform;
        GameObject.Find("Camera_sneaker").GetComponent<Camera>().enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {            
        if (!isLocalPlayer)
        {
            return;
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);


    }
}
