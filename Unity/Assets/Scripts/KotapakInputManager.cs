using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class KotapakInputManager : MonoBehaviour {




	[SerializeField]
	public List<GameObject> PlayersOnline = new List<GameObject> ();



	[SerializeField]
	private GameObject _prefabPlayer;

	Vector3[] spawns = new Vector3[4];
	private KotapakNetworkScript kotapakNetworkScript;
	private PutBomber putBomberScript;
	public PlayerInventory playerInventoryScript;

	[SerializeField]
	private GameObject GUIcamera ;

	List <PlayerController> playersController = new List<PlayerController>() ;
	List <PutBomber> putBombers = new List<PutBomber>();
	public List <PlayerInventory> playerInventory = new List<PlayerInventory>();



	
   	int count = 0;
   
	[SerializeField]
	public NetworkView _myNetworkView ;

	void Start () {
		kotapakNetworkScript = GameObject.Find("aKotapakNetworkManager").GetComponent<KotapakNetworkScript>();
		GameObject myGUIcamera = Instantiate (GUIcamera) as GameObject;
		DontDestroyOnLoad (myGUIcamera);
	
		
		//Chargement des spawns
		spawns[0] = new Vector3(12,1,12);
		spawns[1] = new Vector3(-12,1,12);
		spawns[2] = new Vector3(12,1,-12);
		spawns[3] = new Vector3(-12,1,-12);
		
		if (Network.isServer) {
		for (int i = 0; i< Network.connections.Length; i++)
				_myNetworkView.RPC ("createNewPlayer", RPCMode.All);
		}

				
	}
	

	
	void Update () {

		if (Network.isClient) 
		{


			if (Input.GetKeyDown (KeyCode.DownArrow)) 
			{
				_myNetworkView.RPC ("PlayerWantToMoveDown", RPCMode.Server, Network.player, true);
			
			}

			if (Input.GetKeyUp (KeyCode.DownArrow)) 
			{

				_myNetworkView.RPC ("PlayerWantToMoveDown", RPCMode.Server, Network.player, false);
			
			}


			if (Input.GetKeyDown (KeyCode.UpArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, true);


			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, false);
			}		

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, true);


			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, false);
			}	


			if (Input.GetKeyDown (KeyCode.RightArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveRight", RPCMode.Server, Network.player, true);


			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveRight", RPCMode.Server, Network.player, false);
			}	
			
			if (Input.GetKeyUp (KeyCode.Space)) 
			{
				_myNetworkView.RPC("PlayerRefreshButton", RPCMode.Server, Network.player, playerInventory[int.Parse(Network.player.ToString())-1].InCurrentSelection );
				_myNetworkView.RPC ("PlayerWantPutBomb", RPCMode.Server, Network.player, true);
				_myNetworkView.RPC ("PlayerMAJstock", RPCMode.Server, Network.player, playerInventory[int.Parse(Network.player.ToString())-1].IntToNameResourceObjects[playerInventory[int.Parse(Network.player.ToString())-1].InCurrentSelection]);
			}

		} 


	}

	void FixedUpdate(){


		foreach (var p in kotapakNetworkScript.DicoPlayersIntents) {


			if (p.Value._wantToMoveDown || p.Value._wantToMoveUp || p.Value._wantToMoveRight || p.Value._wantToMoveLeft) {

				if (p.Value._wantToMoveDown) {
					playersController [int.Parse (p.Key.ToString ())-1].MoveToDown ();
				} 

				if (p.Value._wantToMoveUp) {
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToUp ();
				} 


				if (p.Value._wantToMoveLeft) {
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToLeft ();
				}

				if (p.Value._wantToMoveRight) {
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToRight ();
				}

			} else {
				try {
					playersController [int.Parse (p.Key.ToString ())-1]._inCurrentDeplacement=0;
					playersController [int.Parse (p.Key.ToString ())-1]._myRigidbody.velocity = Vector3.zero;
				} catch (System.Exception ex) {
					Debug.Log (ex.Message);
				}
			}

			if (p.Value._wantToPutBomb) {
				putBombers[int.Parse(p.Key.ToString ())-1].wantToPutBomb(playerInventory[int.Parse(p.Key.ToString ())-1]);
				kotapakNetworkScript.DicoPlayersIntents[p.Key]._wantToPutBomb = false;

			}


		}
	


	




	}

	[RPC]	
	void PlayerWantPutBomb(NetworkPlayer p, bool b)
	{
		int playerIndice = int.Parse(p.ToString())-1;
		if (playerInventory[playerIndice].ResourceObjects[playerInventory[playerIndice].IntToNameResourceObjects[playerInventory[playerIndice].InCurrentSelection]]>0) 
				{
						kotapakNetworkScript.DicoPlayersIntents [p]._wantToPutBomb = b;

						if (Network.isServer) {
								_myNetworkView.RPC ("PlayerWantPutBomb", RPCMode.OthersBuffered, p, b);
						}
				}

	}


    [RPC]
	void PlayerWantToMoveDown(NetworkPlayer p, bool b)
    {
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveDown = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveDown", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void PlayerWantToMoveUp(NetworkPlayer p, bool b)
	{
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveUp = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveUp", RPCMode.OthersBuffered, p, b);
		}
	}

	[RPC]
	void PlayerWantToMoveLeft(NetworkPlayer p, bool b)
	{
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveLeft = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveLeft", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void PlayerWantToMoveRight(NetworkPlayer p, bool b)
	{
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveRight = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveRight", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void PlayerRefreshButton(NetworkPlayer p, int currentSelect)
	{
		playerInventory [int.Parse (p.ToString ()) - 1].InCurrentSelection = currentSelect;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerRefreshButton", RPCMode.OthersBuffered, p, currentSelect );
		}
	}


	[RPC]
	void PlayerMAJstock(NetworkPlayer p, string key, int value)
	{
				Debug.Log ("Methode RPC playerMAJstock");
		playerInventory [int.Parse (p.ToString ()) - 1].ResourceObjects[key]= value;
		playerInventory [int.Parse (p.ToString ()) - 1].RefreshRessource ();

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerMAJstock", RPCMode.OthersBuffered, p, key,value );
		}
	}


	[RPC]
	void AddItemsToStock(NetworkPlayer p, string key, int value)
	{
		playerInventory [int.Parse (p.ToString ()) - 1].ResourceObjects[key]=value;
		_myNetworkView.RPC("PlayerMAJstock", RPCMode.OthersBuffered, p, key, value );


		if (Network.isServer)
		{
			_myNetworkView.RPC("AddItemsToStock", RPCMode.OthersBuffered, p );
		}
	}




	[RPC]
	void createNewPlayer()
	{
		GameObject Player = Instantiate(_prefabPlayer) as GameObject;
		Player.tag = "player" + (count+1).ToString() ;
		Debug.Log(Player.tag);
		Player.transform.position = spawns[count];
		playersController.Add(Player.GetComponent<PlayerController>());
		putBombers.Add(Player.GetComponent<PutBomber>());
		playerInventoryScript = Player.GetComponent<PlayerInventory> ();
		playerInventoryScript.ChangeAvatar(Player.tag);
		playerInventory.Add(playerInventoryScript);


		count++;




	}


}
