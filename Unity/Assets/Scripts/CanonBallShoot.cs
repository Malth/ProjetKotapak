using UnityEngine;
using System.Collections;

/// <summary>
/// Script managing Cannon ball shoot.
/// </summary>
public class CanonBallShoot : MonoBehaviour 
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


	KotapakInputManager KotapakInputManagerScript ;

	
	// Use this for initialization
	void Start () 
	{		
		_myRigidBody = this.rigidbody;
		_defaultPosition = this.transform.localPosition;
		_myTransform = this.transform;
		_tagName = this.tag;	
		KotapakInputManagerScript = GameObject.Find("aKotapakInputManager").GetComponent<KotapakInputManager>();	
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
	

	public void OnTriggerEnter(Collider col) 		
	{

		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			// Ré-initialisation des boulets de canon
			_myTransform.localPosition = _defaultPosition;
			_myRigidBody.velocity = Vector3.zero;
			BulletStopped = true;

		}


		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			// Tuer le joueur touché
			KotapakInputManagerScript._myNetworkView.RPC("KillPlayer", RPCMode.All, col.gameObject.tag);
		}


	}
	
	
}
