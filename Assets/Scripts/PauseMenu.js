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
  
  var style : GUIStyle;
  style = new GUIStyle (GUI.skin.button);
  style.fontSize = Screen.width / 45;
  style.normal.textColor = new Color (0.9f, 0.9f, 0.9f); 
  style.hover.textColor = new Color (0.9f, 1.0f, 0.2f);
  
  GUI.Box(new Rect(Screen.width / 8, Screen.width / 8, 6 * Screen.width / 8, Screen.height - 2 * Screen.width / 8), GUIContent.none);
  GUI.backgroundColor = Color.clear;
  var y : float = Screen.width / 7;
  var dim : Vector2 = style.CalcSize (new GUIContent ("Pause"));
  GUI.Label(new Rect(Screen.width / 7, y, dim.x, dim.y), "Pause", style);
  
  style.fontSize = Screen.width / 30;
  y+= dim.y + Screen.width / 50;	
  style.normal.textColor = new Color (0.6f, 0.8f, 0.0f);
  	
  dim = style.CalcSize (new GUIContent ("Resume"));
  if(GUI.Button(new Rect(Screen.width / 7, y, dim.x, dim.y), "Resume", style)){
    changeState(); 
  }
  y+= dim.y + Screen.width / 50;
  
  dim = style.CalcSize (new GUIContent ("Quit"));
  if(GUI.Button(new Rect(Screen.width / 7, y, dim.x, dim.y), "Quit", style)){
    changeState();
    Application.LoadLevel("mainMenu");
  }
} 
