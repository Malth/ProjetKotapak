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
		KotapakInputManagerScript = GameObject.Find("aKotapakNetworkManager").GetComponent<KotapakInputManager>();
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
			KotapakInputManagerScript._myNetworkView.RPC ("CheckSurvivorAndDie", RPCMode.Server, col.gameObject.tag);

		}
	}	
}
