using UnityEngine;
using System.Collections;

public class RandomLighting : MonoBehaviour {

	// Use this for initialization

	private float _currentTime = 0;
	private float _randomOn = 0;
	private float _randomOff = 0; 

	[SerializeField]
	private Light _myLight;

	void RandomValue(){
	
		_randomOff = Random.Range (0f, 5f);
		_randomOn = Random.Range (0f, 1.5f);
	}


	void Start () {
		RandomValue ();
	}


	
	// Update is called once per frame
	void Update () {
	
		_currentTime += Time.deltaTime;

		if (_currentTime > _randomOff)
		{
			_myLight.intensity = 0.6f;
			if (_currentTime > _randomOn + _randomOff) 
			{
				_myLight.intensity = 0.0f;
				RandomValue ();
				_currentTime = 0;
			}
		}



	}
}
