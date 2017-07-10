using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ongui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		Event e = Event.current;
		if (e.isKey)
			Debug.Log("Detected key code: " + e.keyCode);
	}
}
