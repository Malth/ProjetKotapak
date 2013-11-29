using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class KotapakInputManager : MonoBehaviour {
	
	[SerializeField]
	private Transform player1;
	public Transform Player1 
	{
		get {
			return this.player1;
		}
		set {
			player1 = value;
		}
	}
	
	int PlayerSpeed = 1;
	
	[SerializeField]
	private Transform player2;
	public Transform Player2 {
		get {
			return this.player2;
		}
		set {
			player2 = value;
		}
	}	
	
	
    class PlayerIntents
    {
        public bool _wantToMoveUp = false;
        public bool _wantToMoveDown = false;
		public bool _wantToMoveLeft = false;
		public bool _wantToMoveRight = false;
    }

    private Dictionary<NetworkPlayer, PlayerIntents> _playersIntents;
    private Dictionary<NetworkPlayer, PlayerIntents> PlayersIntents
    {
        get { return _playersIntents; }
        set { _playersIntents = value; }
    }

    private NetworkView _myNetworkView = null;

	void Start () {
        PlayersIntents = new Dictionary<NetworkPlayer, PlayerIntents>();
        _myNetworkView = this.gameObject.GetComponent<NetworkView>();
	}

    void OnPlayerConnected(NetworkPlayer p)
    {
        PlayersIntents.Add(p, new PlayerIntents());
        _myNetworkView.RPC("NewPlayerConnected", RPCMode.OthersBuffered, p);
    }

    [RPC]
    void NewPlayerConnected(NetworkPlayer p)
    {
        PlayersIntents.Add(p, new PlayerIntents());
    }
	
	void Update () {
        if (Network.isClient)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveDown", RPCMode.Server, Network.player, true);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveDown", RPCMode.Server, Network.player, false);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveUp", RPCMode.Server, Network.player, true);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveUp", RPCMode.Server, Network.player, false);
            }
			if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveLeft", RPCMode.Server, Network.player, true);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveLeft", RPCMode.Server, Network.player, false);
            }
			if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveRight", RPCMode.Server, Network.player, true);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _myNetworkView.RPC("PlayerWantToMoveRight", RPCMode.Server, Network.player, false);
            }
        }
	}

    void FixedUpdate()
    {
        int i = 0;
        foreach (var p in PlayersIntents)
        {
            if (i == 0 && p.Value._wantToMoveDown)
            {
                Player1.Translate(Vector3.down * PlayerSpeed * Time.deltaTime);
            }
            if (i == 0 && p.Value._wantToMoveUp)
            {
                Player1.Translate(Vector3.up * PlayerSpeed * Time.deltaTime);
            }
			if (i == 0 && p.Value._wantToMoveLeft)
            {
                Player1.Translate(Vector3.left * PlayerSpeed * Time.deltaTime);
            }
            if (i == 0 && p.Value._wantToMoveRight)
            {
                Player1.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
			}  
            if (i == 1 && p.Value._wantToMoveUp)
            {
                Player2.Translate(Vector3.up * PlayerSpeed * Time.deltaTime);
            }
            if (i == 1 && p.Value._wantToMoveDown)
            {
                Player2.Translate(Vector3.down * PlayerSpeed * Time.deltaTime);
            } 
			if (i == 1 && p.Value._wantToMoveLeft)
            {
                Player2.Translate(Vector3.left * PlayerSpeed * Time.deltaTime);
            }
            if (i == 1 && p.Value._wantToMoveRight)
            {
                Player2.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
            }
			
            i++;
        }
    }
	
    [RPC]
    void PlayerWantToMoveUp(NetworkPlayer p, bool b)
    {
        PlayersIntents[p]._wantToMoveUp = b;
        if (Network.isServer)
        {
            _myNetworkView.RPC("PlayerWantToMoveUp", RPCMode.Others, p, b);
        }
    }

    [RPC]
    void PlayerWantToMoveDown(NetworkPlayer p, bool b)
    {
        PlayersIntents[p]._wantToMoveDown = b;
        if (Network.isServer)
        {
            _myNetworkView.RPC("PlayerWantToMoveDown", RPCMode.Others, p, b);
        }
	}
		
	[RPC]
    void PlayerWantToMoveLeft(NetworkPlayer p, bool b)
    {
        PlayersIntents[p]._wantToMoveLeft = b;
        if (Network.isServer)
        {
            _myNetworkView.RPC("PlayerWantToMoveLeft", RPCMode.Others, p, b);
        }
    }
	
	[RPC]
    void PlayerWantToMoveRight(NetworkPlayer p, bool b)
    {
        PlayersIntents[p]._wantToMoveRight = b;
        if (Network.isServer)
        {
            _myNetworkView.RPC("PlayerWantToMoveRight", RPCMode.Others, p, b);
        }
	}
}
