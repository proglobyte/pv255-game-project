#pragma strict

private var destroyTimeLeft : float;
private var fadeTimeLeft : float;
private var destroyCountdown = false;
private var fadeCountdown = false;
private var scaleFactor : float;
private var fadeFactor : float;
private var sphere : GameObject;
private var player : Player;

var speed : float = 20;
var radius : float = 75;

function Start () {
  player = GetComponent(Player);
}

function initialize(){
  destroyTimeLeft = 1000;
  fadeTimeLeft = 300;
}

function Update () {
  if (sphere){
    sphere.transform.position = this.transform.position;
  }

  if (destroyCountdown){
    sphere.transform.position = this.transform.position;
    destroyTimeLeft -= (speed - Time.deltaTime);
    if (destroyTimeLeft > 0){
      sphere.transform.localScale += Vector3(scaleFactor, scaleFactor, scaleFactor);
      if (destroyTimeLeft < fadeTimeLeft){
        fadeCountdown = true;
      }
    }else{
      Destroy(sphere);
      destroyCountdown = false;
    }
  }

  if (fadeCountdown){
    fadeTimeLeft -= (speed - Time.deltaTime);
    if (fadeTimeLeft > 0){
      sphere.renderer.material.color.a -= fadeFactor;
    }
    else{
      fadeCountdown = false;
    }
  }

  if (Input.GetButton("Player" + player.id + "_Weapon3")){
    if (transform.Find("em_sphere") == null && player.canEmp){
      print ("player " + player.id + " is using electromagnetic pulse");
      initialize();
      sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
      sphere.transform.parent = this.transform;
      sphere.name = "em_sphere";
      sphere.tag = player.id;
      var collider : SphereCollider;
      collider = sphere.GetComponent("SphereCollider");
      collider.isTrigger = true;
      var rigidbody : Rigidbody;
      rigidbody = sphere.AddComponent("Rigidbody");
      rigidbody.useGravity = false;
      sphere.transform.position = this.transform.position;
      sphere.renderer.material = Resources.Load("m_Lighting", Material);
      scaleFactor = radius/(destroyTimeLeft/speed);
      fadeFactor = sphere.renderer.material.color.a/(fadeTimeLeft/speed);
      destroyCountdown = true;
      player.shotEmp();
    }
  }
}
