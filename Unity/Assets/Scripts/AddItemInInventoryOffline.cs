using UnityEngine;
using System.Collections;

public class AddItemInInventoryOffline : MonoBehaviour {


	private PlayerInventoryOffline playerInventory;
	private string _myTag ;


	void Start()
	{
		_myTag = this.tag;
	}



	void OnTriggerEnter(Collider col) 
	{

		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{

			playerInventory = col.GetComponent<PlayerInventoryOffline>();

			playerInventory.ResourceObjects[_myTag]++;
			playerInventory.RefreshRessource();

			Destroy(gameObject);
		}

	}	
}
