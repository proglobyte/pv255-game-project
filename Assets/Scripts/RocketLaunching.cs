using UnityEngine;
using System.Collections;

public class RocketLaunching : MonoBehaviour {

	public GameObject target;
	public GameObject rocket;
	public string player;
	private float nextRocket = 0.0f;
	private float rocketFrequency = 0.5f;
	public int energyCost;
	public bool avaible;
	//public GameObject warmup;
	// Use this for initialization
	void Start () {
		avaible = false;
	}

	void Fire() {
		nextRocket = Time.time + rocketFrequency;
		var rocketInstance = Instantiate (rocket, transform.position + transform.forward.normalized * 60f, transform.rotation) as GameObject;
		rocketInstance.GetComponent<BasicRocket> ().parent = this.gameObject;
		rocketInstance.GetComponent<BasicRocket> ().target = target;
		(this.gameObject.GetComponent ("SimpleHovercraft") as SimpleHovercraft).energy -= energyCost;
		avaible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if((this.gameObject.GetComponent ("SimpleHovercraft") as SimpleHovercraft).energy < energyCost){avaible=false;}

		if (avaible) {
			if (Input.GetButton ("Fire" + player)) {
				Fire();
			}
		}
		else {
			if ( ((this.gameObject.GetComponent ("SimpleHovercraft") as SimpleHovercraft).energy >= energyCost) && (Time.time >= nextRocket) ) {
				avaible = true;
			}

		}

	}
}
