using UnityEngine;
using System.Collections;

/// <summary>
/// Script managing Cannon ball shoot.
/// </summary>
public class CanonBallShootOffline : MonoBehaviour 
{
	private string _tagName ;
	private Rigidbody _myRigidBody;
	private Transform _myTransform;
	private Vector3 _defaultPosition;
	/// <summary>
	/// Boolean stating true if a bullet has been stopped, false esle.
	/// </summary>
	private bool _bulletStopped = false;
	/// <summary>
	/// Boolean stating true if a bullet has been stopped, false esle.
	/// </summary>
	public bool BulletStopped 
	{
		get {
			return this._bulletStopped;
		}
		set {
			_bulletStopped = value;
		}
	}	
	
	
	// Use this for initialization
	void Start () 
	{		
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
	
	
	/// <summary>
	/// Launch a bullet every seconds, if no bullet launched.
	/// </summary>
	void Update () 
	{
		if(BulletStopped)
		{
			StartCoroutine(Wait4seconds());
			_myTransform.localPosition = _defaultPosition;
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
	
	/// <summary>
	/// Raises the trigger enter event. When hitting a wall it resets the bullet
	/// When hitting a player, it kills him.
	/// </summary>
	/// <param name='col'>
	/// Collider
	/// </param>
	public void OnTriggerEnter(Collider col) 		
	{
		
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			_myTransform.localPosition = _defaultPosition;
			_myRigidBody.velocity = Vector3.zero;
			BulletStopped = true;

		}

		if(col.gameObject.layer == LayerMask.NameToLayer("Player") && col.gameObject.tag == "player1")
		{
			Destroy(col.gameObject);
			Application.LoadLevel ("looser");
		}


	}
	
	
}
