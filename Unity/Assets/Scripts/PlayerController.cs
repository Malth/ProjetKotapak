using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	[SerializeField]
	public Transform _myTransform;
	public Vector3 _lefDirection = new Vector3(0,90,0);
	public Vector3 _rightDirection = new Vector3(0,270,0);
	public Vector3 _topDirection = new Vector3(0,180,0);
	public Vector3 _bottomDirection = new Vector3(0,0,0);
	public int _inCurrentDeplacement = 0;



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
	
	
	
	



	public void MoveToDown(){
				Debug.Log ("Entre dans MoveToDow");
		if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 1) 
		{

			Debug.Log ("Entre dans la condition MoveToDow");

				if(_inCurrentDeplacement == 0)
				{
					_myTransform.eulerAngles = _bottomDirection;
					_inCurrentDeplacement = 1;

				}
				_myTransform.localPosition += Vector3.back * SpeedWalk * Time.deltaTime;



		}
	}


	public void MoveToUp(){
		if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 2) 
		{


				if(_inCurrentDeplacement == 0) {

					_myTransform.eulerAngles = _topDirection;
					_inCurrentDeplacement = 2;

				}
				_myTransform.localPosition += Vector3.forward * SpeedWalk * Time.deltaTime;


		

		}
	}

	public void MoveToLeft(){
		if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 3)
		{


				if (_inCurrentDeplacement == 0) {

					_myTransform.eulerAngles = _lefDirection;
					_inCurrentDeplacement = 3;

				}
				_myTransform.localPosition += Vector3.left * SpeedWalk * Time.deltaTime;
			


				_inCurrentDeplacement = 0;

		}
	
	}

	public void MoveToRight(){
		if (_inCurrentDeplacement == 0 || _inCurrentDeplacement == 4) 
		{


				if (_inCurrentDeplacement == 0) {

					_myTransform.eulerAngles = _rightDirection;
					_inCurrentDeplacement = 4;
				}
				_myTransform.localPosition += Vector3.right * SpeedWalk * Time.deltaTime;


				_inCurrentDeplacement = 0;


		}
	}


	
}
