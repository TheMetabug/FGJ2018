using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyManager : NetworkLobbyManager {

	// Use this for initialization

	private Dictionary<int, int> currentPlayers;
	public int player = 0;
	void Start()
	{
		currentPlayers = new Dictionary<int, int>();
	}
	public override GameObject OnLobbyServerCreateLobbyPlayer(NetworkConnection conn, short playerControllerId)
    {
		Debug.Log(currentPlayers);
		Debug.Log(conn.connectionId);
        if(!currentPlayers.ContainsKey(conn.connectionId))
            currentPlayers.Add(conn.connectionId, 0);

        return base.OnLobbyServerCreateLobbyPlayer(conn, playerControllerId);
    }

    public override GameObject OnLobbyServerCreateGamePlayer(NetworkConnection conn, short playerControllerId)
    {
		if (currentPlayers.ContainsKey(conn.connectionId))
            currentPlayers[conn.connectionId] = player++;
        int index = currentPlayers[conn.connectionId];

	Debug.Log(spawnPrefabs[index]);
	Debug.Log(spawnPrefabs[index].transform.position);

        GameObject _temp = (GameObject)GameObject.Instantiate(spawnPrefabs[index],
            spawnPrefabs[index].transform.position,
            Quaternion.identity);
		
        return _temp;
    }
}
