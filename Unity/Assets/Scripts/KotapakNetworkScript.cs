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



	public class PlayerIntents
	{

		public bool _wantToMoveUp = false;
		public bool _wantToMoveDown = false;
		public bool _wantToMoveLeft = false;
		public bool _wantToMoveRight = false;
	
	}
	
	public class PlayerBombPresent
	{
		public bool _playerBombPresent = false;
	}



	private Dictionary<NetworkPlayer, PlayerIntents> _dicoPlayersIntents;
	public Dictionary<NetworkPlayer, PlayerIntents> DicoPlayersIntents
	{
		get { return _dicoPlayersIntents; }
		set { _dicoPlayersIntents = value; }
	}
	
	private Dictionary<NetworkPlayer, PlayerBombPresent> _dicoPlayersBombPresent;
	public Dictionary<NetworkPlayer, PlayerBombPresent> DicoPlayersBombPresent 
	{
		get {
			return this._dicoPlayersBombPresent;
		}
		set {
			_dicoPlayersBombPresent = value;
		}
	}



	void Awake () {
		DontDestroyOnLoad(this.gameObject);
		DicoPlayersIntents = new Dictionary<NetworkPlayer, PlayerIntents>();
		DicoPlayersBombPresent = new Dictionary<NetworkPlayer, PlayerBombPresent>();
	}
	

	void Start () {
        Application.runInBackground = true;
		//Application.LoadLevel("level1");
        if (IsServer)
        {
            Network.InitializeSecurity();
            Network.InitializeServer(2, 6600, true);
        }
        else
        {
            Network.Connect("127.0.0.1", 6600);
        }
	}

    void OnPlayerConnected(NetworkPlayer player)
    {

		DicoPlayersIntents.Add(player, new PlayerIntents());
		DicoPlayersBombPresent.Add(player, new PlayerBombPresent());
		networkView.RPC("NewPlayerConnected", RPCMode.Others, player);

        if (Network.connections.Length == 2)
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
		DicoPlayersBombPresent.Add(p, new PlayerBombPresent());

	}
	


	[RPC]
	void LoadLevel(string nameLevel){

		Application.LoadLevel(nameLevel);

	}

}
