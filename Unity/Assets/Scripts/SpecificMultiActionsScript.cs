using UnityEngine;
using System.Collections;

public class SpecificMultiActionsScript : MonoBehaviour  
{
	//AudioClip son =  null;
	bool inside;
	
/*void OnMouseUp() { 
	//audio.PlayOneShot(son);
	Debug.Log ("Texte cliqué : " +this.name);
	if (this.name == "Quitter")
	 	Application.Quit();
	else
	 	Application.LoadLevel(this.name);
}*/



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonUp(0) && inside == true)
		{
			Debug.Log ("Texte cliqué : " +this.name);
			if (this.name == "Quitter")
			 	Application.Quit();
			else
			{
				PlayerPrefs.SetString("LevelToLoad", this.name);
				Application.LoadLevel("connectionScreen");
			}
		}		
	}
	
	void OnMouseEnter()
	{
		inside = true;
	}
	
	void OnMouseExit()
	{
		inside = false;
	}
}


