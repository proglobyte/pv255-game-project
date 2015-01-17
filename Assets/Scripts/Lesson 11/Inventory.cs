using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Inventory : MonoBehaviour {
	public List<string> items;

	public string GetItem(string comparedItem)
	{
		foreach(string item in items)
			if(item == comparedItem)
				return item;
		return null;
	}
}
