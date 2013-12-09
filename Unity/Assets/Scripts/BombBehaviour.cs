using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
	
	
	private GameObject instantiated;
	
	[SerializeField]
	private GameObject ExplosionParticule;
	public KotapakNetworkScript networkScript;
	
	public float timeBeforeExplosion;
	private float currentTime = 0;
	
	private string _playerName;
	
	public string PlayerName{
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}
	


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
	
	private Transform _myTransform ;
	private Rigidbody _myRigidbody ;

	
	
	
	public void makeExplosion()
	{
		instantiated = (GameObject)Instantiate(ExplosionParticule, transform.position, transform.rotation);
		instantiated.tag = PlayerName;
	}
	
	void Start()
		
	{
		_myTransform = this.transform;
		_myRigidbody = this.rigidbody;
	}
	
	void Update()	
	{
		
		if(BombIsActive)
		{
			currentTime += Time.deltaTime;
			if(currentTime>timeBeforeExplosion)
			{
				makeExplosion();
				currentTime = 0;
				Destroy (this.gameObject);

			}
		}
			
		
	}

	
}
