using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public string enemyName;
	public float timeToSpawn = 1.0f;
	public int maxNumberOfEnemies = 1;

	private GameObject enemy;
	private GameObject hudText;
	private GameObject uiRoot;
	// Use this for initialization
	void Start () {
		hudText = (GameObject)Resources.Load("HUDText");
		enemy = (GameObject)Resources.Load ("Enemies/" + enemyName);
		uiRoot = GameObject.Find ("UI Root - Main Game");
		if (enemy.Equals (null)) 
		{
			Debug.Log ("Enemy is null!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length < maxNumberOfEnemies) 
		{
			Spawn ();
		}
	}

	private void Spawn()
	{	
		//TODO: Instantiate with Photon Networking stuff
		//Instantiate Enemy
		GameObject newEnemy = Instantiate (enemy) as GameObject;
		//Instantiate HUD Text
		GameObject hud = Instantiate (hudText) as GameObject;
		hud.transform.parent = uiRoot.transform;
		//attach cameras to HUDText
		UIFollowTarget follow = hud.GetComponent<UIFollowTarget>();
		follow.gameCamera = GameObject.Find ("Main Camera").camera;
		follow.uiCamera = uiRoot.transform.FindChild ("Camera").camera;
		//hook up HUDText to follow this enemy
		follow.target = newEnemy.transform.FindChild("Target").transform;

	}
}
