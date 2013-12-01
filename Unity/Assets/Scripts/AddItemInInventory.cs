using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddItemInInventory : MonoBehaviour {

	[SerializeField]
	private KotapakInputManager KotapakInputManagerScript;

	private string _myTag ;


	void Start()
	{
		_myTag = this.tag;
	}



	void OnTriggerEnter(Collider col) 
	{

		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{

			KotapakInputManagerScript.playerInventory[int.Parse (Network.player.ToString ()) - 1].ResourceObjects[_myTag]++;
			KotapakInputManagerScript._myNetworkView.RPC ("AddItemsToStock", RPCMode.Server, Network.player, _myTag, KotapakInputManagerScript.playerInventory[int.Parse (Network.player.ToString ()) - 1].ResourceObjects[_myTag]) ;
			
			Network.Destroy(gameObject);
		}

	}	
}
