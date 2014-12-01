using UnityEngine;
using System.Collections;


public class Gunshot : Skill {

	GameObject bullet;

	//constructor that initializes the skill constructor and fills in the values needed
	public Gunshot() : base("Gunshot",1.0f,1f,10f,10,0,0,0,0f)
	{

	}

	public override void rangedDamage()
	{

	}
}
