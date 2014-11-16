using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
  public int energy;
  private int resetTimer;
  public int resetTime;
  private bool reset = false;
  // Use this for initialization
  void Start () {

  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag.Equals ("Hovercraft")) {
      Player player = other.transform.parent.gameObject.GetComponent("Player") as Player;
      player.addEnergy(energy);
    }
    (this.GetComponent("Renderer") as ParticleRenderer).enabled = false;
    (this.GetComponent("Light") as Light).enabled = false;
    (this.GetComponent("Collider") as Collider).enabled = false;
    resetTimer = 0;
    reset = true;
  }

  // Update is called once per frame
  void FixedUpdate () {
    if (reset) {
      if (++resetTimer > resetTime) {
        reset = false;
        (this.GetComponent("Renderer") as ParticleRenderer).enabled = true;
        (this.GetComponent("Light") as Light).enabled = true;
        (this.GetComponent("Collider") as Collider).enabled = true;
      }
    }
  }
}
