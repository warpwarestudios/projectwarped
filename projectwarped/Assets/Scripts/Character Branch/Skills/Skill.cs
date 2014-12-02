using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour{

	//public to inheritors
	protected string skillName;
	protected int baseDamage;
	protected int baseHeal;
	protected int baseSanityHeal;
	protected int baseSanityCost;
	protected float stat;

	//private
	private float _range;
	private float _cooldown;
	private float _overtime;

	//properties for private variables
	public float range {
		get {
			return _range;
		}
		set{
			_range = value;
		}
	}
	public float cooldown {
		get {
			return _cooldown;
		}
		set{
			_cooldown = value;
		}
	}
	public float overtime {
		get {
			return _overtime;
		}
		set{
			_overtime = value;
		}
	}

	// Use this for initialization
	public void Start()
	{
		this.skillName = "";
		this.cooldown = 0f;
		this.overtime = 0f;
		this.range = 0.0f;
		this.baseDamage = 0;
		this.baseHeal = 0;
		this.baseSanityHeal = 0;
		this.baseSanityCost = 0;
		this.stat = 0f;
	}


	public virtual void meleeDamage(){}
	public virtual void rangedDamage(){}
	public virtual void Heal(){}
	public virtual void sanityHeal(){}
	public virtual void FlatStatIncrease(){}
	public virtual void PercentStatIncrease(){}
	public virtual void Use(){}
}
