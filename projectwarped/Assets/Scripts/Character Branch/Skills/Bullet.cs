﻿using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	void OnCollisionEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Collision")
		{	
			//Destroy Bullet
			Destroy(gameObject);
		}
	}
	

}