using UnityEngine;
using System.Collections;

public class Class : MonoBehaviour {

	// Variables
    private ArrayList activeSkills;
	private Ability passSkill;
	private float healthModifier;
	private float sanityModifier;

	// Use this for initialization
	void Start () {}

	// Methods
	public Skill GetSkill()
	{
		return null;
	}

	public float GetHealth()
	{
		return 0.0f;
	}

	public float GetSanity()
	{
		return 0.0f;
	}
}
