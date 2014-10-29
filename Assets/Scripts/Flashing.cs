using UnityEngine;
using System.Collections;

public class Flashing : MonoBehaviour {
	private Light light;
	private float intensity;
	private float alpha = 0.0f;
	// Use this for initialization
	void Start () {
		light = GetComponent("Light") as Light;
		intensity = this.light.intensity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		alpha += 0.06f;
		this.light.intensity = this.intensity - this.intensity * 0.7f * Mathf.Abs (Mathf.Sin (alpha));
	}
}
