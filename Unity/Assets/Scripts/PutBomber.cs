using UnityEngine;
using System.Collections;

public class PutBomber : MonoBehaviour 
{
	private Transform _myTransform;
	private float temps = 0f;
	public Vector3 test;
	private bool _bombPresent = false;
	public bool BombPresent 
	{
		get {
			return this._bombPresent;
		}
		set {
			_bombPresent = value;
		}
	}

	private int compteur;
	public int Compteur 
	{
		get {
			return this.compteur;
		}
		set {
			compteur = value;
		}
	}
	
	private GameObject _BombeActuelle;
	public GameObject BombeActuelle
	{
		get {
			return this._BombeActuelle;
		}
		set {
			_BombeActuelle = value;
		}
	}	
	private GameObject[] _stock;
	public GameObject[] Stock 
	{
		get {
			return this._stock;
		}
		set {
			_stock = value;
		}
	}
	private int _tailleStock;
	public int TailleStock
	{
		get {
			return this._tailleStock;
		}
		set {
			_tailleStock = value;
		}
	}

	

	// Use this for initialization
	void Start () 
	{
		_myTransform = this.transform;
        Stock = GameObject.FindGameObjectsWithTag("Bombe1");
		Compteur = 0;
		Debug.Log("Stock créé");
		TailleStock = Stock.Length;
		Debug.Log(TailleStock);
	}

	void resetBombe ()
	{
		Stock[Compteur-1].transform.position = Stock[10].transform.position;
		Debug.Log ("Bombe disparue");
		BombPresent = false;
		temps = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && BombPresent==false)
		{
			Debug.Log("Espace appuyé");
			test = _myTransform.position;
			Debug.Log("Ma position : "+ test);
			//Poser une bombe
			BombPresent = true;
			test = _myTransform.transform.position;
			
			Stock[Compteur].transform.position = test;

			Debug.Log("Position de la bombe :"+Stock[Compteur].transform.position);
			
			Debug.Log("Bombe Posée");
			
			temps=0f;
			Compteur++;
		}
		if(BombPresent == true)
			temps += Time.deltaTime ;
		if (temps >= 4)
		{
			resetBombe ();
		}
	}
}

 