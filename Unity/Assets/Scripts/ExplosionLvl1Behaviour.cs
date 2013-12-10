using UnityEngine;
using System.Collections;

/// <summary>
/// Explosion behaviour in level 1.
/// </summary>
public class ExplosionLvl1Behaviour : MonoBehaviour 
{
	public float timeOfExplosion;
	private float currentTime = 0;
	
	/// <summary>
	/// Start this instance. Initialization.
	/// </summary>
	void Start () {		
	}
	/// <summary>
	/// Destroy bombs after a delay.
	/// </summary>
	void Update () {
		currentTime += Time.deltaTime;		
		if(currentTime>timeOfExplosion)
		{
			Destroy(this.gameObject);	
		}
		
	}
}
