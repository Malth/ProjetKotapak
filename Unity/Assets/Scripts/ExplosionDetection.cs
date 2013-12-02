using UnityEngine;
using System.Collections;

public class ExplosionDetection : MonoBehaviour {
	
	

	public void OnTriggerEnter(Collider col) 
	{
		Debug.Log ("Tadaaaaa Trigger ok");
		//Si le Layer est un Brick
		if(col.gameObject.layer == LayerMask.NameToLayer("Bricks"))
		{
			Destroy(col.gameObject);
			Debug.Log ("Il y a un mur destructible.");
		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{

		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			Debug.Log ("Il y a un mur indestructible.");
		}
	}	
}
