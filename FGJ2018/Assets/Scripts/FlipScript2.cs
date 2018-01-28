using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript2 : MonoBehaviour {

	public float flipTime = 0.15f;
	public float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (flipTime < timer)
		{
			timer = 0;
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
		}
	}
}
