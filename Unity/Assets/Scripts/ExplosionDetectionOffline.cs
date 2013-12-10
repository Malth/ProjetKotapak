using UnityEngine;
using System.Collections;

/// <summary>
/// Script managing the Detection of all bombs' explosion in solo game.
/// </summary>
public class ExplosionDetectionOffline : MonoBehaviour
{
	/// <summary>
	/// Raises the trigger enter event. 
	/// When hitting a brick it destroys him.
	/// When hitting a player, it destroys it and launch appropriate scene.
	/// </summary>
	/// <param name='col'>
	/// Col.
	/// </param>
	public void OnTriggerEnter(Collider col) 
	{
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
	}	
}
