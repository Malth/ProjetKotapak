using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
	
	
	private GameObject Player1 ;
	private GameObject instantiated;
	[SerializeField]
	private GameObject Bombe1Explosion;


	
	private PutBomber putBomber ;
	private bool _bombIsActive = false;
	public bool BombIsActive 
	{
		get {
			return this._bombIsActive;
		}
		set {
			_bombIsActive = value;
		}
	}
	// Use this for initialization
	void Start () {
		
		Player1 = GameObject.FindGameObjectWithTag("Player");
		putBomber = Player1.GetComponentInChildren<PutBomber>();
		
	}

	public void Ecrire()
	{
		instantiated = (GameObject)Instantiate(Bombe1Explosion, transform.position, transform.rotation);
	}

	public void OnTriggerEnter(Collider col) 
	{
		Debug.Log ("Tadaaaaa Trigger ok");
		//Si le Layer est un Brick
		if(col.gameObject.layer == LayerMask.NameToLayer("Bricks"))
		{
			Debug.Log ("Il y a un mur destructible.");
		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			Debug.Log ("Il y a un joueur.");
		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			Debug.Log ("Il y a un mur indestructible.");
		}
	}	
}
