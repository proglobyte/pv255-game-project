using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	public int checkpointNumb;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Hovercraft")) {
			Player player = other.transform.parent.gameObject.GetComponent ("Player") as Player;
			if(player.checkpoint==checkpointNumb){
				print("wrong way");
			}
			else{player.checkpoint=checkpointNumb;}
		}
		
	}
}
