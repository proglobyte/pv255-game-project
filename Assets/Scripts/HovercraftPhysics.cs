using UnityEngine;
using System.Collections;

public class HovercraftPhysics : MonoBehaviour {
	private GameObject hovercraft;
	private GameObject body;
	private float stability;
	private bool physicsSetup;
	private float hoverHeight;
	private float jumpingPower;
	private float landingPower;
	private float steeringPower;
	public Transform[] corners;
	private float increment;
	private float distance;
	private Quaternion rotation;
	private float forwardPower;
	private float steerPower;
	private float stabilizingPower;
	public float speedUpdate;
	private Vector3 lastPosition;

	
	private void FixedUpdate() {
		if (!physicsSetup)
			return;
		RaycastHit hit = new RaycastHit();
		var hitNormals = new Vector3[4];

		for (int i = 0; i<corners.Length; i++) {
			if (Physics.Raycast(corners[i].position, -corners[i].transform.up, out hit)) {
				if (hit.distance < hoverHeight) {
					rigidbody.AddForceAtPosition(hit.normal * jumpingPower * Time.deltaTime * Mathf.Min(hoverHeight, hoverHeight/hit.distance), corners[i].position);
				} else {
					rigidbody.AddForceAtPosition(-hit.normal * landingPower * Time.deltaTime / Mathf.Min(hoverHeight, hoverHeight/hit.distance), corners[i].position);
				} 
//			} else if (Physics.Raycast(corners[i].position, Vector3.down, out hit)) {
//				rigidbody.AddForceAtPosition(Vector3.down * landingPower, corners[i].position);
//			} else {
//				rigidbody.AddForceAtPosition(Vector3.up * jumpingPower, corners[i].position);
//			}
			}
			else {
				if (Physics.Raycast(corners[i].position, Vector3.down, out hit)) {
					rigidbody.AddForceAtPosition(Vector3.down * landingPower, corners[i].position);
				} else {
					rigidbody.AddForceAtPosition(Vector3.up * jumpingPower*3, corners[i].position);
				}
			}
		}
		/*if (increment < 1)
			increment += 0.03f;
		rotation = Quaternion.Slerp (body.transform.localRotation, Quaternion.Euler (average * Mathf.Rad2Deg), increment);
		//body.transform.localRotation = rotation;
		Quaternion hack = rotation;
		hack.y = transform.up.y * Mathf.Deg2Rad;
		body.transform.localRotation = hack;
		*/
		float fwdForce = Input.GetAxis ("Vertical") * forwardPower;
		rigidbody.AddForce (transform.forward * fwdForce);
		
//		float steerForce = Input.GetAxis ("Horizontal") * steerPower;
//		rigidbody.AddTorque (transform.up * steerForce);



		//if ((Mathf.Abs (hovercraft.transform.localEulerAngles.z) < 25) || (Mathf.Abs (hovercraft.transform.localEulerAngles.z) -360 > -25))  {
			if (Input.GetAxis("Horizontal") < 0) {
				//left
				rigidbody.AddForceAtPosition(-corners[0].transform.right * steerPower, corners[0].position);
				rigidbody.AddForceAtPosition(corners[1].transform.right * steerPower, corners[1].position);
				rigidbody.AddForceAtPosition(-corners[2].transform.right * steerPower, corners[2].position);
				rigidbody.AddForceAtPosition(corners[3].transform.right * steerPower, corners[3].position);

//				if (Mathf.Abs (hovercraft.transform.localEulerAngles.z) < 45) {
//					rigidbody.AddForceAtPosition(-corners[0].transform.up * steeringPower * Time.deltaTime, corners[0].position);
//					rigidbody.AddForceAtPosition(-corners[0].transform.up * steeringPower * Time.deltaTime, corners[1].position);
//					rigidbody.AddForceAtPosition(corners[0].transform.up * steeringPower * Time.deltaTime, corners[2].position);
//					rigidbody.AddForceAtPosition(corners[0].transform.up * steeringPower * Time.deltaTime, corners[3].position);
//				}
			} 
			if (Input.GetAxis("Horizontal") > 0) {
				//right

				rigidbody.AddForceAtPosition(corners[0].transform.right * steerPower, corners[0].position);
				rigidbody.AddForceAtPosition(-corners[1].transform.right * steerPower, corners[1].position);
				rigidbody.AddForceAtPosition(corners[2].transform.right * steerPower, corners[2].position);
				rigidbody.AddForceAtPosition(-corners[3].transform.right * steerPower, corners[3].position);

//				if (Mathf.Abs (hovercraft.transform.localEulerAngles.z) < 45) {
//					rigidbody.AddForceAtPosition(corners[0].transform.up * steeringPower * Time.deltaTime, corners[0].position);
//					rigidbody.AddForceAtPosition(corners[1].transform.up * steeringPower * Time.deltaTime, corners[1].position);
//					rigidbody.AddForceAtPosition(-corners[2].transform.up * steeringPower * Time.deltaTime, corners[2].position);
//					rigidbody.AddForceAtPosition(-corners[3].transform.up * steeringPower * Time.deltaTime, corners[3].position);
//				}
			}
		//}

		if ((hovercraft.transform.localEulerAngles.z > 180) && (hovercraft.transform.localEulerAngles.z < 275)){
			Debug.Log("under -90");
			rigidbody.AddForceAtPosition(-corners[0].transform.up * stabilizingPower * Time.deltaTime, corners[0].position);
			rigidbody.AddForceAtPosition(-corners[1].transform.up * stabilizingPower * Time.deltaTime, corners[1].position);
			rigidbody.AddForceAtPosition(corners[2].transform.up * stabilizingPower * Time.deltaTime, corners[2].position);
			rigidbody.AddForceAtPosition(corners[3].transform.up * stabilizingPower * Time.deltaTime, corners[3].position);
		}
		if ((hovercraft.transform.localEulerAngles.z > 75) && (hovercraft.transform.localEulerAngles.z < 180)) {
			rigidbody.AddForceAtPosition(corners[0].transform.up * stabilizingPower * Time.deltaTime, corners[0].position);
			rigidbody.AddForceAtPosition(corners[1].transform.up * stabilizingPower * Time.deltaTime, corners[1].position);
			rigidbody.AddForceAtPosition(-corners[2].transform.up * stabilizingPower * Time.deltaTime, corners[2].position);
			rigidbody.AddForceAtPosition(-corners[3].transform.up * stabilizingPower * Time.deltaTime, corners[3].position);
		}
	}
	
