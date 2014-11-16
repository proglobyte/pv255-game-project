using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
  LineRenderer line;
  private Player player;
  public AudioClip sound;

  // Use this for initialization
  void Start () {
    line = gameObject.GetComponent<LineRenderer>();
    //r = gameObject.GetComponent<Rigidbody> ();
    line.enabled = false;
    player = this.GetComponent<Player>();
  }

  void Update (){
    if (Input.GetButton("Player" + player.id + "_Weapon2") && player.canLaser)
    {
      StopCoroutine("FireLaser");
      StartCoroutine("FireLaser");

    }
  }

  // Update is called once per frame
  IEnumerator FireLaser(){
    line.enabled = true;
    player.shotLaser();
    audio.PlayOneShot(sound);
    while (Input.GetButton("Player" + player.id + "_Weapon2")) {
      if(!player.canLaser){
        break;
      }
			print("LASSSSSSSSSSSSSSSSSSS");

      Vector3 fwd = transform.forward;

      //Vector3 a=r.position;
      //a.x+=50;
      RaycastHit hit;

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
  }
}
