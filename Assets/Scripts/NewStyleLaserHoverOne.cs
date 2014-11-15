

using UnityEngine;
using System.Collections;

public class NewStyleLaserHoverOne : MonoBehaviour {
	LineRenderer line;
	public string player;
	public int energyCost;
	public GameObject bd;
	public bool avaible;
	private Player pl;

	//Transform bd;
	
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();
		//r = gameObject.GetComponent<Rigidbody> ();
		line.enabled = false;
		avaible = false;
		pl = this.GetComponent<Player>();
	}
	
	void Update (){
		if (pl.energy >= energyCost) {
						avaible = true;
				} else {
			avaible=false;
				}
		if (pl.energy > 10) {
						print ("vetsi"+player);
				} else {
			print("mensi"+player);
				}
		if (Input.GetButton("Player" + player + "_Weapon2") && avaible==true)
		{
			StopCoroutine("FireLaser");
			StartCoroutine("FireLaser");

		}
	}
	
	
	// Update is called once per frame
	IEnumerator FireLaser(){
		line.enabled = true;
		pl.energy -= energyCost;
		while (Input.GetButton("Player" + player + "_Weapon2")) {
			if(avaible==false ||pl.energy <= 0 ){break;}
			
			
			Vector3 fwd = transform.forward;
		
			//Vector3 a=r.position;
			//a.x+=50;
			RaycastHit hit;
			//bd= gameObject.Find("Cube21");

			Transform boxik= transform.FindChild("hover");
			if(boxik==null){print("hover neni");}
			Transform bxx=boxik.FindChild("Box001");
			if(bxx==null){print("box neni");}



			Vector3 ahoj=bxx.localPosition;
			ahoj.z+=500;

			line.SetPosition(0,bxx.localPosition);
			line.SetPosition(1,ahoj);             
			//Debug.DrawRay (pos, fwd, Color.red,100000);
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
		//(this.gameObject.GetComponent ("SimpleHovercraft") as SimpleHovercraft).energy -= energyCost;
		 avaible=false;
	}
	
	
}
