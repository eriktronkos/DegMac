using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneScript : MonoBehaviour {

	public Renderer rend;
	public Material mat;
	// Use this for initialization
	void Start () {
		rend = GetComponent<MeshRenderer> ();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
