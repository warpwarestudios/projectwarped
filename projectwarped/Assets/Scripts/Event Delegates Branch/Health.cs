using UnityEngine;
using System.Collections;

public class Health: MonoBehaviour {
	
	public float maxHealth = 100f;
	public float _currentHealth = 100f;
	public HUDText floatText = new HUDText();	

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
	
	void OnCollisionEnter2D (Collision2D collision) {
		Damage damage = collision.gameObject.GetComponent<Damage>();
		if (damage) {
			currentHealth -= damage.amountOfDamage;
			floatText.Add (damage.amountOfDamage, Color.red, 0.5f);
			onDamageTaken();
		}
	}
}
