using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fdt : MonoBehaviour {

	public List<Texture2D> frames = new List<Texture2D>();
	public int framesPerSecond = 10;
	Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}

	void Update() {
		int index = (int) (Time.time * framesPerSecond) % frames.Count;
		renderer.material.mainTexture = frames[index];
	}
};
