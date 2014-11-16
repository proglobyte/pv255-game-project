using UnityEngine;
using System.Collections;

public class BasicRocket : MonoBehaviour {
	public GameObject target;
	public GameObject parent;
	private GameObject warmupTarget;
	private bool warmupFinished;
	public GameObject warmup;
	public float warmupDistance;
	public float warmupForce;
	public float movementForce;
	public float rotationSpeed;
        public AudioClip sound;
	// Use this for initialization
	void Start () {
		if (target == null) {
			DestroyObject (gameObject); //commits suicide because it has no purpose
			Debug.Log("Goodbye cruel world!");
		}

		//this rocket is very special... it can ignore gravity...
		this.rigidbody.useGravity = false;
		//create trigger for initial straight movement
		Vector3 warmupPosition = parent.transform.position + (parent.transform.forward.normalized * this.warmupDistance);
		warmupTarget = Instantiate (warmup, warmupPosition, parent.transform.rotation) as GameObject;
		warmupFinished = false;
		//it should be already facing it but it's better to be on the safe side
		//this.transform.LookAt (warmupTarget.transform.position);
		//this.transform.position = parent.transform.position + parent.transform.forward.normalized * 30f;
		//Debug.Log (transform.position);
		//Debug.Log (parent.transform.position);
                this.sound = Resources.Load("missile_impact") as AudioClip;
	}

	void Destroy() {
		DestroyObject (warmupTarget);
		DestroyObject (gameObject);
	}

	void TurnTo(GameObject target) {
		var direction = (target.transform.position - transform.position).normalized;
		var lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.Equals (warmupTarget))
			warmupFinished = true;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.Equals (target)) {
						Debug.Log ("Hit!");

                        audio.PlayOneShot(sound);
			var targetPosition = other.transform.position;
			var rocketPosition = this.transform.position;
			var hitPositionOnTarget = other.transform.InverseTransformPoint(other.contacts[0].point);
			if (hitPositionOnTarget.x > 0) {
				other.rigidbody.AddForceAtPosition(target.transform.right*100,hitPositionOnTarget);
			} else {
				other.rigidbody.AddForceAtPosition(target.transform.right*-100,hitPositionOnTarget);
			}
	
			Debug.Log(hitPositionOnTarget);

			//other.gameObject.rigidbody.AddForceAtPosition(other.transform.right * 500, this.transform.position);
		} else {
			Debug.Log("missed: " + other);
		}
		Destroy ();
	}

	void Warmup()
	{
		TurnTo (warmupTarget);
		rigidbody.AddForce (transform.forward * warmupForce);
	}

	void SeekTarget(){
		TurnTo (target);

		var targetDirection = (target.transform.position - transform.position).normalized;
		var angle = Vector3.Angle (targetDirection, this.transform.forward);
		var strength = (180.0f - angle) / 180.0f;
		rigidbody.AddForce (transform.forward * Mathf.Max(movementForce*strength, warmupForce));
		if (Vector3.Distance (this.transform.position, target.transform.position) < 150)
						rotationSpeed += 0.3f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (warmupFinished) {
			SeekTarget ();
		} else {
			Warmup ();
		}
	}
}
