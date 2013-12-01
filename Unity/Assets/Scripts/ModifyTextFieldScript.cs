using UnityEngine;
using System.Collections;
using System;

public class ModifyTextFieldScript : MonoBehaviour {
	
	string numberOfPlayers = "2";
	int _numberOfPlayers = 2;
	KotapakNetworkScript kotapakNetworkScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		// Make a text field that modifies stringToEdit.
		_numberOfPlayers = Convert.ToInt32(GUI.TextField ( new Rect(420, 170, 20, 20), numberOfPlayers, 1));
		//_numberOfPlayers = Convert.ToInt32(numberOfPlayers);
		PlayerPrefs.SetInt("NumbersOfPlayers", _numberOfPlayers);
	}
}
