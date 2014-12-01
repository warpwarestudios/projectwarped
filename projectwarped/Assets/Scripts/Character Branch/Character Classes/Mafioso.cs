using UnityEngine;
using System.Collections;

public class Mafioso : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject buttonOne = GameObject.Find ("Skill 1");
		this.gameObject.AddComponent<Gunshot> ();
		buttonOne.GetComponent<UIButton> ().onClick = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
