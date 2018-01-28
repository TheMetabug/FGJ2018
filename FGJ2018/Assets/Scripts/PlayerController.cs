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
        GameObject.Find("Camera_sneaker").GetComponent<AudioListener>().enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {            
        if (!isLocalPlayer)
        {
             return;
        }
        if (!GameObject.Find("GameState").GetComponent<GameStateManager>().sneakerGaught)
        {
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player2(Clone)")
        {
            GameObject.Find("GameState").GetComponent<GameStateManager>().sneakerGaught = true;
        }
    }
}
