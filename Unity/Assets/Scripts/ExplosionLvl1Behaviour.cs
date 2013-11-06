using UnityEngine;
using System.Collections;

public class ExplosionLvl1Behaviour : MonoBehaviour {


	
	
	
	// Use this for initialization
	IEnumerator Start () {
	
		
		yield return new WaitForSeconds(2F);
		Debug.Log("Explosion d'une bombe du joueur :"+gameObject.tag);
		Destroy(gameObject);
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
