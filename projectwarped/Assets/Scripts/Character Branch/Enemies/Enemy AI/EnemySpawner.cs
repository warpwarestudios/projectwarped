using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public string enemyName;
	public float timeToSpawn = 1.0f;
	public int maxNumberOfEnemies = 1;
	public int randomRangeMin = 2;
	public int randomRangeMax = 3;

	private GameObject enemy;
	private GameObject hudText;
	private GameObject uiRoot;
//	private EnemyController enemyController;
	private UIFollowTarget follow;
	// Use this for initialization
	void Start () {
		hudText = (GameObject)Resources.Load("HUDText");
		enemy = (GameObject)Resources.Load ("Enemies/" + enemyName);
		uiRoot = GameObject.Find ("UI Root-MainGame");

		if (enemy.Equals (null)) 
		{
			Debug.Log ("Enemy is null!");
		}
		if (hudText.Equals (null)) 
		{
			Debug.Log ("HudText is null!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) 
		{
			Spawn ();
		}
	}

	private void Spawn()
	{	
		for (int i = 0; i < maxNumberOfEnemies; i++) 
		{
			//TODO: Instantiate with Photon Networking stuff
			//Instantiate Enemy at random range and different angle
			var randomRange = Random.Range (randomRangeMin, randomRangeMax);
			var angle = i * Mathf.PI * 2 / maxNumberOfEnemies;
			Vector3 pos = this.transform.position + new Vector3 (Mathf.Cos (angle), Mathf.Sin (angle), 0) * randomRange;
			GameObject newEnemy = Instantiate (enemy, pos, Quaternion.identity) as GameObject;
			//Instantiate HUD Text
			GameObject hud = Instantiate (hudText) as GameObject;
			//hud.transform.parent = uiRoot.transform;
			//Following script
			follow = hud.GetComponent<UIFollowTarget> ();
			//	enemyController = newEnemy.GetComponent<EnemyController>();
			//	enemyController.movePattern = enemyController.movePatternArray [Random.Range (0f, float.Parse(enemyController.movePatternArray.GetLength()))];
			//hook up HUDText to follow this enemy
			follow.target = newEnemy.transform.FindChild ("Target").transform;
			//attach cameras to HUDText
			follow.gameCamera = GameObject.FindGameObjectWithTag ("MainCamera").camera;
			follow.uiCamera = uiRoot.transform.FindChild ("Camera").camera;
			//add hudText to enemy
			Health eHealth = newEnemy.GetComponent<Health> ();
			eHealth.floatText = hud.GetComponent<HUDText> ();
			//set healthbar to track health
			HealthBar eHealthBar = hud.GetComponentInChildren<HealthBar> ();
			eHealthBar.health = eHealth;
		}
	}
}
