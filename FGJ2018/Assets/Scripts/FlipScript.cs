using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour {

	public float flipTime = 2;
	public float hackingTime = 0.25f;
	public float hackingTimeNormal = 0.5f;
	private float timer = 0;
	public Hacking hackingScript;  

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (hackingScript.hacking)
		{
			flipTime = hackingTime;
		}
		else
		{
			flipTime = hackingTimeNormal;
		}
		if (flipTime < timer)
		{
			timer = 0;
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
		}
	}
}
