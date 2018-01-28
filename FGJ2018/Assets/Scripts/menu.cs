using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class menu : MonoBehaviour
{
    public KeyCode startKey;
    public LobbyManager lobbyManager;
    public Text startText;
    
	// Use this for initialization
	void Start ()
    {
        

    }

    // Update is called once per frame
    public void ExitButton()
    {
        Application.Quit();
    }

	void Update ()
    {
        if (Input.GetKey(startKey))
        {
            lobbyManager.showLobbyGUI = true;
            lobbyManager.GetComponent<UnityEngine.Networking.NetworkManagerHUD>().showGUI = true;
            startText.enabled = false;
            
        }
		
	}
}
