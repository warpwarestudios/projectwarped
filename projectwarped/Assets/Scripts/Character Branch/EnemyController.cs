using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//animator
	//private Animator animator;
	
	// standard movement values
	public float maxSpeed = 50f;
	public bool facingRight = false;
	private float Hmove;
	private float Vmove;
	public float delay = 5f;
	private float overTime;
	private bool movingUp = true;
	private bool movingRight = false;
	private bool movingDown = false;
	private bool movingLeft = false;
	// Use this for initialization
	void Start()
	{
		Flip ();
		//animator = GetComponent<Animator>();
	}
	
	// FixedUpdate updates at regular intervals
	// For physics calculations
	void FixedUpdate()
	{
		
	}
	
	// Update updates at irregular intervals for maximum accuracy
	void Update()
	{
		// enables sprite movement
		MovementChange ();
		rigidbody2D.velocity = new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed);
		//animator.SetFloat ("Speed", Mathf.Abs (move));
		
		//Flips Sprite
		if (Hmove > 0 && !facingRight) 
			Flip ();
		else if (Hmove < 0 && facingRight) 
			Flip ();
		
	}
	
	void MovementChange()
	{
		if (Time.time >= overTime) 
		{
			if (movingUp)
			{
				MoveUp();
				movingUp = false;
				movingRight = true;
				MovementChange();
			}
			else if (movingRight)
			{
				MoveRight();
				movingRight = false;
				movingDown = true;
				MovementChange();
			}
			else if (movingDown)
			{
				MoveDown();
				movingDown = false;
				movingLeft = true;
				MovementChange();
			}
			else if (movingLeft)
			{
				MoveLeft();
				movingLeft = false;
				movingUp = true;
				MovementChange();
			}
		}
	}
	// Flips Sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	
	void MoveRight()
	{
		Hmove = Time.deltaTime;
		Vmove = 0;
		overTime = Time.time + delay;
	}
	
	void MoveLeft()
	{
		Hmove = -Time.deltaTime;
		Vmove = 0;
		overTime = Time.time + delay;
	}
	
	void MoveUp()
	{
		Hmove = 0;
		Vmove = Time.deltaTime;
		overTime = Time.time + delay;
	}
	
	void MoveDown()
	{
		Hmove = 0;
		Vmove = -Time.deltaTime;
		overTime = Time.time + delay;
	}
}
