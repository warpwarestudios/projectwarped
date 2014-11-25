using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	// Variables
	private string skillName;
	private int baseDamage;
	private int baseHeal;
	private int baseSanityHeal;
	private int baseSanityCost;
	private float range;
	private float cooldown;
	private float overtime;
	private float stat;

	public Skill (string skillName, float cooldown, float overTime, float range, int baseDamage, int baseSanityCost)
	{
		this.skillName = skillName;
		this.cooldown = cooldown;
		this.overtime = overTime;
		this.range = range;
		this.baseDamage = baseDamage;
		this.baseSanityCost = baseSanityCost;
	}

	public Skill (string skillName, float cooldown, float overTime, float range, int baseDamage, int baseSanityCost, int baseHeal)
	{
		this.skillName = skillName;
		this.cooldown = cooldown;
		this.overtime = overTime;
		this.range = range;
		this.baseDamage = baseDamage;
		this.baseSanityCost = baseSanityCost;
		this.baseHeal = baseHeal;
	}

	public Skill (string skillName, float cooldown, float overtime, float range, int baseDamage, int baseSanityCost, int baseHeal, int baseSanityHeal)
	{
		this.skillName = skillName;
		this.cooldown = cooldown;
		this.overtime = overtime;
		this.range = range;
		this.baseDamage = baseDamage;
		this.baseSanityCost = baseSanityCost;
		this.baseHeal = baseHeal;
		this.baseSanityHeal = baseSanityHeal;
		
	}
	// Use this for initialization
	// Methods
	public string GetSkillName()
	{
		return skillName;
	}

	public float GetCoolDown()
	{
		return cooldown;
	}

	public float GetOverTime()
	{
		return overtime;
	}

	public float GetRange()
	{
		return range;
	}

	public void Damage(){}
	public void Heal(){}
	public void sanityHeal(){}
	public void FlatStatIncrease(){}
	public void PercentStatIncrease(){}
}
