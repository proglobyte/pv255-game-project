var suspensionRange = 2.50;
var suspensionForce = 500;
var suspensionDamp = 17.00;

private var hit : RaycastHit;
private var parent : Rigidbody;
private var diff = 1.0f;
parent = transform.root.rigidbody;

var levelParent : GameObject;


function FixedUpdate () {


	down = transform.TransformDirection(Vector3.down); 
	worldDown = levelParent.transform.TransformDirection(Vector3.down); 
	if(Physics.Raycast (transform.position, worldDown, hit, suspensionRange) && hit.collider.transform.root != transform.root)
	{
		velocityAtTouch = parent.GetPointVelocity(hit.point);
		
		compression = hit.distance / (suspensionRange);
		compression = -compression + 1;
		counterForce = -worldDown * compression * suspensionForce;
		if (hit.distance > (3.0 * suspensionRange / 4.0)) {
			diff -= 0.01f;	
		}
		else {
			if (diff<1)
				diff += 0.01f;
		}
		
		counterForce *= diff;
		
		t = transform.InverseTransformDirection(velocityAtTouch);
		t.z = t.x = 0;
		shockDrag = levelParent.transform.TransformDirection(t) * -suspensionDamp;
		
		parent.AddForceAtPosition(counterForce + shockDrag, hit.point);

	}
}


// Show yellow Rays (debug only)
/*
function OnDrawGizmos () {
	Gizmos.color = Color.yellow;
    Gizmos.DrawRay (transform.position, levelParent.transform.TransformDirection (Vector3.up) * -suspensionRange);
}
*/