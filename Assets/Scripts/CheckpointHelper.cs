using UnityEngine;
using System.Collections;

public class CheckpointHelper : MonoBehaviour {
	public GameObject nextCheckpoint;
	public GameObject previousCheckpoint;
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals ("Hovercraft")) {
			Player player = other.transform.parent.gameObject.GetComponent ("Player") as Player;
			if (player.checkpointObject == previousCheckpoint)
				player.checkpointObject = nextCheckpoint;
			else 
				player.temporaryCheckpointObject = nextCheckpoint;
		}
		
	}
}
