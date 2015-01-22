using UnityEngine;
using System.Collections;

public class RaycastEnemyMovement : MonoBehaviour {

	public float maxSpeed = 50f;
	private float Hmove;
	private float Vmove;
	public float movementDelay = 5f;
	public float lookAroundDelay = 5f;
	
	public bool facingRight = false;
	public bool facingUp = false;
	public bool facingDown = false;
	public bool facingLeft = false;
	
	private EnemyAggro eAggro;
	
	private Vector3 frontRay;
	private Vector3 leftMiddleRay;
	private Vector3 leftRay;
	private Vector3 rightMiddleRay;
	private Vector3 rightRay;
	private float rayDistance = 2.5f;
	
	RaycastHit2D frontSide;
	RaycastHit2D leftSide;
	RaycastHit2D rightSide;

	// Use this for initialization

	// Update is called once per frame
	void Update () 
	{
//		Debug.DrawLine (transform.position, transform.position + frontRay, Color.green);
//		Debug.DrawLine (transform.position, transform.position + leftRay, Color.red);
//		Debug.DrawLine (transform.position, transform.position + rightRay, Color.blue);
//		
//		if(Physics2D.Linecast (transform.position, transform.position + frontRay, 1 << LayerMask.NameToLayer ("Collision")))
//		{
//			//Make sure ray is not hitting itself
//			if(frontSide.transform != transform) 
//			{
//				
//			}
//		}
//		if(Physics2D.Linecast (transform.position, transform.position + leftRay, 1 << LayerMask.NameToLayer ("Collision")))
//		{
//			//Make sure ray is not hitting itself
//			if(frontSide.transform != transform) 
//			{
//				
//			}
//		}
//		if(Physics2D.Linecast (transform.position, transform.position + rightRay, 1 << LayerMask.NameToLayer ("Collision")))
//		{
//			//Make sure ray is not hitting itself
//			if(frontSide.transform != transform) 
//			{
//				
//			}
//		}
	}
	
	
	void RayCastSide()
	{
		if (facingRight)
		{
			leftRay = new Vector3 (rayDistance, rayDistance, 0);
			
			frontRay = new Vector3 (rayDistance, 0, 0);
			
			rightRay = new Vector3 (rayDistance, -rayDistance, 0);
		}
		if (facingDown)
		{
			leftRay = new Vector3 (rayDistance, -rayDistance, 0);
			
			frontRay = new Vector3 (0, -rayDistance, 0);
			
			rightRay = new Vector3 (-rayDistance, -rayDistance, 0);
		}
		if (facingLeft)
		{
			leftRay = new Vector3 (-rayDistance, rayDistance, 0);

			frontRay = new Vector3 (-rayDistance, 0, 0);

			rightRay = new Vector3 (-rayDistance, -rayDistance, 0);
		}
		if (facingUp)
		{
			leftRay = new Vector3 (-rayDistance, rayDistance, 0);
			frontRay = new Vector3 (0, rayDistance, 0);
			rightRay = new Vector3 (rayDistance, rayDistance, 0);
			
		}
		
//			Debug.DrawLine (transform.position, rayStart.transform.position + leftRay, Color.red);
//			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + leftRay, 1 << LayerMask.NameToLayer ("Player"));
//			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + leftMiddleRay, Color.magenta);
//			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + leftMiddleRay, 1 << LayerMask.NameToLayer ("Player"));
//			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + rightMiddleRay, Color.cyan);
//			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + rightMiddleRay, 1 << LayerMask.NameToLayer ("Player"));
//			
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
//Faces and Movements	
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
	}
	
	void MoveLeft()
	{
		faceLeft();
		Hmove = -Time.deltaTime;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		Vmove = 0;
	}
	
	void MoveUp()
	{
		faceUp();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= 1;
		Vmove = Time.deltaTime;
	}
	
	void MoveDown()
	{
		faceDown();
		Hmove = 0;
		Vector2 scale = transform.localScale;
		scale.y *= -1;
		Vmove = -Time.deltaTime;
	}
}