using UnityEngine;
using System.Collections;

public class EnemyAggro : MonoBehaviour {
	
	public bool spotted = false;
	// Use this for initialization

	private GameObject player;
	private GameObject rayStart;
	private GameObject rayEnd;
	public float minDist = 5;
	public float maxSpeed = 20;

	void Start()
	{
		player = GameObject.FindWithTag ("Player");
		rayStart = this.transform.Find ("RaycastStart").gameObject;
		rayEnd = this.transform.Find("RayCastEnd").gameObject;
	}
	void Update () 
	{
		Raycasting ();
	}

	public void Aggro()
	{
		if (Vector2.Distance (transform.position, player.transform.position) >= minDist) 
		{
			this.rigidbody2D.velocity = Vector2.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
		}
	}

	void Raycasting ()
	{
		Debug.DrawLine (rayStart.transform.position, rayEnd.transform.position, Color.green);
		spotted = Physics2D.Linecast (rayStart.transform.position, rayEnd.transform.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	
}
