using UnityEngine;
using System.Collections;

public class HUDDamageText : MonoBehaviour {

	public HUDText hudText;
	// Update is called once per frame
	void Update () {
		hudText.Add (Time.deltaTime * 10f, Color.white, 0f);
	}
}
