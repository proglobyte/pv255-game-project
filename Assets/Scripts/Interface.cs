using UnityEngine;
using System.Collections;

public class Interface : MonoBehaviour {

  private Texture2D emp;
  private Texture2D laser;
  private Texture2D missile;
  public bool top;
  public GameObject hovercraft;

  private int iconSize;

  private Texture2D energyRect;
  private GUIStyle energyStyle;

  private GUIStyle speedStyle;
  private GUIStyle speedStyle2;
  private Player player;

  void Start()
  {
    player = hovercraft.GetComponent<Player>();
    emp = (Texture2D)Resources.Load("GUI/emp");
    laser = (Texture2D)Resources.Load("GUI/laser");
    missile = (Texture2D)Resources.Load("GUI/missile");

    energyRect = new Texture2D (1, 1);
    energyRect.SetPixel(0,0, Color.white);
    energyRect.Apply();

    energyStyle = new GUIStyle();
    energyStyle.normal.background = energyRect;

    int size = Mathf.Min (Screen.height, Screen.width);
		iconSize = size / 13;
  }

  void OnGUI()
  {
    speedStyle = GUI.skin.GetStyle ("Label");
    speedStyle.alignment = TextAnchor.LowerRight;
    speedStyle.fontSize = iconSize;

    speedStyle2 = GUI.skin.GetStyle ("Box");
    speedStyle2.alignment = TextAnchor.UpperRight;
    speedStyle2.fontSize = iconSize;

    Color iconColor = Color.white;
    int offset = 0;
    if (top) {
      offset = -Screen.height / 2;
    }
    if (!player.canLaser) {
      iconColor.a = 0.3f;
      GUI.color = iconColor;
    }
    GUI.DrawTexture (new Rect (Screen.width - iconSize * 2, Screen.height - iconSize * 1.5f + offset, iconSize, iconSize), laser);
    iconColor.a = 1;
    GUI.color = iconColor;

    if (!player.canMissile) {
      iconColor.a = 0.3f;
      GUI.color = iconColor;
    }

    GUI.DrawTexture (new Rect (Screen.width - iconSize * 3.2f, Screen.height - iconSize * 1.5f + offset, iconSize, iconSize), missile);
    iconColor.a = 1;
    GUI.color = iconColor;

    if (!player.canEmp) {
      iconColor.a = 0.3f;
      GUI.color = iconColor;
    }
    GUI.DrawTexture (new Rect (Screen.width - iconSize * 4.4f, Screen.height - iconSize * 1.5f + offset, iconSize, iconSize), emp);
		/////	DELETE
		if(player.energy>0)
			player.win = 1;

    for (int i = 0; i < player.maxEnergy; i++) {
      iconColor.a = 1;
      GUI.color = iconColor;
      //dodělal jsem zde pro playera
      if(player.energy <= i){
        iconColor.a = 0.3f;
        GUI.color = iconColor;
      }
      //
      GUI.Box (new Rect (Screen.width - iconSize * 1.4f -  (iconSize * 0.5f * i), Screen.height - iconSize * 2.2f + offset, iconSize*0.4f, iconSize*0.2f), GUIContent.none, energyStyle);
    }
    iconColor.a = 1;
    GUI.color = iconColor;
    //GUI.Box(new Rect(Screen.width - iconSize * 4, Screen.height - iconSize * 6.4f + offset, iconSize *3, iconSize *3), "SPEED");
    GUI.Label(new Rect(Screen.width - iconSize * 4, Screen.height - iconSize * 6.4f + offset, iconSize *3, iconSize *4), 
        Mathf.RoundToInt(hovercraft.GetComponent<SimpleHovercraft>().speed).ToString(), speedStyle);

    if (player.win == 1) {
      GUI.Box(new Rect(Screen.width - iconSize * 4, Screen.height - iconSize * 6.4f + offset, iconSize *3, iconSize *4), 
          "won", speedStyle2);
	  GameObject.Find("EndMenu").GetComponent<End>().show(player.id);
    }else{
      GUI.Box(new Rect(Screen.width - iconSize * 4, Screen.height - iconSize * 6.4f + offset, iconSize *3, iconSize *4), 
          player.lap.ToString()+"/3", speedStyle2);
    }
  }
}
