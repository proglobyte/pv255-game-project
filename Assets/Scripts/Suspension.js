var suspensionRange = 2.50;

function OnDrawGizmos () {
	Gizmos.color = Color.yellow;
    Gizmos.DrawRay (transform.position, levelParent.transform.TransformDirection (Vector3.up) * -suspensionRange);
}