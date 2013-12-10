using UnityEngine;
using System.Collections;
/// <summary>
/// Script managing the Detection of all bombs' explosion in multiplayer game.
/// </summary>
public class ExplosionDetection : MonoBehaviour 
{
	/// <summary>
	/// The kotapak input manager script.
	/// </summary>
	KotapakInputManager KotapakInputManagerScript ;
	void Start(){
		KotapakInputManagerScript = GameObject.Find("aKotapakInputManager").GetComponent<KotapakInputManager>();
		Debug.Log("input mana : "+ KotapakInputManagerScript);
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// When around a brick wall or a player, it destroy it.
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
			KotapakInputManagerScript._myNetworkView.RPC("KillPlayer", RPCMode.All, col.gameObject.tag);
		}
	}	
}
