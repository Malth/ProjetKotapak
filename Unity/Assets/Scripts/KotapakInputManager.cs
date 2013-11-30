using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KotapakInputManager : MonoBehaviour {




	[SerializeField]
	public List<GameObject> PlayersOnline = new List<GameObject> ();



	[SerializeField]
	private GameObject _prefabPlayer;


	private KotapakNetworkScript kotapakNetworkScript;
	List <PlayerController> playersController = new List<PlayerController>() ;
	
   
	[SerializeField]
	private NetworkView _myNetworkView ;

	void Start () {
		kotapakNetworkScript = GameObject.Find("aKotapakNetworkManager").GetComponent<KotapakNetworkScript>();

				if (Network.isServer) {
				for (int i = 0; i< Network.connections.Length; i++)
						_myNetworkView.RPC ("createNewPlayer", RPCMode.All);
				}

				Debug.Log (kotapakNetworkScript.DicoPlayersIntents.Count);
				
	}
	

	
	void Update () {







		if (Network.isClient) 
		{

				Debug.Log ("Je suis un client");
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					_myNetworkView.RPC ("PlayerWantToMoveDown", RPCMode.Server, Network.player, true);
					Debug.Log ("Joueur veut descendre");
				}
				if (Input.GetKeyUp (KeyCode.DownArrow)) 
				{
					_myNetworkView.RPC ("PlayerWantToMoveDown", RPCMode.Server, Network.player, false);
				}


			if (Input.GetKeyDown (KeyCode.UpArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, true);
				Debug.Log ("Joueur veut monter");

			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveUp", RPCMode.Server, Network.player, false);
			}		

			if (Input.GetKeyDown (KeyCode.LeftArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, true);
				Debug.Log ("Joueur veut aller à gauche");

			}
			if (Input.GetKeyUp (KeyCode.LeftArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveLeft", RPCMode.Server, Network.player, false);
			}	




			if (Input.GetKeyDown (KeyCode.RightArrow)) {


				_myNetworkView.RPC ("PlayerWantToMoveRight", RPCMode.Server, Network.player, true);
				Debug.Log ("Joueur veut aller à droite");

			}
			if (Input.GetKeyUp (KeyCode.RightArrow)) {

				_myNetworkView.RPC ("PlayerWantToMoveRight", RPCMode.Server, Network.player, false);
			}		
           
		} 


	}

	void FixedUpdate(){

		Debug.Log ("dico taille :" + kotapakNetworkScript.DicoPlayersIntents.Count);
		Debug.Log ("controller taille :" + playersController.Count);


				foreach (var p in kotapakNetworkScript.DicoPlayersIntents) {
						Debug.Log ("p=" + int.Parse (p.Key.ToString ()));


						if (p.Value._wantToMoveDown || p.Value._wantToMoveUp || p.Value._wantToMoveRight || p.Value._wantToMoveLeft) {

								if (p.Value._wantToMoveDown) {
										playersController [int.Parse (p.Key.ToString ()) - 1].MoveToDown ();
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
								} catch (System.Exception ex) {
					
								}
							
						}

				}
	}



    [RPC]
	void PlayerWantToMoveDown(NetworkPlayer p, bool b)
    {
		Debug.Log("Le joueur"+p+"veut descendre");
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveDown = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveDown", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void PlayerWantToMoveUp(NetworkPlayer p, bool b)
	{
		Debug.Log("RPC WantToMove");
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveUp = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveUp", RPCMode.OthersBuffered, p, b);
		}
	}

	[RPC]
	void PlayerWantToMoveLeft(NetworkPlayer p, bool b)
	{
		Debug.Log("RPC WantToMove");
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveLeft = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveLeft", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void PlayerWantToMoveRight(NetworkPlayer p, bool b)
	{
		Debug.Log("RPC WantToMove");
		kotapakNetworkScript.DicoPlayersIntents[p]._wantToMoveRight = b;

		if (Network.isServer)
		{
			_myNetworkView.RPC("PlayerWantToMoveRight", RPCMode.OthersBuffered, p, b);
		}
	}


	[RPC]
	void createNewPlayer()
	{
			GameObject Player = Instantiate(_prefabPlayer) as GameObject;
			playersController.Add(Player.GetComponent<PlayerController>());
	}

}
