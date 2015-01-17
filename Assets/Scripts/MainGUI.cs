using UnityEngine;
using System.Collections;

public class MainGUI : MonoBehaviour {
	private Texture buttonTexture;
	private int state = 0;
	private int player1 = 0;
	private int player2 = 1;
	private const int hovercraftNumber = 2;
	// Use this for initialization
	void OnGUI () {
		GUI.backgroundColor = Color.clear;
		GUIStyle style = new GUIStyle (GUI.skin.button);
		if (state == 0) 
		{
			style.fontSize = Screen.width / 20;
			style.normal.textColor = new Color (0.9f, 0.9f, 0.9f); 

			style.hover.textColor = new Color (0.9f, 1.0f, 0.2f);
			//GUI.color = new Color (0, 0.39f, 0.49f); 
			var dim = style.CalcSize (new GUIContent ("Hovercraft Mania"));
			float y = Screen.height / 7;
			GUI.Label (new Rect (Screen.width / 8, y, dim.x, dim.y), "Hovercraft Mania", style);
			y += dim.y + Screen.width / 50;

			style.normal.textColor = new Color (0.6f, 0.8f, 0.0f); 
			style.fontSize = Screen.width / 30;
			dim = style.CalcSize (new GUIContent ("New Game"));
			if (GUI.Button (new Rect (Screen.width / 8, y, dim.x, dim.y), "New Game", style)) 
			{
				Application.LoadLevel("game");
				//state = 1;
			}
			y += dim.y + Screen.width / 80;
			dim = style.CalcSize (new GUIContent ("Exit"));
			if (GUI.Button (new Rect (Screen.width / 8, y, dim.x, dim.y), "Exit", style)) 
			{
				Application.Quit();	
			}
		}
		if (state == 1) 
		{
			style.fontSize = Screen.width / 30;
			style.normal.textColor = new Color (0.9f, 0.9f, 0.9f); 
			style.hover.textColor = new Color (0.9f, 1.0f, 0.2f);

			var dim = style.CalcSize (new GUIContent ("Player 1"));
			float y = Screen.height / 10;
			GUI.Label (new Rect (Screen.width / 8, y, dim.x, dim.y), "Player 1", style);
			dim = style.CalcSize (new GUIContent ("Player 2"));
			GUI.Label (new Rect (Screen.width / 2, y, dim.x, dim.y), "Player 2", style);

			y = 7*Screen.height / 10;

			style.normal.textColor = new Color (0.6f, 0.8f, 0.0f); 
			style.fontSize = Screen.width / 30;

			float x = Screen.width / 8;
			dim = style.CalcSize (new GUIContent ("< "));
			if (GUI.Button (new Rect (x, y, dim.x, dim.y), "< ", style)) 
			{
				player1--;
				if (player1 < 0) //stupid % implementation
					player1 = hovercraftNumber-1;
				player1 %= 2;
			}
			x+=dim.x;

			if(player1 == 0)
			{
				dim = style.CalcSize (new GUIContent ("Dolphin "));
				GUI.Label (new Rect (x, y, dim.x, dim.y), "Dolphin ", style);
				x+=dim.x;
			}
			if (player1 == 1)
			{
				dim = style.CalcSize (new GUIContent ("Hammerhead "));
				GUI.Label (new Rect (x, y, dim.x, dim.y), "Hammerhead ", style);
				x+=dim.x;
			}
			dim = style.CalcSize (new GUIContent (">"));
			if (GUI.Button (new Rect (x, y, dim.x, dim.y), ">", style)) 
			{
				player1++;
				player1 %= 2;
			}

			x = Screen.width / 2;
			dim = style.CalcSize (new GUIContent ("< "));
			if (GUI.Button (new Rect (x, y, dim.x, dim.y), "< ", style)) 
			{
				player2--;
				if (player2 < 0) //stupid % implementation
					player2 = hovercraftNumber-1;
				player2 %= 2;
			}
			x+=dim.x;
			
			if(player2 == 0)
			{
				dim = style.CalcSize (new GUIContent ("Dolphin "));
				GUI.Label (new Rect (x, y, dim.x, dim.y), "Dolphin ", style);
				x+=dim.x;
			}
			if (player2 == 1)
			{
				dim = style.CalcSize (new GUIContent ("Hammerhead "));
				GUI.Label (new Rect (x, y, dim.x, dim.y), "Hammerhead ", style);
				x+=dim.x;
			}
			dim = style.CalcSize (new GUIContent (">"));
			if (GUI.Button (new Rect (x, y, dim.x, dim.y), ">", style)) 
			{
				player2++;
				player2 %= 2;
			}

			y = 7*Screen.height / 8;
			dim = style.CalcSize (new GUIContent ("Back"));
			if (GUI.Button (new Rect (Screen.width / 8, y, dim.x, dim.y), "Back", style)) 
			{
				state = 0;
				//state = 0;
			}

			dim = style.CalcSize (new GUIContent ("Start"));
			if (GUI.Button (new Rect (Screen.width / 2, y, dim.x, dim.y), "Start", style)) 
			{
				Application.LoadLevel("game");
				//state = 0;
			}
		}

	}
}
