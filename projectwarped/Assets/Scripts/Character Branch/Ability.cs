using UnityEngine;
using System.Collections;

public class Ability : MonoBehaviour {

	Skill rangeAttack = new Skill ("Range Attack", Time.time, 1.25f, 1.25f, 1, 0);

	public void MyClickFunction()
	{
		Debug.Log ("I was clicked");
	}
	void RangeAttack()
	{
		rangeAttack.GetCoolDown ();

	}
}
