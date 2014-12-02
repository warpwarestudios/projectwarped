using UnityEngine;
using System.Collections;


public class Gunshot : Skill {

	private GameObject bullet;
	private GameObject player;
	private float coolDown;
	private float attackRate;
	private PlayerController playerDirection;
	private Vector2 rightLeftSpeed = Vector2.right * 500;
	private Vector2 upDownSpeed = Vector2.up * 500;
	//constructor that initializes the skill constructor and fills in the values needed
	public Gunshot() : base("Gunshot",1.0f,0f,10f,10,0,0,0,0f)
	{
		attackRate = GetCoolDown();
	}

	void Start()
	{
		bullet = (GameObject)Resources.Load("Bullet");
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

	public void Shoot(Vector2 directions, float angle)
	{

		GameObject newBullet = Instantiate (bullet) as GameObject;
		newBullet.transform.parent = player.gameObject.transform;
		newBullet.transform.position = new Vector2 (0, 0);
		newBullet.transform.eulerAngles = new Vector3 (newBullet.transform.position.x, newBullet.transform.position.y, angle);
		newBullet.rigidbody2D.AddForce (directions);
		coolDown = Time.time + attackRate;

	}


}
