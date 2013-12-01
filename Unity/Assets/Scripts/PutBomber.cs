using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
	


	[SerializeField]
	public GameObject[] Bombes ;


	// Use this for initialization
	void Start () 
	{
		
		_myTransform = this.transform;
		MyTag = gameObject.tag;
		playerInventory = gameObject.GetComponent<PlayerInventory>();
		
		
	}
	
	
	

	
	
	
	void BombeActivated(GameObject myBomb)
    {
			
			bombBehaviour = myBomb.GetComponent<BombBehaviour>();
			bombBehaviour.PlayerName = _myTag;
			bombBehaviour.BombIsActive = true;

    }
	
	
	

	
	
	public void PutBomb(GameObject kindOfBomb){
		
		GameObject myBomb = Instantiate (kindOfBomb)as GameObject;
		_myPosition = _myTransform.position;
		myBomb.transform.position = _myPosition;
		myBomb.rigidbody.velocity = Vector3.zero;

			
		BombeActivated(myBomb);
						
	}



	public void wantToPutBomb(PlayerInventory actualPlayerInventory){


			Debug.Log (actualPlayerInventory.InCurrentSelection);
			switch(actualPlayerInventory.InCurrentSelection)
			{
				case 0: PutBomb(Bombes[actualPlayerInventory.InCurrentSelection]);
				break;


				case 1: 
					PutBomb(Bombes[actualPlayerInventory.InCurrentSelection]); 
					//actualPlayerInventory.ResourceObjects ["MegaBomb"]--;
					//actualPlayerInventory.RefreshRessource ();
				
				break;

			/*
				case 1: if(actualPlayerInventory.ResourceObjects["MegaBomb"]>0)
				{ 
					PutBomb(Bombes[actualPlayerInventory.InCurrentSelection]); 
					actualPlayerInventory.ResourceObjects ["MegaBomb"]--;
					actualPlayerInventory.RefreshRessource ();
				}
				break;
			*/

			}



	}

	
	// Update is called once per frame
	void Update () 
	{
		
		




		
		
			
			

	}
}

 