using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour {
	public GameObject objeto;
	public float maxTimeToAppear;
	public float minTimeToAppear;
	public float maxTimeToBlink;
	public float minTimeToBlink;
	private float timeleftAppear = 1;
	private float timeleftBlink = 1;
	private MeshRenderer mr;
	private bool blinking = false;
	private float blinkTimer = 0;

	public struct Answer{
		public Vector2 point { get; set; }
		public bool hit { get; set; }
		public int missHits { get; set; }
	}

	public static List<Answer> answers;

	// Use this for initialization
	void Start () {
		answers = new List<points.Answer>();
		transform.position = new Vector3 (0f, 0f, 3f);
		mr = (MeshRenderer) gameObject.GetComponent (typeof(MeshRenderer));
		mr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (blinkTimer > 0) {
			blinkTimer -= Time.deltaTime;
		} else {
			blinkTimer = 0;
		}
		if (timeleftBlink >= 0 && blinking) {
			timeleftBlink -= Time.deltaTime;
		}
		if (timeleftBlink < 0 && blinking) {
			mr.enabled = false;
			timeleftBlink = 0;
			blinking = false;
			timeleftAppear = Random.Range (minTimeToAppear, maxTimeToAppear);
		} else {
			timeleftAppear -= Time.deltaTime;

			if (timeleftAppear <= 0 && timeleftBlink >= 0 && !blinking) {
				transform.position = Random.insideUnitCircle * 2.65f;
				transform.position = new Vector3 (transform.position.x, transform.position.y + 1, 3);
				mr.enabled = true;
				blinking = true;
				blinkTimer = 1;
				timeleftBlink = Random.Range (minTimeToBlink, maxTimeToBlink);
				answers.Add (new Answer {
					point = new Vector2 (transform.position.x, transform.position.y),
					hit = false,
					missHits = 0
				});
			}
		}
		Debug.Log ("timeleftAppear " + timeleftAppear);
		Debug.Log ("timeleftBlink " + timeleftBlink);
	}

	void OnGUI()
	{
		if (Event.current.ToString() != "Repaint" && Event.current.ToString() != "Layout")
			//Debug.Log(Event.current);
		if (Event.current.keyCode.ToString() == KeyCode.F7.ToString () && Event.current.type == EventType.KeyDown) {
			//Debug.Log("Recebi F7.");
			if (answers.Count == 0)
				return;
			var tempAns = answers [answers.Count - 1];
			if (blinkTimer > 0) {
				//	Debug.Log("Captei");
				if (answers [answers.Count - 1].hit == false) {
					tempAns.hit = true;
					Debug.Log ("True");
				} else {
					tempAns.missHits += 1;
				}
			} else {
				tempAns.missHits += 1;
			}
			answers [answers.Count - 1] = tempAns;
	}
}
}
