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

	private bool movingUp;
	private bool movingRight;
	private bool movingDown;
	private bool movingLeft;
	private bool normal;
	private bool reverse;
	private bool upAndDown = false;
	private bool leftAndRight = false;

	public enum MovementPattern{
				CounterClockwise,
				Clockwise,
				LeftToRight,
				RightToLeft,
				UpToDown,
				DownToUp,
				None
		};
	public MovementPattern movePattern;

	private Transform sightStart, sightEnd;
	private GameObject enemy;
	private GameObject rayCastStart;
	private GameObject rayCastEnd;
	// Use this for initialization
	void Awake()
	{
		Flip ();
		MoveSwitch ();


		//enemy = GameObject.Find ("testEnemy").
		//rayCastStart.GetComponentInChildren = enemy.transform.FindChild ("RayCastStart");
		//sightStart = Vector2(rayCastEnd.transform.position.x, rayCastEnd.transform.position.y);
		//rayCastEnd = enemy.transform.FindChild ("RayCastEnd");
		//sightEnd = Vector2(rayCastEnd.transform.position.x, rayCastEnd.transform.position.y);

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
		//Raycasting ();
		MovementChange ();
		rigidbody2D.velocity = new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed);
		//animator.SetFloat ("Speed", Mathf.Abs (move));
		
		//Flips Sprite
		if (Hmove > 0 && !facingRight) 
			Flip ();
		else if (Hmove < 0 && facingRight) 
			Flip ();
		
	}

//	void Raycasting ()
//	{
//		Debug.DrawLine (sightStart, sightEnd, Color.green);
//	}

	void MoveSwitch()
	{
		switch (movePattern) {
		case MovementPattern.CounterClockwise:
		{
			MoveSequence (false, true, false, true, true, false);
			break;
		}
		case MovementPattern.Clockwise:
		{
			MoveSequence (false, true, false, true, true, false);
			break;
		}
		case MovementPattern.UpToDown:
		{
			upAndDown = true;
			MoveSequence (true, false, false, false, true, false);
			break;
		}
		case MovementPattern.DownToUp:
		{
			upAndDown = true;
			MoveSequence (false, false, true, false, true, false);
			break;
		}
		case MovementPattern.LeftToRight:
		{
			leftAndRight = true;
			MoveSequence (false, false, false, true, false, true);
			break;
		}
		case MovementPattern.RightToLeft:
		{
			leftAndRight = true;
			MoveSequence (false, true, false, false, false, true);
			break;
		}
		case MovementPattern.None:
		{
			break;	
		}
		}
	}

	void MoveSequence(bool up, bool right, bool down, bool left, bool norm, bool rev)
	{
		movingUp = up;
		movingRight = right;
		movingDown = down;
		movingLeft = left;
		normal = norm;
		reverse = rev;
	}
	void MovementDirection()
	{
		if (movingUp && Time.time >= overTime)
		{
			if (upAndDown)
			{
				MoveUp();
				movingUp = reverse;
				movingDown = normal;
				MovementChange();
			}
			else
			{
				MoveUp();
				movingUp = reverse;
				movingRight = normal;
				MovementChange();
			}
		}
		if (movingRight && Time.time >= overTime)
		{
			if (leftAndRight)
			{
				MoveRight();
				movingLeft = reverse;
				movingRight = normal;
				MovementChange();
			}
			else
			{
				MoveRight();
				movingRight = reverse;
				movingDown = normal;
				MovementChange();
			}
		}
		if (movingDown && Time.time >= overTime)
		{
			if (upAndDown)
			{
				MoveDown();
				movingDown = reverse;
				movingUp = normal;
				MovementChange();
			}
			else
			{
				MoveDown();
				movingDown = reverse;
				movingLeft = normal;
				MovementChange();
			}
		}
		if (movingLeft && Time.time >= overTime)
		{
			if (leftAndRight)
			{
				MoveLeft();
				movingRight = reverse;
				movingLeft = normal;
				MovementChange();
			}
			else
			{
				MoveLeft();
				movingLeft = reverse;
				movingUp = normal;
				MovementChange();
			}
		}
	}

	void MovementChange()
	{
		if (Time.time >= overTime) 
		{
			MovementDirection();
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
