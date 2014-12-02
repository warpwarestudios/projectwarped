using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour {
	
	public float maxHealth = 100f;
	public float _currentHealth = 100f;

	public HUDText floatText = null;	

	public float currentHealth {
		get { 
			return _currentHealth; 
		}
		set { 
			if(value <= maxHealth)
			{
				_currentHealth = value; 
			}
			else
			{
				_currentHealth = maxHealth;
			}
		}
	}

	public delegate void OnDamageTaken();
	public event OnDamageTaken onDamageTaken = delegate {};
	
	void OnCollisionEnter2D (Collision2D collision) 
	{
		Damage damage = collision.gameObject.GetComponent<Damage> ();
		Debug.Log("Collision: " + collision.gameObject.tag + "GameObject: " + this.gameObject.tag);
		if (damage && collision.gameObject.tag != this.gameObject.tag) 
		{
			currentHealth -= damage.amountOfDamage;
			if (floatText != null) 
			{
				floatText.Add (-damage.amountOfDamage, Color.red, 1.0f);
			}
			onDamageTaken ();
		}
	}
	void OnTriggerEnter2D (Collider2D collision) 
	{
		Damage damage = collision.gameObject.GetComponent<Damage> ();
		Debug.Log("Collision: " + collision.gameObject.tag + "GameObject: " + this.gameObject.tag);
		if (damage && collision.gameObject.tag != this.gameObject.tag) 
		{
				currentHealth -= damage.amountOfDamage;
				if (floatText != null) 
				{
					floatText.Add (-damage.amountOfDamage, Color.red, 1.0f);
				}
				onDamageTaken ();
		}
		if (_currentHealth <= 0) 
		{
				if (floatText) 
				{
					Destroy (floatText.gameObject);
				}
				Destroy (this.gameObject);
		}
	}

}
