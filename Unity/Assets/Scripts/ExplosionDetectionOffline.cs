using UnityEngine;
using System.Collections;

public class ExplosionDetectionOffline : MonoBehaviour {
	
	

	public void OnTriggerEnter(Collider col) 
	{
		Debug.Log ("Tadaaaaa Trigger ok");

		if(col.gameObject.layer == LayerMask.NameToLayer("Bricks"))
		{
			Destroy(col.gameObject);

		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			Destroy (col.gameObject);
			if(col.gameObject.tag=="player1")
			Application.LoadLevel ("looser");
			if(col.gameObject.tag=="AIplayer")
			Application.LoadLevel ("winner");

		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{

		}
	}	
}
