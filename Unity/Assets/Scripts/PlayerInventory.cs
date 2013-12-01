using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	
	
	
	private Dictionary<string, int> _resourceObjects = new Dictionary<string,int> ();
	private Dictionary<int, string> _intToNameResourceObjects = new Dictionary<int,string> ();


	private Color _activeColor = new Color(0.5f,0.5f,0.5f,1f);
	private Color _inactiveColor = new Color(0.5f,0.5f,0.5f,0.2f);
	private KotapakInputManager kotapakInputManagerScript;

	
	
	public GameObject[] _ressourceButtons;
	public GameObject[] _stockIndicators;

	public GameObject[] StockIndicators {
		get {
			return _stockIndicators;
		}
		set {
			_stockIndicators = value;
		}
	}

	public GameObject playerAvatar;
	public GameObject playerMesh;
	public TextMesh[] itemsIndicator;


	public Texture[] texturesPlayerAvatar;




	
	public  Dictionary<string, int> ResourceObjects {
		
		get {
			return _resourceObjects;
		}
		set {
			_resourceObjects = value;
		}
	
	}

	public  Dictionary<int, string> IntToNameResourceObjects {

		get {
			return _intToNameResourceObjects;
		}
		set {
			_intToNameResourceObjects = value;
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


		for (int i = 1; i < StockIndicators.Length; i++) {


			StockIndicators[i].GetComponent<TextMesh>().text = ResourceObjects[_intToNameResourceObjects[i]].ToString();


		}



	}
	
	

	public void ChangeAvatar(string tagName){
		



		playerAvatar = GameObject.Find("Avatar");



		switch (tagName) 
		{

			case "player1":
			playerAvatar.renderer.material.mainTexture = texturesPlayerAvatar[0];
			playerMesh.renderer.materials [6].SetColor ("_Color", Color.blue);
			break;

			case "player2":
			playerAvatar.renderer.material.mainTexture = texturesPlayerAvatar [1];
			playerMesh.renderer.materials [6].SetColor ("_Color", Color.red);
			break;

			case "player3":
			playerAvatar.renderer.material.mainTexture = texturesPlayerAvatar[2];
			playerMesh.renderer.materials [6].SetColor ("_Color", Color.green);
			break;

			case "player4":
			playerAvatar.renderer.material.mainTexture = texturesPlayerAvatar[3];
			playerMesh.renderer.materials [6].SetColor ("_Color", Color.magenta);
			break;

		}
	}

	
	
	
	// Use this for initialization
	void Start () {
	
		_ressourceButtons = GameObject.FindGameObjectsWithTag("Buttons");

		// Initialisation des dictionnaires
		ResourceObjects.Add("DefaultBomb", 9999);
		ResourceObjects.Add("MegaBomb", 0);
		refreshButtons(0);

		IntToNameResourceObjects.Add(0, "DefaultBomb");
		IntToNameResourceObjects.Add(1, "MegaBomb");


		StockIndicators = GameObject.FindGameObjectsWithTag("Indicators");





		

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
