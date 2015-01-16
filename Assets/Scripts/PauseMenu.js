#pragma strict

private var showed : boolean = false;
private var lastPressed : int = 0;

function Update () {
  if (Input.GetButton("Esc") && lastPressed < Time.frameCount){
    lastPressed = Time.frameCount + 10;
    changeState();
  }
}

function changeState(){
  if(showed){
    Time.timeScale = 1.0;
    showed = false;
  }else{
    Time.timeScale = 0.0;
    showed = true;
  }
}

function OnGUI(){
  if(!showed){
    return;
  }

  GUI.Box(new Rect(200, 100, 600, 500), GUIContent.none);
  GUI.Label(new Rect(250, 150, 200, 60), "Pause");

  if(GUI.Button(new Rect(250, 220, 100, 50), "Resume")){
    changeState(); 
  }
  if(GUI.Button(new Rect(250, 280, 100, 50), "Quit")){
    changeState();
    Application.LoadLevel("menu");
  }
} 
