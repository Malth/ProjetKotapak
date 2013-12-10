using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventoryOffline : MonoBehaviour {



	private Dictionary<string, int> _resourceObjects = new Dictionary<string,int> ();
	private Dictionary<int, string> _intToNameResourceObjects = new Dictionary<int,string> ();


	private Color _activeColor = new Color(0.5f,0.5f,0.5f,1f);
	private Color _inactiveColor = new Color(0.5f,0.5f,0.5f,0.2f);


	public GameObject[] _ressourceButtons;
	public GameObject playerAvatar;
	public GameObject playerMesh;
	public TextMesh[] itemsIndicator;


	public  Dictionary<string, int> ResourceObjects {

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



	public void RefreshRessource()
	{

		for (int i = 1; i < ResourceObjects.Count; i++) {
			itemsIndicator[i].text = ResourceObjects[_intToNameResourceObjects[i]].ToString();
		}

	}



	void refreshButtons(int InCurrentSelection)
	{

		for(int i = 0; i<ResourceObjects.Count;i++)
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


	// Use this for initialization
	void Start () {

		// Initialisation des dictionnaires
		ResourceObjects.Add("DefaultBomb", 9999);
		ResourceObjects.Add("MegaBomb", 0);


		_intToNameResourceObjects.Add(0, "DefaultBomb");
		_intToNameResourceObjects.Add(1, "MegaBomb");


		refreshButtons(0);

	}





	// Update is called once per frame
	void Update () 
	{



		if(Input.GetAxis("Mouse ScrollWheel")>0&&InCurrentSelection+1<ResourceObjects.Count)
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
