using UnityEngine;
using System.Collections;

public class HealthBar: MonoBehaviour {
	
	public Health health;
	public UIProgressBar healthBar;
	// sign up for the event when you're enabled
	void OnEnable () {
		if (health) health.onDamageTaken += UpdateHealth;
	}
	
	// stop listening when you're disabled
	void OnDisable () {
		if (health) health.onDamageTaken -= UpdateHealth;
	}
	
	void UpdateHealth () {
		healthBar.value = health.currentHealth/health.maxHealth;
	}
}
