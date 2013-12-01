using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KotapakNetworkScript : MonoBehaviour {

   
	[SerializeField]
    private bool _isServer = true;
    public bool IsServer
    {
        get { return _isServer; }
        set { _isServer = value; }
    }

	
	public int _numberOfPlayers;

	public class PlayerIntents
	{

		public bool _wantToMoveUp = false;
		public bool _wantToMoveDown = false;
		public bool _wantToMoveLeft = false;
		public bool _wantToMoveRight = false;
		public bool _wantToPutBomb = false;
	
	}


	private Dictionary<NetworkPlayer, PlayerIntents> _dicoPlayersIntents;
	public Dictionary<NetworkPlayer, PlayerIntents> DicoPlayersIntents
	{
		get { return _dicoPlayersIntents; }
		set { _dicoPlayersIntents = value; }
	}



	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		DicoPlayersIntents = new Dictionary<NetworkPlayer, PlayerIntents>();

	}
	

	void Start () {
        Application.runInBackground = true;
		 _numberOfPlayers = PlayerPrefs.GetInt("NumbersOfPlayers");
		Debug.Log ("Nombre de joueurs : "+_numberOfPlayers);

        if (IsServer)
        {
            Network.InitializeSecurity();
            Network.InitializeServer( _numberOfPlayers, 6600, true);
        }
        else
        {
            Network.Connect("127.0.0.1", 6600);
        }
	}

    void OnPlayerConnected(NetworkPlayer player)
    {
		DicoPlayersIntents.Add(player, new PlayerIntents());
		networkView.RPC("NewPlayerConnected", RPCMode.OthersBuffered, player);

        if (Network.connections.Length == _numberOfPlayers)
        {

			if(IsServer){
				networkView.RPC("LoadLevel", RPCMode.All, "level1");
			}
        }
    }
	


	
	[RPC]
	void NewPlayerConnected(NetworkPlayer p)
	{
		DicoPlayersIntents.Add(p, new PlayerIntents());		
	}
	


	[RPC]
	void LoadLevel(string nameLevel){

		Application.LoadLevel(nameLevel);

	}

}
