using UnityEngine;
using System.Collections;

public class HealthBar: MonoBehaviour {
	
	public Health health;
	
	// sign up for the event when you're enabled
	void OnEnable () {
		if (health) health.onDamageTaken += UpdateHealth;
	}
	
	// stop listening when you're disabled
	void OnDisable () {
		if (health) health.onDamageTaken -= UpdateHealth;
	}
	
	void UpdateHealth () {
		transform.localScale = new Vector3(health.currentHealth/(health.maxHealth/2), 0.2f, 1);
	}
}
