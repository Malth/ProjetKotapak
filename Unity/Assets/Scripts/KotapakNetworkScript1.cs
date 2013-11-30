using UnityEngine;
using System.Collections;

public class KotapakNetworkScript1 : MonoBehaviour {



	void Start () {
		Application.runInBackground = true;
		//Application.LoadLevel("level1");

		Network.Connect("127.0.0.1", 6600);

	}



}
