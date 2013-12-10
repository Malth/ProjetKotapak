using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Kotapak main script managing the input.
/// </summary>
public class KotapakInputManager : MonoBehaviour {
	


	/// <summary>
	/// Store the list of online players.
	/// </summary>
	[SerializeField]
	public List<GameObject> PlayersOnline = new List<GameObject> ();

	/// <summary>
	/// Store the life state of players.
	/// </summary>
	public Dictionary<int,bool> isDead = new Dictionary<int, bool>() ;

	/// <summary>
	/// Store the prefab of all players.
	/// </summary>
	[SerializeField]
	private GameObject _prefabPlayer;
	
	/// <summary>
	/// A tab storing all spawns point of the current level.
	/// </summary>
	Vector3[] spawns = new Vector3[4];
	/// <summary>
	/// The kotapak network script, managing the network.
	/// </summary>
	private KotapakNetworkScript kotapakNetworkScript;
	/// <summary>
	/// The put bomber script, managing the bomb throw.
	/// </summary>
	private PutBomber putBomberScript;
	/// <summary>
	/// The player inventory script, managing the inventories.
	/// </summary>
	public PlayerInventory playerInventoryScript;
	
	/// <summary>
	/// The GUicamera represents the interface seen by the player.
	/// </summary>
	[SerializeField]
	private GameObject GUIcamera ;
	
	/// <summary>
	/// List storing all the PlayerControllers, that control the players.
	/// </summary>
	List <PlayerController> playersController = new List<PlayerController>() ;
	/// <summary>
	/// List storing the putBombers.
	/// </summary>
	List <PutBomber> putBombers = new List<PutBomber>();
	/// <summary>
	/// List storing the PlayerInventories, 
	/// </summary>
	public List <PlayerInventory> playerInventory = new List<PlayerInventory>();

   	int count = 0;
   
	[SerializeField]
	public NetworkView _myNetworkView ;
	
