using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Collision")
		{	
			//Destroy Bullet
			Destroy(this.gameObject);
		}
	}
	
	void FixedUpdate()
	{
		//Destroy Bullet on range
		Destroy(this.gameObject, 1.25f);
	}
}