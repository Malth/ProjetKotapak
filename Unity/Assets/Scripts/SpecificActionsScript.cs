using UnityEngine;
using System.Collections;

public class SpecificActionsScript : MonoBehaviour 
{
	AudioClip son =  null;
	

void OnMouseUp() { 
	audio.PlayOneShot(son);
	Debug.Log ("Texte cliqué : " +this.name);
	if (this.name == "Quitter")
	 	Application.Quit();
	else
	 	Application.LoadLevel(this.name);
}



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}

