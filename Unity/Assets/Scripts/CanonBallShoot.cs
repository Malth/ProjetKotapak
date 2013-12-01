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
	
	
	IEnumerator Wait4seconds ()
	{
		yield return new WaitForSeconds(4);
		BulletStopped = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		if(BulletStopped)
		{
			StartCoroutine(Wait4seconds());
		}
		if(!BulletStopped)
		{
			switch(_tagName)
			{
				case "right" :	_myRigidBody.AddForce(Vector3.right *3);
				break;
				
				case "left" : _myRigidBody.AddForce(Vector3.left *3);
				break;
				
				case "top" : _myRigidBody.AddForce(Vector3.back *3);
				break;
				
				case "bottom" :	_myRigidBody.AddForce(Vector3.forward *3);
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

		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{

			Destroy(col.gameObject);

		}
		
		
	}
	
	
}
