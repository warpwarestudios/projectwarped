using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour {
	
	public int maxHealth = 100;
	public int _currentHealth = 100;

	public int currentHealth {
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
	
	void OnCollisionEnter2D (Collision2D collision) {
		Damage damage = collision.gameObject.GetComponent<Damage>();
		if (damage) {
			currentHealth -= damage.amountOfDamage;
			onDamageTaken();
		}
	}
}
