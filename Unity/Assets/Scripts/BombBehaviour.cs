using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
	
	
	private GameObject instantiated;
	
	[SerializeField]
	private GameObject ExplosionParticule;
	
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
				BombIsActive = false;
				currentTime = 0;
				
				
				// Reset position and velocity de la bombe
				_myTransform.transform.localPosition = Vector3.zero;
				_myRigidbody.rigidbody.velocity = Vector3.zero;
			}
		}
			
		
	}

	
}
