using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;

	public float maxSpeed = 3f;
	public float moveForce = 365f;
	public Vector2 velocity;
	public float vert;
	public float hort;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update()
	{
		//gets inputs
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");

		vert = vertical;
		hort = horizontal;

		//determine direction pressed, change animation, add force to create movement
		if (vertical > 0)
		{
			rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			animator.SetInteger("Direction", 2);
			if(vertical * rigidbody2D.velocity.y < maxSpeed * 2) 			
				rigidbody2D.AddForce(Vector2.up * vertical * moveForce); 
		}
		else if (vertical < 0)
		{
			rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			animator.SetInteger("Direction", 0);
			if(vertical * rigidbody2D.velocity.y < maxSpeed * 2) 			
				rigidbody2D.AddForce(Vector2.up * vertical * moveForce); 
		}
		else if (horizontal > 0)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0);
			animator.SetInteger("Direction", 3);
			if(horizontal * rigidbody2D.velocity.y < maxSpeed) 			
				rigidbody2D.AddForce(Vector2.right * horizontal * moveForce); 
		}
		else if (horizontal < 0)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,0);
			animator.SetInteger("Direction", 1);
			if(horizontal * rigidbody2D.velocity.y < maxSpeed) 			
				rigidbody2D.AddForce(Vector2.right * horizontal * moveForce); 
		}
		else
		{
			//set idle animation then stop velocity
			if(rigidbody2D.velocity.x > 0)
			{
				animator.SetInteger("Direction", 6);
			}
			else if(rigidbody2D.velocity.x < 0)
			{
				animator.SetInteger("Direction", 5);
			}
			else if(rigidbody2D.velocity.y < 0)
			{
				animator.SetInteger("Direction", 4);
			}
			rigidbody2D.velocity = new Vector2(0,0);
		}

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed * 2 )
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed * 2);

		velocity = rigidbody2D.velocity;
	}
}
