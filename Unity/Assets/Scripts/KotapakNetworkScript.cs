using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KotapakNetworkScript : MonoBehaviour
{

   /// <summary>
   /// Storing a boolean depending of the statusof the network.
   /// True if is Server, false if is Client.
   /// </summary>
	[SerializeField]
    private bool _isServer = true;
    public bool IsServer
    {
        get { return _isServer; }
        set { _isServer = value; }
    }
	/// <summary>
	/// Store the name of the level to load.
	/// </summary>
	public string _levelToLoad;
	/// <summary>
	/// Store the number of players to wait.
	/// </summary>
	public int _numberOfPlayers;
	/// <summary>
	/// Player intents about mocing and putting bpmbs.
	/// </summary>
	public class PlayerIntents
	{
		public bool _wantToMoveUp = false;
		public bool _wantToMoveDown = false;
		public bool _wantToMoveLeft = false;
		public bool _wantToMoveRight = false;
		public bool _wantToPutBomb = false;
	}
	/// <summary>
	/// A dictionary storing players and their intents.
	/// </summary>
	private Dictionary<NetworkPlayer, PlayerIntents> _dicoPlayersIntents;
	public Dictionary<NetworkPlayer, PlayerIntents> DicoPlayersIntents
	{
		get { return _dicoPlayersIntents; }
		set { _dicoPlayersIntents = value; }
	}
	/// <summary>
	/// On awake, no destroy of this GameObject is attended.
	/// Load the Dictionary
	/// </summary>
	void Awake () 
	{
		DontDestroyOnLoad(this.gameObject);
		DicoPlayersIntents = new Dictionary<NetworkPlayer, PlayerIntents>();
	}
	
	/// <summary>
	/// On start, get the Players Preferences and loading _numbersOfPlayers 
	/// and _levelToLoad. The server start and initialize, the client 
	/// connects to server.
	/// </summary>
	void Start () 
	{
        Application.runInBackground = true;
		_numberOfPlayers = PlayerPrefs.GetInt("NumbersOfPlayers");
		_levelToLoad = PlayerPrefs.GetString("LevelToLoad");
        if (IsServer)
        {
            Network.InitializeSecurity();
            Network.InitializeServer(_numberOfPlayers, 6600, true);
        }
        else
        {
            Network.Connect("127.0.0.1", 6600);
        }
	}
	
	/// <summary>
	/// Raises the player connected event.
	/// Add this player to th Dictionary of Players Intents.
	/// If the max numbers of Players is reached, load the level chosen.
	/// </summary>
	/// <param name='player'>
	/// Player.
	/// </param>
    void OnPlayerConnected(NetworkPlayer player)
    {
		DicoPlayersIntents.Add(player, new PlayerIntents());
		networkView.RPC("NewPlayerConnected", RPCMode.OthersBuffered, player);
        if (Network.connections.Length == _numberOfPlayers)
        {
			if(IsServer){
				networkView.RPC("LoadLevel", RPCMode.All, _levelToLoad);
			}
        }
    }
	


	/// <summary>
	/// On new player connected add it to DicoPlayersIntents
	/// </summary>
	/// <param name='p'>
	/// P.
	/// </param>
	[RPC]
	void NewPlayerConnected(NetworkPlayer p)
	{
		DicoPlayersIntents.Add(p, new PlayerIntents());		
	}
	/// <summary>
	/// Loads the level for all clients and server
	/// </summary>
	/// <param name='nameLevel'>
	/// Name level.
	/// </param>
	[RPC]
	void LoadLevel(string nameLevel){
		Application.LoadLevel(nameLevel);
	}

}
