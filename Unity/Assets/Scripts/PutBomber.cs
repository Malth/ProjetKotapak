using UnityEngine;
using System.Collections;

public class PutBomber : MonoBehaviour 
{
	private Transform _myTransform;
	public Vector3 test;
	private bool _bombPresent = false;
	
	private BombBehaviour bombBehaviour ;
	
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
		BombPresent = false;
	}
	
	
	
	
	IEnumerator BombeActivated ()
    {
			Debug.Log("Bombe Active");
			yield return new WaitForSeconds(3);
			bombBehaviour = Stock[Compteur].GetComponent<BombBehaviour>();
			print(bombBehaviour);
			bombBehaviour.Ecrire();
			compteur++;
			resetBombe();
    }
	
	
	

	
	
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && BombPresent==false)
		{
			
			test = _myTransform.position;
			//Poser une bombe
			BombPresent = true;
			test = _myTransform.transform.position;
			
			Stock[Compteur].transform.position = test;
			StartCoroutine(BombeActivated());
				
			
			
		}

	}
}

 