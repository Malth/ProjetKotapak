using UnityEngine;
using System.Collections;


public class MenuMouseBehaviourScript : MonoBehaviour 
{ 
	Texture2D curseur;
	Rect positionCurseur;


	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false; 
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	/*void OnGUI() 
	{
    	Vector3 positionSouris = Input.mousePosition;
    	positionCurseur = new Rect(positionSouris.x, Screen.height - positionSouris.y, curseur.width, curseur.height );
		GUI.Label(positionCurseur,curseur);
	}
	*/

	//@script RequireComponent(AudioSource)

	
}


