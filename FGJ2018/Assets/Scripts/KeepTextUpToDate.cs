using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTextUpToDate : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		int hacked = GameObject.Find("GameState").GetComponent<GameStateManager>().hackerScore;
		int hackedMax = GameObject.Find("GameState").GetComponent<GameStateManager>().maxHackScore;
		if (!GameObject.Find("GameState").GetComponent<GameStateManager>().isDone)
		{
			string infoText = "Points hacked: " + hacked + "/" + hackedMax;
			GetComponent<UnityEngine.UI.Text>().text = infoText;
		}
		else
		{
			if (hacked >= hackedMax)
			{
				GetComponent<UnityEngine.UI.Text>().text = "SNEAKER WINS! Returning to lobby...";
			}
			else
			{
				GetComponent<UnityEngine.UI.Text>().text = "GUARD WINS! Returning to lobby...";
			}
		}
	}
}
