using UnityEngine;
using System.Collections;

public class MeleeAttack : Skill {

	private GameObject meleeMove;
	private GameObject player;
	private float coolDown;
	private PlayerController playerDirection;
	private Vector2 rightLeftSpeed = Vector2.right * 150;
	private Vector2 upDownSpeed = Vector2.up * 150;

	
	public void Start()
	{
		base.Start ();
		meleeMove = (GameObject)Resources.Load("TestMelee");
		cooldown = 1f;
		range = 0.25f;
		player = GameObject.Find ("TestPlayer");
		playerDirection = player.GetComponent<PlayerController>();
		
	}
	public void Update()
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
		//TODO: Instantiate through Photon Networking
		GameObject newSlash = Instantiate (meleeMove) as GameObject;
		newSlash.transform.parent = player.gameObject.transform;
		newSlash.transform.localPosition = new Vector3 (0,0,0);
		newSlash.transform.localScale = new Vector3 (0.05f,0.05f,0.05f);
		newSlash.transform.eulerAngles = new Vector3 (0, 0, angle);
		newSlash.rigidbody2D.AddForce (directions);
		coolDown = Time.time + cooldown;
		Destroy (newSlash.gameObject, range);
		
	}

}
