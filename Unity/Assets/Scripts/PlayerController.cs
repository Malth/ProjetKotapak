using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	
	private Transform _myTransform;
	private Vector3 _lefDirection = new Vector3(0,90,0);
	private Vector3 _rightDirection = new Vector3(0,270,0);
	private Vector3 _topDirection = new Vector3(0,180,0);
	private Vector3 _bottomDirection = new Vector3(0,0,0);
	
	
	
	
	
	
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
			Debug.Log(_myTransform.localEulerAngles);;
			_myTransform.eulerAngles = _bottomDirection;
			
		}
	
		if(Input.GetKey(KeyCode.DownArrow))
		{
			_myTransform.localPosition += Vector3.back * 2 * Time.deltaTime;
		}
		
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			Debug.Log(_myTransform.localEulerAngles);;
			_myTransform.eulerAngles = _topDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			_myTransform.localPosition += Vector3.forward * 2 * Time.deltaTime;
		}
		
		
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Debug.Log(_myTransform.localEulerAngles);;
			_myTransform.eulerAngles = _lefDirection;
			
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			_myTransform.localPosition += Vector3.left * 2 * Time.deltaTime;
		}
		
		
		
		
		
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			Debug.Log(_myTransform.localEulerAngles);;
			_myTransform.eulerAngles = _rightDirection;
			
		}
		
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			_myTransform.localPosition += Vector3.right * 2 * Time.deltaTime;
		}
		
		


		
	}
	
	
}
