#pragma strict

private var timeLeft : float;
private var disabled : boolean;
private var power : float;
private var script : SimpleHovercraft;
private var player : Player;

var timeout : float = 5;

function Start(){
  player = GetComponent(Player);
}

function initialize(){
  timeLeft = timeout;
  disabled = true;
}

function OnTriggerEnter (col : Collider)
{
  if(col.gameObject.tag != player.id && col.gameObject.name == "em_sphere" && !disabled){
    initialize();
    script = GetComponent(SimpleHovercraft);
    power = script.power;
    script.power = 0;
  }
}

function Update () {
  if(disabled){
    if(timeLeft > 0){
      timeLeft -= Time.deltaTime;
    }
    else{
      script.power = power;
      script = null;
      power = 0;
      disabled = false;
    }
  }
}
