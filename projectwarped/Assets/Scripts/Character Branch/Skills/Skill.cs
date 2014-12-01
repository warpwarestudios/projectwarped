using UnityEngine;
using System.Collections;

public class Skill{

	// Variables
	private string skillName;
	protected int baseDamage;
	protected int baseHeal;
	protected int baseSanityHeal;
	protected int baseSanityCost;
	private float range;
	private float cooldown;
	private float overtime;
	protected float stat;

	//all possible variables
	public Skill (string skillName, float cooldown, float overTime, float range, int baseDamage, int baseHeal, int baseSanityHeal, int baseSanityCost, float stat)
	{
		this.skillName = skillName;
		this.cooldown = cooldown;
		this.overtime = overTime;
		this.range = range;
		this.baseDamage = baseDamage;
		this.baseHeal = baseHeal;
		this.baseSanityHeal = baseSanityHeal;
		this.baseSanityCost = baseSanityCost;
		this.stat = stat;
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

	public virtual void meleeDamage(){}
	public virtual void rangedDamage(){}
	public virtual void Heal(){}
	public virtual void sanityHeal(){}
	public virtual void FlatStatIncrease(){}
	public virtual void PercentStatIncrease(){}
	public virtual void Use(){}
}