	private void OnDrawGizmos() {
		for (int i=0; i<corners.Length; i++) {
			if (corners[i]!=null) {
				Gizmos.DrawWireSphere(corners[i].position, 1);
			}
		}
	}
	
	private void CalculateSpeed() {
		/*if (lastPosition != transform.position) {
			float distance = Vector3.Distance(transform.position, lastPosition);
			speedUpdate = (distance / 1000)/(Time.deltaTime/3600);
			lastPosition = transform.position;
		}*/
	}
	
	private void InitilizePhysics () {
		hovercraft = GameObject.Find ("Hovercraft");
		body = GameObject.Find("Hovercraft/Body");
		stability = 1.35f;
		physicsSetup = false;
		hoverHeight = 35;
		jumpingPower = 10000;
		landingPower = 5000;
		steeringPower = 20000;
		stabilizingPower = 60000;

		corners = new Transform[4];

		increment = 0;
		distance = 0;
		rotation = new Quaternion ();
		forwardPower = 7500;
		steerPower = 100;
		lastPosition = transform.position;
		Vector3[] cornerPoints;
		cornerPoints = new Vector3[4];

		BoxCollider boxCollider = body.GetComponent ("BoxCollider") as BoxCollider; 
		Vector3 boxDim = new Vector3 (boxCollider.size.x, 
		                              boxCollider.size.y, 
		                              boxCollider.size.z) * stability;
		cornerPoints [0] = new Vector3 (transform.position.x - boxDim.x / 2, transform.position.y - boxDim.y / 2, transform.position.z + boxDim.z / 2);
		cornerPoints [1] = new Vector3 (transform.position.x - boxDim.x / 2, transform.position.y - boxDim.y / 2, transform.position.z - boxDim.z / 2);
		cornerPoints [2] = new Vector3 (transform.position.x + boxDim.x / 2, transform.position.y - boxDim.y / 2, transform.position.z + boxDim.z / 2);
		cornerPoints [3] = new Vector3 (transform.position.x + boxDim.x / 2, transform.position.y - boxDim.y / 2, transform.position.z - boxDim.z / 2);

		//Destroy (boxCollider);
		
		int index = 0;
		foreach (Vector3 corner in cornerPoints) {
			var stablePlatform = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			stablePlatform.name = "stablePlatform[" + index + "]";
			stablePlatform.transform.parent = body.transform;
			stablePlatform.transform.localPosition = transform.InverseTransformPoint(corner);
			
			corners[index] = stablePlatform.transform;
			Destroy(stablePlatform.GetComponent("MeshRenderer"));
			Destroy(stablePlatform.GetComponent("Collider"));
			index++;
		}
		cornerPoints = null;
		physicsSetup = true;
		
	}
	
	// Use this for initialization
	void Start () {
		InitilizePhysics ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
