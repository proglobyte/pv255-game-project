using UnityEngine;
using System.Collections;

public class SimpleHovercraft : MonoBehaviour {

  Transform fan;
  private Player player;
  private float nextReset = 0.0f;
  private float resetFrequency = 0.5f;
  public float speed;
  private const float speedConstant = 8;

  private Vector3 lastPosition;

  void Start () {
      fan = transform.Find("Fan");
      lastPosition = this.transform.position;
      player = GetComponent<Player>();
    }

  void FixedUpdate () {
      //float r = Input.GetAxis("Horizontal"+player.id) * -10;
      //fan.localRotation = Quaternion.Euler(0,r,0);
      float force = Input.GetAxis("Vertical"+player.id) * player.power;
      rigidbody.AddForceAtPosition( fan.forward * force, fan.position );
      float torqueForce = Input.GetAxis ("Horizontal" + player.id) * player.power * 4;
      Debug.Log (torqueForce);
      rigidbody.AddTorque (this.transform.up * torqueForce);
      this.speed = Vector3.Distance (lastPosition, this.transform.position) * speedConstant;
      lastPosition = this.transform.position;

      float volumeFromSpeed = speed;
      if(volumeFromSpeed >= 20){
        volumeFromSpeed = 20;
      }

      audio.volume = (volumeFromSpeed / 0.2f) / 100f;
  }

  void Update() {
      if (Input.GetButton ("Reset"+player.id) && Time.time > nextReset ) {
            nextReset = Time.time + resetFrequency;
            var pos = this.transform.position;
            pos.y += 50;
            this.transform.position = pos;
            var rot = this.transform.rotation;
            rot.x = 0;
            rot.z = 0;
            this.transform.rotation = rot;
          }
    }
}
