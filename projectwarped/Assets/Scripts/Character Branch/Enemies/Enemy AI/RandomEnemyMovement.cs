using UnityEngine;
using System.Collections;

public class RandomEnemyMovement : MonoBehaviour {
	
	public float maxSpeed = 50f;
	private float Hmove;
	private float Vmove;
	public float movementDelay = 5f;
	public float lookAroundDelay = 5f;
	private float movementOverTime;
	private float lookAroundOverTime;
	private int randomDirection;
	public bool stopMove = false;

	public bool facingRight = false;
	public bool facingUp = false;
	public bool facingDown = false;
	public bool facingLeft = false;
	
	private EnemyAggro eAggro;
	
	// Use this for initialization
	void Start () 
	{
		eAggro = this.GetComponent<EnemyAggro>();
		randomDirection = (int) Random.Range (1f, 4.9f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (eAggro.spotted) 
		{
			eAggro.StartCoroutine(eAggro.Aggro());
		} 
		else
		{
		//	if(stopMove == false)
		//	{
				this.rigidbody2D.velocity = new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed);
				MovementChange ();
		//	}
		//	else
			//{
				//LookAround();
			//}
		}
		
		
	}
	
	void MovementChange()
	{
		if (Time.time >= movementOverTime) 
		{
			randomDirection = (int) Random.Range (1f, 4.9f);
			
			switch (randomDirection)
			{
				case 1:
				{
					MoveRight ();			
					break;
				}
				case 2:
				{
					MoveDown ();				
					break;
				}
				case 3:
				{
					MoveLeft ();			
					break;
				}
				case 4:
				{
					MoveUp ();
					break;
				}
			}
		}
		else
		{
			stopMove = true;
		}
	}
	
//	void LookAround()
//	{
//		int count = 0;
//		
//		if (Time.time >= lookAroundOverTime)
//		{
//			randomDirection = (int) Random.Range (1f, 4.9f);
//			
//			switch (randomDirection) 
//			{
//				case 1:
//				{
//					faceRight ();
//					lookAroundOverTime = Time.deltaTime + lookAroundDelay;
//					count++;			
//					break;
//				}
//				case 2:
//				{
//					faceDown ();
//					lookAroundOverTime = Time.deltaTime + lookAroundDelay;
//					count++;		
//					break;
//				}
//				
//				case 3:
//				{
//					faceLeft ();
//					lookAroundOverTime = Time.deltaTime + lookAroundDelay;
//					count++;
//					break;
//				}
//				case 4:
//				{
//					faceUp ();
//					lookAroundOverTime = Time.deltaTime + lookAroundDelay;
//					count++;
//					break;
//				}
//			}
//			
//		}
//		
//		if (count >= 4)
//		{
//			stopMove = false;
//			count = 0;
//		}
		
//	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Collision") 
		{
			switch (randomDirection) {
			case 1:
			{
				MoveLeft ();	
				randomDirection = (int) Random.Range (1f, 4.9f);
				break;
			}
			case 2:
			{
				MoveUp ();
				randomDirection = (int) Random.Range (1f, 4.9f);
				break;
			}
			case 3:
			{
				MoveRight ();
				randomDirection = (int) Random.Range (1f, 4.9f);
				break;
			}
			case 4:
			{
				MoveDown ();
				randomDirection = (int) Random.Range (1f, 4.9f);
				break;
			}
			}
		}
		
	}
	
	void faceRight()
	{
		facingRight = true;
		facingDown = false;
		facingLeft = false;
		facingUp = false;
	}
	
	void faceDown()
	{
		facingRight = false;
		facingDown = true;
		facingLeft = false;
		facingUp = false;
	}
	
	void faceLeft()
	{
		facingRight = false;
		facingDown = false;
		facingLeft = true;
		facingUp = false;	
	}
	
	void faceUp()
	{
		facingRight = false;
		facingDown = false;
		facingLeft = false;
		facingUp = true;
	}
	
	void MoveRight()
	{
		faceRight();
		Hmove = Time.deltaTime;
		Vector2 scale = transform.localScale;
		scale.x *= 1;
		Vmove = 0;
		movementOverTime = Time.time + movementDelay;
	}
	
	void MoveLeft()
	{
		faceLeft();
		Hmove = -Time.deltaTime;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		Vmove = 0;
		movementOverTime = Time.time + movementDelay;
	}
	
	void MoveUp()
	{
		faceUp();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= 1;
		Vmove = Time.deltaTime;
		movementOverTime = Time.time + movementDelay;
	}
	
	void MoveDown()
	{
		faceDown();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= -1;
		Vmove = -Time.deltaTime;
		movementOverTime = Time.time + movementDelay;
	}
}
