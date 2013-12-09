using UnityEngine;
using System.Collections;

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
		numberOfPlayers = GUI.TextField ( new Rect(350, 200, 20, 20), numberOfPlayers, 2);
		try {
			_numberOfPlayers = int.Parse(numberOfPlayers);
		} catch (System.Exception ex) {
			Debug.Log (ex);
		}

		_numberOfPlayers = int.Parse(numberOfPlayers);
		PlayerPrefs.SetInt("NumbersOfPlayers", _numberOfPlayers);

	}
}
