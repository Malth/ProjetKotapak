using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour 
{

	
	private Transform _myTransform;
	private Vector3 _lefDirection = new Vector3(0,270,0);
	private Vector3 _rightDirection = new Vector3(0,90,0);
	private Vector3 _topDirection = new Vector3(0,0,0);
	private Vector3 _bottomDirection = new Vector3(0,180,0);
	
	
	
	
	
	
	// Use this for initialization
	void Start () 
	{
	
		_myTransform = this.transform;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
		if(Input.GetKeyDown(KeyCode.S))
		{
			
			_myTransform.eulerAngles = _bottomDirection;
			
		}
	
		if(Input.GetKey(KeyCode.S))
		{
			_myTransform.localPosition += Vector3.back * 2 * Time.deltaTime;
		}
		
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.Z))
		{
			
			_myTransform.eulerAngles = _topDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.Z))
		{
			_myTransform.localPosition += Vector3.forward * 2 * Time.deltaTime;
		}
		
		
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.Q))
		{
			
			_myTransform.eulerAngles = _lefDirection;
			
		}
		
		if(Input.GetKey(KeyCode.Q))
		{
			_myTransform.localPosition += Vector3.left * 2 * Time.deltaTime;
		}
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.D))
		{
			
			_myTransform.eulerAngles = _rightDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.D))
		{
			_myTransform.localPosition += Vector3.right * 2 * Time.deltaTime;
		}
		
		


		
	}
	
	
}
