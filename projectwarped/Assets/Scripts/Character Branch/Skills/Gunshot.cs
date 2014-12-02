using UnityEngine;
using System.Collections;


public class Gunshot : Skill {

	private GameObject bullet;
	private GameObject player;
	private float coolDown;
	private PlayerController playerDirection;
	private Vector2 rightLeftSpeed = Vector2.right * 400;
	private Vector2 upDownSpeed = Vector2.up * 400;

	//constructor that initializes the skill constructor and fills in the values needed
	public Gunshot() : base("Gunshot",0.5f,0f,1.25f,10,0,0,0,0f)
	{
	}

	void Start()
	{
		bullet = (GameObject)Resources.Load("TestBullet");

		player = GameObject.Find ("TestPlayer");
		playerDirection = player.GetComponent<PlayerController>();

	}
	void Update()
	{

	}

	public override void rangedDamage()
	{
		if (Time.time >= coolDown) 
		{
			if (playerDirection.facingRight) 
			{
				Shoot(rightLeftSpeed, 0);
			}
			else if (playerDirection.facingLeft)
			{
				Shoot(-rightLeftSpeed, 180);
			}
			else if (playerDirection.facingUp) 
			{
				Shoot(upDownSpeed, 90);
			}
			else if (playerDirection.facingDown) 
			{
				Shoot(-upDownSpeed, 270);
			}
		}
	}

 	private void Shoot(Vector2 directions, float angle)
	{
		GameObject newBullet = Instantiate (bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		//newBullet.transform.parent = player.gameObject.transform;
		//newBullet.transform.position = new Vector2 (player.transform.position.x + 50, player.transform.position.y + 0);
		newBullet.transform.eulerAngles = new Vector3 (0, 0, angle);
		newBullet.rigidbody2D.AddForce (directions);
		coolDown = Time.time + GetCoolDown();
		Destroy (newBullet.gameObject, GetRange());

	}


}
