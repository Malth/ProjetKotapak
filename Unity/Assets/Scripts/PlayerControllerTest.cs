using UnityEngine;
using System.Collections;

public class PlayerControllerTest : MonoBehaviour 
{

	
	private Transform _myTransform;
	private Vector3 _lefDirection = new Vector3(0,90,0);
	private Vector3 _rightDirection = new Vector3(0,270,0);
	private Vector3 _topDirection = new Vector3(0,180,0);
	private Vector3 _bottomDirection = new Vector3(0,0,0);
	private int _inCurrentDeplacement = 0;



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
		if(Time.timeScale == 0 )
		{
			if (Input.GetKeyUp(KeyCode.P))
			{
				Debug.Log ("Resume");
				Time.timeScale = 1;
			}
		}
		else
		{
			if (Input.GetKeyUp(KeyCode.P))
			{
				Debug.Log ("Pause");
				Time.timeScale = 0;
			}
			
			if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 1) 
			{	
				if(Input.GetKey(KeyCode.DownArrow))
				{
					if(_inCurrentDeplacement == 0)
					{
						_myTransform.eulerAngles = _bottomDirection;
						_inCurrentDeplacement = 1;
	
					}
					_myTransform.localPosition += Vector3.back * SpeedWalk * Time.deltaTime;
				}
				if(Input.GetKeyUp(KeyCode.DownArrow))
				{
					_inCurrentDeplacement = 0;
				}
			}
					
			if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 2) 
			{
					
				if (Input.GetKey (KeyCode.UpArrow)) {
					if(_inCurrentDeplacement == 0) {
	
						_myTransform.eulerAngles = _topDirection;
						_inCurrentDeplacement = 2;
	
					}
						_myTransform.localPosition += Vector3.forward * SpeedWalk * Time.deltaTime;
				}
	
	
				if(Input.GetKeyUp(KeyCode.UpArrow))
				{
					_inCurrentDeplacement = 0;
				}
			}	
			
			if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 3)
			{
				if (Input.GetKey (KeyCode.LeftArrow)) {
					if (_inCurrentDeplacement == 0) {
	
						_myTransform.eulerAngles = _lefDirection;
						_inCurrentDeplacement = 3;
					}
						_myTransform.localPosition += Vector3.left * SpeedWalk * Time.deltaTime;
				}
				if(Input.GetKeyUp(KeyCode.LeftArrow))
				{
					_inCurrentDeplacement = 0;
				}
			}
			
			if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 4) 
			{
				if (Input.GetKey (KeyCode.RightArrow)) {
					if (_inCurrentDeplacement == 0) {
	
						_myTransform.eulerAngles = _rightDirection;
						_inCurrentDeplacement = 4;
					}
						_myTransform.localPosition += Vector3.right * SpeedWalk * Time.deltaTime;
				}
				if(Input.GetKeyUp(KeyCode.RightArrow))
				{
					_inCurrentDeplacement = 0;
				}
			}
		}
	}
	
}
