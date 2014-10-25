#pragma strict

private var timeLeft : float;
private var disabled : boolean;
private var power : float;
private var script : SimpleHovercraft;

var player : String;
var timeout : float = 5;

function initialize(){
	timeLeft = timeout;
	disabled = true;
}

function OnTriggerEnter (col : Collider)
{
  print(this.name + ": HIT! (collider)");
  print("Collider object name: " + col.gameObject.tag);
  
  if(col.gameObject.tag != player && !disabled){
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
