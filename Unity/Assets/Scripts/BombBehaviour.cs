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

	public void makeExplosion()
	{
		instantiated = (GameObject)Instantiate(Bombe1Explosion, transform.position, transform.rotation);
	}

	
}
