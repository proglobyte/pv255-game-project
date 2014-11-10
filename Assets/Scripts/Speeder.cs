using UnityEngine;
using System.Collections;

public class Speeder : MonoBehaviour {

	public float force;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Speeder"))
		{
			var rb = this.GetComponentInParent<Rigidbody>();
			rb.AddForce(other.transform.forward * force);
		}
	}
}
