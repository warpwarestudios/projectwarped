using UnityEngine;
using System.Collections;

public class MeleeAttack : Skill {

	private GameObject meleeMove;
	private GameObject player;
	private float coolDown;
	private PlayerController playerDirection;
	private Vector2 rightLeftSpeed = Vector2.right * 150;
	private Vector2 upDownSpeed = Vector2.up * 150;
	//constructor that initializes the skill constructor and fills in the values needed
	public MeleeAttack() : base("Melee Attack",0.5f,0f,0.20f,10,0,0,0,0f)
	{
	}
	
	void Start()
	{
		meleeMove = (GameObject)Resources.Load("TestMelee");

		player = GameObject.Find ("TestPlayer");
		playerDirection = player.GetComponent<PlayerController>();
		
	}
	void Update()
	{
		
	}
	
	public override void meleeDamage()
	{
		if (Time.time >= coolDown) 
		{
			if (playerDirection.facingRight) 
			{
				Slash(rightLeftSpeed, 0);
			}
			else if (playerDirection.facingLeft)
			{
				Slash(-rightLeftSpeed, 180);
			}
			else if (playerDirection.facingUp) 
			{
				Slash(upDownSpeed, 90);
			}
			else if (playerDirection.facingDown) 
			{
				Slash(-upDownSpeed, 270);
			}
		}
	}
	
	private void Slash(Vector2 directions, float angle)
	{
		GameObject newSlash = Instantiate (meleeMove, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
		//newBullet.transform.parent = player.gameObject.transform;
		//newBullet.transform.position = new Vector2 (player.transform.position.x + 50, player.transform.position.y + 0);
		newSlash.transform.eulerAngles = new Vector3 (0, 0, angle);
		newSlash.rigidbody2D.AddForce (directions);
		coolDown = Time.time + GetCoolDown ();
		Destroy (newSlash.gameObject, GetRange());
		
	}

}
