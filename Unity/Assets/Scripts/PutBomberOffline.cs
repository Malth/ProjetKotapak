using UnityEngine;
using System.Collections;

public class PutBomberOffline : MonoBehaviour 
{
	private Transform _myTransform;
	public Vector3 _myPosition;
	private bool _bombPresent = false;

	private BombBehaviour bombBehaviour ;
	private PlayerInventoryOffline playerInventory ;


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
	private GameObject StandardBomb;
	[SerializeField]
	private GameObject MegaBomb;




	// Use this for initialization
	void Start () 
	{

		_myTransform = this.transform;
		MyTag = gameObject.tag;
		playerInventory = gameObject.GetComponent<PlayerInventoryOffline>();


	}







	void BombeActivated(GameObject _myBomb)
	{

		bombBehaviour = _myBomb.GetComponent<BombBehaviour>();
		bombBehaviour.PlayerName = _myTag;
		bombBehaviour.BombIsActive = true;

	}






	private void PutBomb(GameObject kindOfBomb){

		//Poser une bombe

		GameObject _myBomb =Instantiate (kindOfBomb) as GameObject;

		Debug.Log ("Mettre une bombe");
		_myPosition = _myTransform.position;


		_myBomb.transform.position = _myPosition;
		_myBomb.rigidbody.velocity = Vector3.zero;

		BombeActivated(_myBomb);






	}


	// Update is called once per frame
	void Update () 
	{



		if(Input.GetKeyDown(KeyCode.Space))
		{



			switch(playerInventory.InCurrentSelection)
			{
				case 0: PutBomb(StandardBomb);
				break;

				case 1: if(playerInventory.ResourceObjects["MegaBomb"]>0)
				{ 
					PutBomb(MegaBomb); 
					playerInventory.ResourceObjects["MegaBomb"]--;
					playerInventory.RefreshRessource();
				}
				break;

			}



		}







	}
}

