using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	
	private Transform _myTransform;
	private Vector3 _lefDirection = new Vector3(0,90,0);
	private Vector3 _rightDirection = new Vector3(0,270,0);
	private Vector3 _topDirection = new Vector3(0,180,0);
	private Vector3 _bottomDirection = new Vector3(0,0,0);


	[SerializeField]
	private int _speedWalk;


	public int SpeedWalk {
		get {
			return _speedWalk;
		}
		set {
			_speedWalk = value;
		}
	}
	
	
	
	
	// Use this for initialization
	void Start () 
	{
	
		_myTransform = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			
			Debug.Log("ok");
			_myTransform.eulerAngles = _bottomDirection;
			
		}
	
		if(Input.GetKey(KeyCode.DownArrow))
		{
			_myTransform.localPosition += Vector3.back * SpeedWalk * Time.deltaTime;
		}
		
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			
			_myTransform.eulerAngles = _topDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			_myTransform.localPosition += Vector3.forward * SpeedWalk * Time.deltaTime;
		}
		
		
		
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			
			_myTransform.eulerAngles = _lefDirection;
			
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			_myTransform.localPosition += Vector3.left * SpeedWalk * Time.deltaTime;
		}
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			
			_myTransform.eulerAngles = _rightDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			_myTransform.localPosition += Vector3.right * SpeedWalk * Time.deltaTime;
		}
		
		


		
	}
	
	
}
