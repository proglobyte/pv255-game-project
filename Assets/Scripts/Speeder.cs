using UnityEngine;
using System.Collections;

public class Speeder : MonoBehaviour {

	public float force = 1800;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("Hovercraft")) {
			other.attachedRigidbody.AddForce(this.transform.forward * force);
		}
	}
}
