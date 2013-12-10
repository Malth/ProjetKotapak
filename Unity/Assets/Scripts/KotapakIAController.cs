using UnityEngine;
using System.Collections;
using System;
/// <summary>
/// Script controlling the IA in all offline games.
/// </summary>
public class KotapakIAController : MonoBehaviour {
	
	private Transform _myTransform;
	private Vector3 _lefDirection = new Vector3(0,90,0);
	private Vector3 _rightDirection = new Vector3(0,270,0);
	private Vector3 _topDirection = new Vector3(0,180,0);
	private Vector3 _bottomDirection = new Vector3(0,0,0);
	private int _inCurrentDeplacement = 0;



	
	
	private int j;	
	private int _choice;
	
	/// <summary>
	/// The speed walk of all players.
	/// </summary>
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
	
	/// <summary>
	/// On update, choose a random direction for 200 iterations.
	/// </summary>
	void Update () 
	{	
		if (j >200)
		{
			System.Random random = new System.Random();
			_choice = random.Next(0, 40); 
			j = 0;
		}
		
		if( _choice <= 10)
		{
			_myTransform.eulerAngles = _bottomDirection;
			_myTransform.localPosition += Vector3.back * SpeedWalk * Time.deltaTime;
		}
		if (_choice > 10 && _choice <= 20) 
		{
			_myTransform.eulerAngles = _topDirection;
			_myTransform.localPosition += Vector3.forward * SpeedWalk * Time.deltaTime;
		}
		
		if (_choice > 20 && _choice <= 30) 
		{
			_myTransform.eulerAngles = _lefDirection;
			_myTransform.localPosition += Vector3.left * SpeedWalk * Time.deltaTime;
		}
		
		if (_choice > 30) {
			_myTransform.eulerAngles = _rightDirection;
			_myTransform.localPosition += Vector3.right * SpeedWalk * Time.deltaTime;
		}
		j++;		
	}	
}
