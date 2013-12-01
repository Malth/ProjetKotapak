using UnityEngine;
using System.Collections;

public class CanonBallShoot : MonoBehaviour {
	
	
	
	
	
	private string _tagName ;
	private Rigidbody _myRigidBody;
	private Transform _myTransform;
	private Vector3 _defaultPosition;
	private bool _bulletStopped = false;

	public bool BulletStopped {
		get {
			return this._bulletStopped;
		}
		set {
			_bulletStopped = value;
		}
	}	
	
	
	// Use this for initialization
	void Start () {
		
		_myRigidBody = this.rigidbody;
		_defaultPosition = this.transform.localPosition;
		_myTransform = this.transform;
		_tagName = this.tag;
		 
		
	}
	
	
	IEnumerator Wait3seconds ()
	{
		yield return new WaitForSeconds(3);
		BulletStopped = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(BulletStopped)
		{
			StartCoroutine(Wait3seconds());
		}
		if(!BulletStopped)
		{
			switch(_tagName)
			{
				case "right" :	_myRigidBody.AddForce(Vector3.right *5);
				break;
				
				case "left" : _myRigidBody.AddForce(Vector3.left *5);
				break;
				
				case "top" : _myRigidBody.AddForce(Vector3.back *5);
				break;
				
				case "bottom" :	_myRigidBody.AddForce(Vector3.forward *5);
				break;
			}
			
		}
		 
	}
	
	
	public void OnTriggerEnter(Collider col) 
		
	{
		
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			_myTransform.localPosition = _defaultPosition;
			_myRigidBody.velocity = Vector3.zero;
			BulletStopped = true;	
		}
		
		
		
	}
	
	
}
