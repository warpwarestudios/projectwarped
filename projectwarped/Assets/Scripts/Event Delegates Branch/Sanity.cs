using UnityEngine;
using System.Collections;

public class Sanity: MonoBehaviour {
	
	public int maxSanity = 100;
	public int _currentSanity = 100;
	
	public int currentSanity {
		get { 
			return _currentSanity; 
		}
		set { 
			if(value <= maxSanity)
			{
				_currentSanity = value; 
			}
			else
			{
				_currentSanity = maxSanity; 

			}
		}
	}
	
	public delegate void OnSanitySpent();
	public event OnSanitySpent onSanitySpent = delegate {};
	
	void Update () 
	{
		//Will take some more thought

		//on skill use, subtract cost
		//need more implementation to test anyway
	}
}
