using UnityEngine;
using System.Collections;

public class RocketLaunching : MonoBehaviour {

	public GameObject target;
	public GameObject rocket;
	public string player;
	private float nextRocket = 0.0f;
	private float rocketFrequency = 0.5f;
	public int energyCost;
	//public GameObject warmup;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire"+player) && (Time.time > nextRocket) 
		    && ((this.gameObject.GetComponent("SimpleHovercraft") as SimpleHovercraft).energy >= energyCost)) {

			(this.gameObject.GetComponent("SimpleHovercraft") as SimpleHovercraft).energy -= energyCost;

			nextRocket = Time.time + rocketFrequency;
			var rocketInstance = Instantiate (rocket, transform.position + transform.forward.normalized * 60f, transform.rotation) as GameObject;
			rocketInstance.GetComponent<BasicRocket>().parent = this.gameObject;
			rocketInstance.GetComponent<BasicRocket>().target = target;
//			rocketInstance.GetComponent<BasicRocket>().movementForce = 1300;
//			rocketInstance.GetComponent<BasicRocket>().warmupForce = 600;
//			rocketInstance.GetComponent<BasicRocket>().warmupDistance = 150;
//			rocketInstance.GetComponent<BasicRocket>().rotationSpeed = 2;
//			rocketInstance.GetComponent<BasicRocket>().warmup = warmup;
		}
	}
}
