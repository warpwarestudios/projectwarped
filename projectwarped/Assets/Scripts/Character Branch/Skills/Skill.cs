using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

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

	//Start method to initialize variables
	public void Start()
	{
		this.skillName = "";
		this.cooldown = 0f;
		this.overtime = 0f;
		this.range = 1f;
		this.baseDamage = 0;
		this.baseHeal = 0;
		this.baseSanityHeal = 0;
		this.baseSanityCost = 0;
		this.stat = 0f;
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
