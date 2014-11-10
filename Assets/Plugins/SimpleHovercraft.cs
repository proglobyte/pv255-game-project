using UnityEngine;
using System.Collections;

public class SimpleHovercraft : MonoBehaviour {
	
	Transform fan;
	public float power;
	public string player;
	private float nextReset = 0.0f;
	private float resetFrequency = 0.5f;
	public int energy = 0;
	public int maxEnergy = 100;
	public float speed;
	private const float speedConstant = 8;

	private Vector3 lastPosition;
	
	void Start () {
		fan = transform.Find("Fan");
		lastPosition = this.transform.position;
	}

	public void AddEnergy(int energy) {
		this.energy += energy;
		if (this.energy > this.maxEnergy)
			this.energy = this.maxEnergy;
	}

	void FixedUpdate () {
		
		float r = Input.GetAxis("Horizontal"+player) * -10;
		
		fan.localRotation = Quaternion.Euler(0,r,0);
		
		float force = Input.GetAxis("Vertical"+player) * power;
		
		rigidbody.AddForceAtPosition( fan.forward * force, fan.position );

		this.speed = Vector3.Distance (lastPosition, this.transform.position) * speedConstant;
		lastPosition = this.transform.position;
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