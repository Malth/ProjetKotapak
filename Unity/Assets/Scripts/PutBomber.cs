using UnityEngine;
using System.Collections;

public class PutBomber : MonoBehaviour 
{
	private Transform _myTransform;
	public Vector3 _myPosition;
	private bool _bombPresent = false;
	
	private BombBehaviour bombBehaviour ;
	
	
	private string _myTag;
	
	public string MyTag 
	{
		get {
			return this._myTag;
		}
		set {
			_myTag = value;
		}
	}
	
	
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
	
	private GameObject _ActualBomb;
	public GameObject ActualBomb
	{
		get {
			return this._ActualBomb;
		}
		set {
			_ActualBomb = value;
		}
	}	
	
	
	[SerializeField]
	private GameObject[] _standardBombsStock;
	public GameObject[] StandardBombsStock 
	{
		get {
			return this._standardBombsStock;
		}
		set {
			_standardBombsStock = value;
		}
	}


	

	// Use this for initialization
	void Start () 
	{
		
		_myTransform = this.transform;
		Compteur = 0;
		MyTag = gameObject.tag;
		
	}
	
	
	
	
		void resetBombe ()
	{
		ActualBomb.transform.localPosition = Vector3.zero;
		BombPresent = false;
	}
	
	
	
	
	IEnumerator BombeActivated ()
    {
			Debug.Log("Bombe Active");
			yield return new WaitForSeconds(3);
			bombBehaviour = ActualBomb.GetComponent<BombBehaviour>();
			bombBehaviour.PlayerName = _myTag;
			bombBehaviour.makeExplosion();
			compteur++;
			resetBombe();
    }
	
	
	

	
	
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) && BombPresent==false)
		{
			
			
			//Poser une bombe
			BombPresent = true;
			_myPosition = _myTransform.transform.position;
			
			int i = 0;
			
			do
			{
				Debug.Log(i);
				ActualBomb = StandardBombsStock[i];
			}
			while((ActualBomb.GetComponent<BombBehaviour>().BombIsActive==true && i < StandardBombsStock.Length));
			
			ActualBomb.transform.position = _myPosition;
			StartCoroutine(BombeActivated());
				
			
			
		}

	}
}

 