using UnityEngine;
using System.Collections;

public class SimpleHovercraft : MonoBehaviour {
	Transform fan;
	private Transform body;
	private Player player;
	private float nextReset = 0.0f;
	private float resetFrequency = 0.5f;
	public float speed;
	private const float speedConstant = 8;
	private Vector3 lastPosition;

	private int rotationStep = 1;
	public int maxRotation = 30;
	private int currentRotation = 0;
	private bool handlingLock = false;
	private int back = 1;

	void Start () {
		fan = transform.Find("Fan");
		body = transform.Find ("hover");
		lastPosition = this.transform.position;
		player = GetComponent<Player>();
	}

	void FixedUpdate () {
		//thrusters
		float force = Input.GetAxis("Vertical"+player.id) * player.power;
		rigidbody.AddForceAtPosition( fan.forward * force, fan.position );

		//rotation on direction change

		if (!handlingLock) {
			if (Vector3.Dot (transform.position - lastPosition, transform.forward) < -0.1f)
				back = -1;
			else
				back = 1;
		}

		var horizontalAxis = Input.GetAxis ("Horizontal" + player.id);
		handlingLock = true;
		if (force >= 0 || speed < 15) {
			handlingLock = false;
		}
		float torque = horizontalAxis * back;
		float torqueForce =  torque * player.power * 4;
		if (torque != 0) {
			if (Mathf.Abs(currentRotation) <= maxRotation) {
				currentRotation += (int)(Mathf.Sign(torque) * rotationStep * back);
				body.Rotate (-Vector3.right * Mathf.Sign(torque) * rotationStep * back);
			}
				} else if (Mathf.Abs(currentRotation) > 0) {
			body.Rotate (Vector3.right * Mathf.Sign(currentRotation) * rotationStep);
			currentRotation += (int)(-Mathf.Sign(currentRotation) * rotationStep);
		}

		//changing direction
		rigidbody.AddTorque (this.transform.up * torqueForce);

		//speed calculation
		this.speed = Vector3.Distance (lastPosition, this.transform.position) * speedConstant;
		lastPosition = this.transform.position;

		//sound
		float volumeFromSpeed = speed;
		if(volumeFromSpeed >= 20){
			volumeFromSpeed = 20;
		}
		audio.volume = (volumeFromSpeed / 0.2f) / 100f;
	}

	void Update() {
		if (Input.GetButton ("Reset"+player.id) && Time.time > nextReset ) {
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
