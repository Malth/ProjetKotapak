using UnityEngine;
using System.Collections;

public class MenuTextBehaviourScript : MonoBehaviour {
	
	Color couleurEntrer = Color.red;
	Color couleurSortie = Color.white;
	int tailleEntrer = 45;
	int tailleSortie = 25;
	
	// Use this for initialization
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	public void OnMouseEnter() 
	{
	    guiText.material.color = couleurEntrer;
	    guiText.fontSize = tailleEntrer;
		Debug.Log("Entrée");
	}
	
	public void OnMouseExit() 
	{
	    guiText.material.color = couleurSortie;
	    guiText.fontSize = tailleSortie;
		Debug.Log("Sortie");
	}	
	
}

