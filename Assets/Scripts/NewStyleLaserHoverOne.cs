using UnityEngine;
using System.Collections;

public class NewStyleLaserHoverOne : MonoBehaviour {
	LineRenderer line;
	public GameObject bd;
	//Transform bd;
	
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		line.enabled = false;
	}
	
	void Update (){
		if (Input.GetKey(KeyCode.M))
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");
			
		}
	}
	
	
	// Update is called once per frame
	IEnumerator FireLaser(){
		line.enabled = true;
		while (Input.GetKey (KeyCode.M)) {
			
			
			
			Vector3 fwd = transform.right;
			RaycastHit hit;
			//bd= gameObject.Find("Cube21");
			Vector3 pos=transform.localPosition;
			
			pos.x+=500;
			Vector3 pos2=transform.localPosition;
			pos2.y-=2;
			line.SetPosition(0, pos2);
			line.SetPosition(1, pos );             
			Debug.DrawRay (transform.position, fwd, Color.red);
			if (Physics.Raycast (transform.position, fwd, out hit, 500)) {
				
				print (hit.transform.name);
				//hit.transform.Rotate(Time.deltaTime, 0, 0);
				if (hit.rigidbody != null){
					hit.rigidbody.AddForce(Vector3.up * 500);
				}
				
			}
			yield return null;
		}
		
		line.enabled = false;
		
		
	}
	
	
}
