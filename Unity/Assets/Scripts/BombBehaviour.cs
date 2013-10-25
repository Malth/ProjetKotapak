using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
	
	
	private GameObject Player1 ;
	private GameObject instantiated;
	[SerializeField]
	private GameObject SmallExplostion;
	
	private PutBomber putBomber ;
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
		
		Player1 = GameObject.FindGameObjectWithTag("Player");
		putBomber = Player1.GetComponentInChildren<PutBomber>();
	}

	IEnumerator ActiverBombe ()
	{
		 yield return new WaitForSeconds(2);
		 instantiated = (GameObject)Instantiate(SmallExplostion, transform.position, transform.rotation);	
		 yield return new WaitForSeconds(1);
		 Destroy (instantiated);
		 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(putBomber.BombPresent == true)			
		{
			StartCoroutine(ActiverBombe ());
		}			
		
	}
	

	
}
