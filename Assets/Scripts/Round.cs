using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Hovercraft")) {
						player = other.transform.parent.gameObject.GetComponent ("Player") as Player;
						if (player.checkpoint*player.lap == player.lap) {
								player.addLap(1);
				                player.checkpoint=0;
						}
			            if (player.lap == 4) {
				          player.win=1;
			              }
				}

	}





}
