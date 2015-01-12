using UnityEngine;
using System.Collections;

public class RandomEnemyMovement : MonoBehaviour {
	
	public float maxSpeed = 50f;
	private float Hmove;
	private float Vmove;
	public float delay = 5f;
	private float overTime;
	private int randomDirection;
	
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
			eAggro.Aggro ();
		} 
		else 
		{
			MovementChange ();
			rigidbody2D.velocity = new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed);
		}
		
		
	}
	
	void MovementChange()
	{
		if (Time.time >= overTime) 
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
	}
	
	void LookAround()
	{
		randomDirection = (int) Random.Range (1f, 4.9f);
		
		switch (randomDirection) 
		{
			case 1:
			{
				faceRight ();				
				break;
			}
			case 2:
			{
				faceDown ();				
				break;
			}
			case 3:
			{
				faceLeft ();			
				break;
			}
			case 4:
			{
				faceUp ();
				break;
			}
		}
	}
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
		overTime = Time.time + delay;
	}
	
	void MoveLeft()
	{
		faceLeft();
		Hmove = -Time.deltaTime;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		Vmove = 0;
		overTime = Time.time + delay;
	}
	
	void MoveUp()
	{
		faceUp();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= 1;
		Vmove = Time.deltaTime;
		overTime = Time.time + delay;
	}
	
	void MoveDown()
	{
		faceDown();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= -1;
		Vmove = -Time.deltaTime;
		overTime = Time.time + delay;
	}
}
