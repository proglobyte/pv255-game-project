using UnityEngine;
using System.Collections;

public class RocketLaunching : MonoBehaviour {

  public GameObject target;
  public GameObject rocket;
  private float rocketFrequency = 0.5f;
  private Player player;
  public AudioClip sound;
  //public GameObject warmup;
  // Use this for initialization
  void Start () {
    player = GetComponent("Player") as Player;
  }

  void Fire() {
    if(player.canMissile){
      var rocketInstance = Instantiate (rocket, transform.position + transform.forward.normalized * 60f, transform.rotation) as GameObject;
      rocketInstance.GetComponent<BasicRocket> ().parent = this.gameObject;
      rocketInstance.GetComponent<BasicRocket> ().target = target;
      rocketInstance.AddComponent("AudioSource");

      player.shotMissile();
      audio.PlayOneShot(sound);
    }
  }
  // Update is called once per frame
  void Update () {
    if (Input.GetButton ("Fire" + player.id)) {
      Fire();
    }
  }
}
