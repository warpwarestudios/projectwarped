using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings ("0.01");
		PhotonNetwork.logLevel = PhotonLogLevel.Full;
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

	void OnJoinedRoom()
	{
		GameObject myGameObject = PhotonNetwork.Instantiate ("TestPlayer", Vector2.zero, Quaternion.identity, 0);
		//CharacterControl controller = monster.GetComponent<CharacterControl>();
		//controller.enabled = true;
	}

	// this may be unneccesary for NGUI
	void OnGui () 
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}
}
