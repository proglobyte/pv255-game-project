using UnityEngine;
using System.Collections;

public class SimpleHovercraft : MonoBehaviour {
	
	Transform fan;
	public float power;
	public string player;
	private float nextReset = 0.0f;
	private float resetFrequency = 0.5f;
	
	void Start () {
		fan = transform.Find("Fan");
	}
	
	void FixedUpdate () {
		
		float r = Input.GetAxis("Horizontal"+player) * -10;
		
		fan.localRotation = Quaternion.Euler(0,r,0);
		
		float force = Input.GetAxis("Vertical"+player) * power;
		
		rigidbody.AddForceAtPosition( fan.forward * force, fan.position );
		
		//Camera.main.transform.LookAt(transform);
	}

	void Update() {

		if (Input.GetButton ("Reset"+player) && Time.time > nextReset ) {
			nextReset = Time.time + resetFrequency;
			var pos = this.transform.position;
			pos.y += 50;
			this.transform.position = pos;
			var rot = this.transform.rotation;
			rot.x = 0;
			rot.z = 0;
			this.transform.rotation = rot;
		}
	}
}