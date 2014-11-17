using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	// Variables
	private string skillName;
	private int baseDamage;
	private int baseHeal;
	private int baseSanityHeal;
	private int baseSanityCost;
	private float baseCooldown;
	private float overtime;
	private float stat;

	// Use this for initialization
	void Start () {}

	// Methods
	void Damage(){}
	void Heal(){}
	void sanityHeal(){}
	void FlatStatIncrease(){}
	void PercentStatIncrease(){}
}
