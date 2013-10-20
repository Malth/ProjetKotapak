using UnityEngine;
using System.Collections;

public class PutBomber : MonoBehaviour 
{
	private Transform _myTransform;
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
        Stock = GameObject.FindGameObjectsWithTag("BombTest");
		Compteur = 0;
		Debug.Log("Stock créé");
		TailleStock = Stock.Length;
		Debug.Log(TailleStock);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if (BombPresent == false)
			{
				Debug.Log("Espace appuyé");
				test = GameObject.FindGameObjectWithTag("Player").transform.localPosition;
				Debug.Log("Ma position : "+ test);
				//Poser une bombe
				BombeActuelle = Stock[compteur];
				BombeActuelle.BombIsActive(true);
				//BombeActuelle.activeSelf = true;
				compteur++;
			}
		}
	}
}
 