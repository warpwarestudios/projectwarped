using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

	//animator
	//private Animator animator;

	// standard movement values
	public float maxSpeed = 10f;
	public bool facingRight = false;

	//Damage Responce
	public float takenDamage = 0.2f;

	
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
		float Hmove = Input.GetAxis ("Horizontal");
		float Vmove = Input.GetAxis ("Vertical");
		rigidbody2D.velocity= new Vector2 (Hmove * maxSpeed, Vmove * maxSpeed);
		//animator.SetFloat ("Speed", Mathf.Abs (move));
		
		//Flips Sprite
		if (Hmove > 0 && !facingRight) 
			Flip ();
		else if (Hmove < 0 && facingRight) 
			Flip ();
		
	}
	
	// Flips Sprite
	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public IEnumerator TakenDamage()
	{
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = false;
		yield return new WaitForSeconds(takenDamage);
		renderer.enabled = true;
		yield return new WaitForSeconds(takenDamage);

	}
}