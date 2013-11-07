using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	
	
	
	private string[] _resourceObjects = new string[2];
	private Color _activeColor = new Color(0.5f,0.5f,0.5f,1f);
	private Color _inactiveColor = new Color(0.5f,0.5f,0.5f,0.2f);
	
	
	public GameObject[] _ressourceButtons;
	
	
	
	public string[] ResourceObjects {
		
		get {
			return _resourceObjects;
		}
		set {
			_resourceObjects = value;
		}
	
	}
	
	
	
		
	private int _inCurrentSelection = 0;
	
	public int InCurrentSelection {
		
		get {
			return _inCurrentSelection;
		}
		set {
			_inCurrentSelection = value;
		}
	
	}
	
	
	
	
	
	
	
	
	// Use this for initialization
	void Start () {
	
		// Initialisation des objets
		ResourceObjects[0] = "DefaultBomb";
		ResourceObjects[1] = "MegaBomb";
		
		refreshButtons(0);
		
		
	}
	
	
	
	void refreshButtons(int InCurrentSelection)
	{
		for(int i = 0; i<ResourceObjects.Length;i++)
		{

			if(i==InCurrentSelection)
			{
				_ressourceButtons[i].renderer.material.SetColor("_TintColor", _inactiveColor) ;	
			}
			else
			{
				_ressourceButtons[i].renderer.material.SetColor("_TintColor", _activeColor);	
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		
		if(Input.GetAxis("Mouse ScrollWheel")>0&&InCurrentSelection+1<ResourceObjects.Length)
		{
			InCurrentSelection++;	
			refreshButtons(InCurrentSelection);
		}
		
		if(Input.GetAxis("Mouse ScrollWheel")<0&&InCurrentSelection-1>=0)
		{
			InCurrentSelection--;
			refreshButtons(InCurrentSelection);
		}
		
		
		
		
		
	
	}
}