	/// <summary>
	/// On start, load the Spanw position in the spawns tab, instantiate GUICamera
	 /// and create new player for all client connected to the server.
	/// </summary>
	void Start () 
	{
		kotapakNetworkScript = GameObject.Find("aKotapakNetworkManager").GetComponent<KotapakNetworkScript>();
		GameObject myGUIcamera = Instantiate (GUIcamera) as GameObject;
		//Loading spawns
		/*
		spawns[0] = new Vector3(12,1,12);
		spawns[1] = new Vector3(-12,1,12);
		spawns[2] = new Vector3(12,1,-12);
		spawns[3] = new Vector3(-12,1,-12);
		*/


		GameObject[] spawnsGO = GameObject.FindGameObjectsWithTag("Spawn");

				for (int i = 0; i < spawnsGO.Length ; i++) 
				{
						spawns [i] = spawnsGO [i].transform.position;
				}

		if (Network.isServer) 
		{
			for (int i = 0; i< Network.connections.Length; i++)
				_myNetworkView.RPC ("createNewPlayer", RPCMode.All);
		}
	}
	/// <summary>
	/// On Update, sending the intentions of Players to the Server
	/// </summary>
	void Update () 
	{
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
			
			if (Input.GetKeyDown (KeyCode.UpArrow)) 
			{
				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, true);
			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) 
			{
				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, false);
			}		

			if (Input.GetKeyDown (KeyCode.LeftArrow)) 
			{
				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, true);
			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) 
			{
				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, false);
			}	

			if (Input.GetKeyDown (KeyCode.RightArrow)) 
			{
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
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate(){
		foreach (var p in kotapakNetworkScript.DicoPlayersIntents) {
			if (p.Value._wantToMoveDown || p.Value._wantToMoveUp || p.Value._wantToMoveRight || p.Value._wantToMoveLeft) 
			{
				if (p.Value._wantToMoveDown) 
				{
					playersController [int.Parse (p.Key.ToString ())-1].MoveToDown ();
				} 
				if (p.Value._wantToMoveUp) 
				{
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToUp ();
				} 
				if (p.Value._wantToMoveLeft) 
				{
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToLeft ();
				}
				if (p.Value._wantToMoveRight) 
				{
					playersController [int.Parse (p.Key.ToString ()) - 1].MoveToRight ();
				}
			} 
			else 
			{
				try 
				{
					playersController [int.Parse (p.Key.ToString ())-1]._inCurrentDeplacement=0;
					playersController [int.Parse (p.Key.ToString ())-1]._myRigidbody.velocity = Vector3.zero;
				} 
				catch (System.Exception ex) 
				{
					Debug.Log (ex.Message);
				}
			}
			if (p.Value._wantToPutBomb) 
			{
				putBombers[int.Parse(p.Key.ToString ())-1].wantToPutBomb(playerInventory[int.Parse(p.Key.ToString ())-1]);
				kotapakNetworkScript.DicoPlayersIntents[p.Key]._wantToPutBomb = false;
			}
		}	
	}
	/// <summary>
	/// Message about a player wanting to put a bomb is send through the network.
	/// </summary>
	/// <param name='p'>
	/// P.
	/// </param>
	/// <param name='b'>
	/// B.
	/// </param>
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

	/// <summary>
	/// Updating the player stock message send to the network
	/// </summary>
	/// <param name='p'>
	/// Player
	/// </param>
	/// <param name='key'>
	/// Key of the item
	/// </param>
	/// <param name='value'>
	/// Amount of items used
	/// </param>
	[RPC]
	void PlayerMAJstock(NetworkPlayer p, string key)
	{
		Debug.Log ("Methode RPC playerMAJstock");
		playerInventory [int.Parse (p.ToString ()) - 1].ResourceObjects[key]--;
		playerInventory [int.Parse (p.ToString ()) - 1].RefreshRessource ();

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerMAJstock", RPCMode.OthersBuffered, p, key );
		}
	}

	/// <summary>
	/// Adds the items to stock.
	/// </summary>
	/// <param name='p'>
	/// Player.
	/// </param>
	/// <param name='key'>
	/// Key of the item
	/// </param>
	/// <param name='value'>
	/// Amount of items
	/// </param>
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

	/// <summary>
	/// Checks the survivor and died players.
	/// </summary>
	/// <param name='tagPlayer'>
	/// Tag player.
	/// </param>
	/// 
	/// 
	/// 
	/// 
	/// 


	[RPC]
	void KillPlayer(string tagPlayer)
	{
		GameObject player = GameObject.FindGameObjectWithTag (tagPlayer) as GameObject;
		Destroy (player);

		int indicePlayer = 0;
		switch (tagPlayer) {
			case"player1":
				indicePlayer = 0;
			break;
			case"player2":
				indicePlayer = 1;
			break;
			case"player3":
				indicePlayer = 2;
			break;
			case"player4":
				indicePlayer = 3;
			break;
		}
		Debug.Log ("IsDead count : " + isDead.Count());
		isDead.Remove(indicePlayer+1);
		Debug.Log ("IsDead count : " + isDead.Count());

		if(Network.isServer)_myNetworkView.RPC("CheckSurvivor", RPCMode.All);

		if(int.Parse(Network.player.ToString())-1 == indicePlayer) Application.LoadLevel ("looser");



	}


	[RPC]
	void CheckSurvivor()
	{
		Debug.Log ("Check survivor ok");

		if(isDead.Count == 1 && isDead[int.Parse(Network.player.ToString())]==false)Application.LoadLevel("winner");
				

	

	}


	/// <summary>
	/// Creates the new player.
	/// </summary>
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
		isDead.Add(count+1,false);

		if (Player.tag == "player" + int.Parse (Network.player.ToString ())) 
		{
			playerInventoryScript.ChangeAvatar(Player.tag);
		}
		playerInventory.Add(playerInventoryScript);

		if (Player.tag == "player" + int.Parse (Network.player.ToString ())) 
		{
			Light[] _myLight = Player.GetComponentsInChildren<Light>();
				foreach (Light light in _myLight) {
						light.intensity = 2;
				}
		}
		if (Network.isServer) 
		{
			Light[] _myLight = Player.GetComponentsInChildren<Light>();
			foreach (Light light in _myLight) 
			{
				light.intensity = 2;
			}
		}
		count++;
	}
}
