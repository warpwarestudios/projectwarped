using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	public float range;
	
	public void Update()
	{
		if (this.transform.position.x > range) 
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Collision")
		{	
			//Destroy Bullet
			Destroy(gameObject);
		}
	}
}
