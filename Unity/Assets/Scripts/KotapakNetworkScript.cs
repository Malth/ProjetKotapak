using UnityEngine;
using System.Collections;

public class KotapakNetworkScript : MonoBehaviour {

   

    [SerializeField]
    private bool _isServer = true;
    public bool IsServer
    {
        get { return _isServer; }
        set { _isServer = value; }
    }

	void Start () {
        Application.runInBackground = true;

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
        if (Network.connections.Length == 2)
        {
            Debug.Log("Chargement niveau");
        }
    }
}
