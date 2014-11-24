using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings ("0.01");
		//GameObject myGameObject = PhotonNetwork.Instantiate ("prefab", Vector2.zero, Quaternion.identity, 0);
	}

	void OnPhotonRandomJoinFailed () 
	{
		Debug.Log("Error joining random room.");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedLobby () 
	{
		PhotonNetwork.JoinRandomRoom ();
	}

	// this may be unneccesary for NGUI
	void OnGui () 
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
