using UnityEngine;
using System.Collections;

public class ExplosionLvl1Behaviour : MonoBehaviour {


	public float timeOfExplosion;
	private float currentTime = 0;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		
		if(currentTime>timeOfExplosion)
		{
			Destroy(this.gameObject);	
		}
		
	}
}
