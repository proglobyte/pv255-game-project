using UnityEngine;
using System.Collections;

public class WrongWay : MonoBehaviour {
	private bool show1 = false;
	private bool show2 = false;
	private float t1;
	private float t2;
	private float timeout = 2;


	public void show(Player player)
	{
		if (player.id == "One")
		{
			t1 = Time.time + timeout;
			show1 = true;
		}
		if (player.id == "Two") 
		{
			t2 = Time.time + timeout;
			show2 = true;
		}
	}

	void OnGUI()
	{

		if (show1) 
		{
			if (t1 < Time.time)
				show1 = false;
		}
		if (show2) 
		{
			if (t2 < Time.time)
				show2 = false;
		}

		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.alignment = TextAnchor.UpperCenter;
		style.fontSize = Screen.width / 30;
		style.normal.textColor = new Color (0.9f, 0.9f, 0.9f); 

		if (show1) {
			var dim = style.CalcSize (new GUIContent ("Wrong way!"));
			GUI.Label (new Rect (Screen.width / 8, Screen.height / 8, dim.x, dim.y), "Wrong way!", style);
		}

		if (show2) {
				var dim = style.CalcSize (new GUIContent ("Wrong way!"));
				GUI.Label (new Rect (Screen.width / 8, 5*Screen.height / 8, dim.x, dim.y), "Wrong way!", style);
		}
	}
}
