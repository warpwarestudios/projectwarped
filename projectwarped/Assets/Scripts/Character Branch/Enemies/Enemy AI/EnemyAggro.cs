using UnityEngine;
using System.Collections;

public class EnemyAggro : MonoBehaviour {
	
	public bool spotted = false;
	private RandomEnemyMovement enemyMovement;
	private GameObject player;
	private GameObject rayStart;
	private GameObject enemy;
	private GameObject skillGen;
	private GameObject bullet;
	public float maxSpeed = 100;
	private Vector3 middleRay;
	private Vector3 leftMiddleRay;
	private Vector3 leftRay;
	private Vector3 rightMiddleRay;
	private Vector3 rightRay;
	private float rayDistance = 2.5f;
	public bool isRanged;
	private float cooldown = 1f;
	private float range = 3f;
	private float coolDown;
	private Vector2 rightLeftSpeed = Vector2.right * 400;
	private Vector2 upDownSpeed = Vector2.up * 400;

	void Start()
	{
		bullet = (GameObject)Resources.Load("TestBullet");
		enemyMovement = this.GetComponent<RandomEnemyMovement>();
		player = GameObject.FindWithTag ("Player");
		rayStart = this.transform.Find ("RaycastStart").gameObject;
		enemy = GameObject.FindWithTag ("Enemy");
		skillGen = enemy.transform.Find ("Skill").gameObject;
		
	}
	void Update () 
	{
		Raycasting ();
	}

	public IEnumerator Aggro()
	{
		
			if (Vector2.Distance (transform.position, player.transform.position) >= (rayDistance * 10)) 
			{
				if (!isRanged)
				{
					this.rigidbody2D.velocity = Vector2.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
				}
				else
				{
					RangedDamage();
				}
				
			}
		yield return null;
	}

	void Raycasting ()
	{
		if (enemyMovement.facingRight)
		{
			leftRay = new Vector3 (rayDistance, rayDistance, 0);
			leftMiddleRay = new Vector3 (rayDistance, rayDistance/2, 0);
			middleRay = new Vector3 (rayDistance, 0, 0);
			rightMiddleRay = new Vector3 (rayDistance, -rayDistance/2, 0);
			rightRay = new Vector3 (rayDistance, -rayDistance, 0);
		}
		if (enemyMovement.facingDown)
		{
			leftRay = new Vector3 (rayDistance, -rayDistance, 0);
			leftMiddleRay = new Vector3 (rayDistance/2, -rayDistance, 0);
			middleRay = new Vector3 (0, -rayDistance, 0);
			rightMiddleRay = new Vector3 (-rayDistance/2, -rayDistance, 0);
			rightRay = new Vector3 (-rayDistance, -rayDistance, 0);
		}
		if (enemyMovement.facingLeft)
		{
			leftRay = new Vector3 (-rayDistance, rayDistance, 0);
			leftMiddleRay = new Vector3 (-rayDistance, rayDistance/2, 0);
			middleRay = new Vector3 (-rayDistance, 0, 0);
			rightMiddleRay = new Vector3 (-rayDistance, -rayDistance/2, 0);
			rightRay = new Vector3 (-rayDistance, -rayDistance, 0);
		}
		if (enemyMovement.facingUp)
		{
			leftRay = new Vector3 (-rayDistance, rayDistance, 0);
			leftMiddleRay = new Vector3 (-rayDistance/2, rayDistance, 0);
			middleRay = new Vector3 (0, rayDistance, 0);
			rightMiddleRay = new Vector3 (rayDistance/2, rayDistance, 0);
			rightRay = new Vector3 (rayDistance, rayDistance, 0);
		}
			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + leftRay, Color.red);
			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + leftRay, 1 << LayerMask.NameToLayer ("Player"));
			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + leftMiddleRay, Color.magenta);
			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + leftMiddleRay, 1 << LayerMask.NameToLayer ("Player"));
			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + middleRay, Color.green);
			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + middleRay, 1 << LayerMask.NameToLayer ("Player"));
			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + rightMiddleRay, Color.cyan);
			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + rightMiddleRay, 1 << LayerMask.NameToLayer ("Player"));
			Debug.DrawLine (rayStart.transform.position, rayStart.transform.position + rightRay, Color.blue);
			spotted = Physics2D.Linecast (rayStart.transform.position, rayStart.transform.position + rightRay, 1 << LayerMask.NameToLayer ("Player"));
	
	}
	
	public void RangedDamage()
	{
		if (Time.time >= coolDown) 
		{
			if (enemyMovement.facingRight) 
			{
				Shoot(rightLeftSpeed, 1, 0, 0);
			}
			else if (enemyMovement.facingLeft) 
			{
				Shoot(-rightLeftSpeed, 1, 0, 180);
			}
			else if (enemyMovement.facingUp) 
			{
				Shoot(upDownSpeed, 0, 1, 90);
			}
			else if (enemyMovement.facingDown) 
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
