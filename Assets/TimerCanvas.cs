using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimerCanvas : MonoBehaviour {

	private const string DISPLAY_TEXT_FORMAT = "{0}";
	private const string TIME_FORMAT = "##.#";
	public GameObject greenDots;
	points pointScript;

	private Text textField;
	private float timeleft = 30;


	public Camera cam;

	void Awake() {
		textField = GetComponent<Text>();
	}

	void Start() {
		pointScript = (points) greenDots.GetComponent ("points");
		Debug.Log (pointScript);
		pointScript.enabled = false;

		if (cam == null) {
			cam = Camera.main;
		}

		if (cam != null) {
			// Tie this to the camera, and do not keep the local orientation.
			transform.SetParent(cam.GetComponent<Transform>(), true);
		}
	}

	void LateUpdate() {
		pointScript.enabled = true;
		timeleft -= Time.deltaTime;
		textField.text = string.Format(DISPLAY_TEXT_FORMAT,
			timeleft.ToString(TIME_FORMAT));
		if (timeleft < 0) {
			pointScript.enabled = false;
			timeleft = 0;

			var total = 0;
			var hits = 0;
			var misses = 0;
			foreach (var res in points.answers) {
				total += 1;
				if (res.hit)
					hits += 1;
				misses += res.missHits;
			}

			Debug.Log ("total:" + total);
			Debug.Log ("hits:" + hits);
			Debug.Log ("misses:" + misses);

			this.enabled = false;
		}
				
	}
}
