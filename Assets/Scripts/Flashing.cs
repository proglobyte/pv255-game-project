using UnityEngine;
using System.Collections;

public class Flashing : MonoBehaviour {
	private Light lightSource;
	private float intensity;
	private float alpha = 0.0f;
	// Use this for initialization
	void Start () {
		lightSource = GetComponent("Light") as Light;
		intensity = this.lightSource.intensity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		alpha += 0.06f;
		this.lightSource.intensity = this.intensity - this.intensity * 0.7f * Mathf.Abs (Mathf.Sin (alpha));
	}
}
