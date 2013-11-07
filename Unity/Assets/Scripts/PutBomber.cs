using UnityEngine;
using System.Collections;

public class PutBomber : MonoBehaviour 
{
	private Transform _myTransform;
	public Vector3 _myPosition;
	private bool _bombPresent = false;
	
	private BombBehaviour bombBehaviour ;
	private PlayerInventory playerInventory ;
	
	
	public float lifeTimeOfBomb;
	private float currentTime = 0;
	
	
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
	
	
	[SerializeField]
	private GameObject[] _megaBombsStock;
	public GameObject[] MegadBombsStock 
	{
		get {
			return this._megaBombsStock;
		}
		set {
			_megaBombsStock = value;
		}
	}


	

	// Use this for initialization
	void Start () 
	{
		
		_myTransform = this.transform;
		MyTag = gameObject.tag;
		playerInventory = gameObject.GetComponent<PlayerInventory>();
		
		
	}
	
	
	

	
	
	
	void BombeActivated()
    {
			
			bombBehaviour = ActualBomb.GetComponent<BombBehaviour>();
			bombBehaviour.PlayerName = _myTag;
			bombBehaviour.BombIsActive = true;

    }
	
	
	

	
	
	private void PutBomb(GameObject[] stock){
		
		//Poser une bombe
			BombPresent = true;
			_myPosition = _myTransform.position;
			
			int i = 0;
			
			do
			{
				ActualBomb = stock[i];
				i++;
			}
		
		
			while((ActualBomb.GetComponent<BombBehaviour>().BombIsActive==true && i < stock.Length));
			
			ActualBomb.transform.position = _myPosition;
			ActualBomb.rigidbody.velocity = Vector3.zero;
			BombeActivated();
		
			
			
		
		
			
			
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
		
		
		if(Input.GetKeyDown(KeyCode.Space) && BombPresent==false)
		{
			
			
			
			switch(playerInventory.InCurrentSelection)
			{
				case 0: PutBomb(StandardBombsStock);
				break;
				
				case 1: PutBomb(MegadBombsStock);
				break;
					
			}
			
			
			
		}
		
		if(BombPresent)
		{
			currentTime += Time.deltaTime;
			if(currentTime>lifeTimeOfBomb)
			{
				BombPresent = false;
				currentTime = 0;
			}
		}
		
		
			
			

	}
}

 