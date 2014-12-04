using UnityEngine;
using System.Collections;

public class Gunshot : Skill {

	private GameObject bullet;
	private GameObject player;
	private GameObject skillGen;
	private float coolDown;
	private PlayerController playerDirection;
	private Vector2 rightLeftSpeed = Vector2.right * 400;
	private Vector2 upDownSpeed = Vector2.up * 400;
	private Vector2 posX;
	private Vector2 posY;

	public void Start()
	{
		base.Start ();
		bullet = (GameObject)Resources.Load("TestBullet");
		player = GameObject.Find ("TestPlayer");
		skillGen = player.transform.Find ("Skill").gameObject;
		playerDirection = player.GetComponent<PlayerController>();
		cooldown = 2f;
		range = 2f;
	}
	public void Update()
	{

	}

	public override void rangedDamage()
	{
		if (Time.time >= coolDown) 
		{
			if (playerDirection.facingRight) 
			{
				Shoot(rightLeftSpeed, 1, 0, 0);
			}
			else if (playerDirection.facingLeft)
			{
				Shoot(-rightLeftSpeed, 1, 0, 180);
			}
			else if (playerDirection.facingUp) 
			{
				Shoot(upDownSpeed, 0, 1, 90);
			}
			else if (playerDirection.facingDown) 
			{
				Shoot(-upDownSpeed, 0, -1, 270);
			}
		}
	}

 	private void Shoot(Vector2 directions, float posX, float posY, float angle)
	{
		//TODO: Instantiate through Photon Networking
		GameObject newBullet = Instantiate (bullet) as GameObject;
		newBullet.transform.parent = skillGen.gameObject.transform;
		newBullet.transform.localPosition = new Vector3 (0,0,0);
		skillGen.transform.localPosition = new Vector3 (posX, posY, 0);
		newBullet.transform.localScale = new Vector3 (0.05f,0.05f,0.05f);
		newBullet.transform.eulerAngles = new Vector3 (0, 0, angle);
		newBullet.rigidbody2D.AddForce (directions);
		coolDown = Time.time + cooldown;
		newBullet.GetComponent<Bullet> ().range = range;

	}


}
