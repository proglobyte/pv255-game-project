using UnityEngine;
using System.Collections;

public class RocketLaunching : MonoBehaviour {

  public GameObject target;
  public GameObject rocket;
  private float nextRocket = 0.0f;
  private float rocketFrequency = 0.5f;
  private Player player;
  //public GameObject warmup;
  // Use this for initialization
  void Start () {
    player = GetComponent("Player") as Player;
  }

  void Fire() {
    if(player.canMissile){
      nextRocket = Time.time + rocketFrequency;
      var rocketInstance = Instantiate (rocket, transform.position + transform.forward.normalized * 60f, transform.rotation) as GameObject;
      rocketInstance.GetComponent<BasicRocket> ().parent = this.gameObject;
      rocketInstance.GetComponent<BasicRocket> ().target = target;

      // colum for PLayer.js
      player.shotMissile();
      //colum for player.js
    }
  }
  // Update is called once per frame
  void Update () {
    if (Input.GetButton ("Fire" + player.id)) {
      Fire();
    }
  }
}
