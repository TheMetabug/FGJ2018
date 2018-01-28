using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameStateManager : NetworkBehaviour
{
	[SyncVar]
	public int hackerScore;
	
	[SyncVar]
	public bool sneakerGaught;

	public int maxHackScore = 3;
	public bool isDone = false;
	// Use this for initialization
	void Start ()
	{
		hackerScore = 0;
		sneakerGaught = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hackerScore >= maxHackScore)
		{
			Debug.Log("SNEAKER WINS");
			if (isServer && !isDone)
			{
				Debug.Log("Call");
				StartCoroutine("WaitAndReturn");
			}
			isDone = true;
		}
		if (sneakerGaught)
		{
			Debug.Log("GUARD WINS");
			if (isServer && !isDone)
			{
				Debug.Log("Call");
				StartCoroutine("WaitAndReturn");
			}
			isDone = true;
		}
	}

	IEnumerator WaitAndReturn()
	{
		GameObject.Find("Player2(Clone)").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().mouseenabled = true;
		yield return new WaitForSeconds(4);
		GameObject.Find("NetworkManagerObject").GetComponent<LobbyManager>().ServerChangeScene("Lobby");
		yield return null;
	}

}
