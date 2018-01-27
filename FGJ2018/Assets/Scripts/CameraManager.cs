using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public GameObject[] cameras;
	public GameObject activeCamera;

	// Use this for initialization
	void Start () {
		activeCamera = cameras[0];
	}
	
	// Update is called once per frame
	void Update () {
		activeCamera.GetComponent<Camera>().enabled = false;
		if (Input.GetKey(KeyCode.Keypad0))
		{
			activeCamera = cameras[0];
		}
		else if (Input.GetKey(KeyCode.Keypad1))
		{
			activeCamera = cameras[1];
		}
		else if (Input.GetKey(KeyCode.Keypad2))
		{
			activeCamera = cameras[2];
		}
		else if (Input.GetKey(KeyCode.Keypad3))
		{
			activeCamera = cameras[3];
		}
		else if (Input.GetKey(KeyCode.Keypad4))
		{
			activeCamera = cameras[4];
		}
		activeCamera.GetComponent<Camera>().enabled = true;
	}
}
