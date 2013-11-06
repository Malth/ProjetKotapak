using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	
	
	
	private string[] _resourceObjects = new string[2];
	
	
	
	
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
	
		ResourceObjects[0] = "DefaultBomb";
		ResourceObjects[1] = "MegaBomb";
	
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		
		
		
		
		if(Input.GetAxis("Mouse ScrollWheel")>0&&InCurrentSelection+1<ResourceObjects.Length)
			InCurrentSelection++;
		
		if(Input.GetAxis("Mouse ScrollWheel")<0&&InCurrentSelection-1>=0)
			InCurrentSelection--;
		
	
	}
}
