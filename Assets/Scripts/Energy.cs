﻿using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	public int energy;
	private int resetTimer;
	public int resetTime;
	private bool reset = false;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Hovercraft")) {
			(other.transform.parent.gameObject.GetComponent("SimpleHovercraft") as SimpleHovercraft).AddEnergy(this.energy);
		}
		(this.transform.Find("Visual")).gameObject.SetActive(false);
		(this.GetComponent("Collider") as Collider).enabled = true;
		resetTimer = 0;
		reset = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (reset) {
			if (++resetTimer > resetTime) {
				reset = false;
				(this.transform.Find("Visual")).gameObject.SetActive(true);
				(this.GetComponent("Collider") as Collider).enabled = true;
			}
		}
	}
}