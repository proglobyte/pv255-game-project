using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
	//private const int hovercraftNumber = 2;
	// Use this for initialization
	private bool showed = false;
	private string player;

	public void show(string player)
	{
		this.player = player;
		Time.timeScale = 0.0f;
		showed = true;
	}

	void Awake()
	{
		Time.timeScale = 1.0f;
	}

	void OnGUI () {
		if (!showed)
			return;

		GUIStyle style;
		style = new GUIStyle(GUI.skin.button);
		style.fontSize = Screen.width / 15;
		style.normal.textColor = new Color (0.9f, 0.9f, 0.9f); 
		style.hover.textColor = new Color (0.9f, 1.0f, 0.2f);
		
		GUI.Box(new Rect(Screen.width / 8, Screen.width / 8, 6 * Screen.width / 8, Screen.height - 2 * Screen.width / 8), GUIContent.none);
		GUI.backgroundColor = Color.clear;
		float y = Screen.width / 7;
		var dim = style.CalcSize (new GUIContent (player + " won!"));
		GUI.Label(new Rect(Screen.width / 7, y, dim.x, dim.y), player + " won!", style);
		
		style.fontSize = Screen.width / 30;
		y+= dim.y + Screen.width / 60;	
		style.normal.textColor = new Color (0.6f, 0.8f, 0.0f);
		
		dim = style.CalcSize (new GUIContent ("Again"));
		if(GUI.Button(new Rect(Screen.width / 7, y, dim.x, dim.y), "Again", style)){
			Time.timeScale = 1.0f;
			Application.LoadLevel(Application.loadedLevel); 
		}
		y+= dim.y + Screen.width / 80;
		
		dim = style.CalcSize (new GUIContent ("Main menu"));
		if(GUI.Button(new Rect(Screen.width / 7, y, dim.x, dim.y), "Main menu", style)){
			//changeState();
			Application.LoadLevel("mainMenu");
		}
		
	}
}
