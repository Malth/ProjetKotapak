using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
		private bool _bombIsActive = false;
	public bool BombIsActive 
	{
		get {
			return this._bombIsActive;
		}
		set {
			_bombIsActive = value;
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(BombIsActive)			
		{
			ActiverBombe();
		}			
	}
	public IEnumerator ActiverBombe()
	{
		Debug.Log("Bombe Activée");
		Debug.Log(Time.time);
		yield return new WaitForSeconds(3);
		Debug.Log(Time.time);
		Debug.Log("Bombe Explosée");
	}
}
