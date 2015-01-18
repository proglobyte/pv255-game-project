using UnityEngine;
using System.Collections;

public class CheckpointEnhanced : MonoBehaviour {
	public bool final = false;
	public bool triggered = false;
	void OnTriggerEnter(Collider other)
	{
		if (triggered)
			return;
		if (other.gameObject.tag.Equals ("Hovercraft")) {
			Player player = other.transform.parent.gameObject.GetComponent ("Player") as Player;
			if(player.checkpointObject == (this.gameObject) || player.temporaryCheckpointObject == (this.gameObject)){
				Debug.Log ("OK");
				if (player.checkpointObject == (this.gameObject)  && final)
				{
					player.addLap(1);
					if (player.lap == 4)
						player.win = 1;
				}
			}
			else
			{
				GameObject.Find("Wrong").GetComponent<WrongWay>().show(player);
				Debug.Log(player.checkpointObject.name + "   ::   " + this.gameObject.name);
			}
			triggered = true;
		}

	}
	void OnTriggerExit(Collider other)
	{
		triggered = false;
	}
}
