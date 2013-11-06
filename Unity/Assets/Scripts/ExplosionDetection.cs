using UnityEngine;
using System.Collections;

public class ExplosionDetection : MonoBehaviour {
	
	
	private bool isDead = false;

	public bool IsDead {
		get {
			return this.isDead;
		}
		set {
			isDead = value;
		}
	}	
	
	
	void OnGUI() {
		
		if (IsDead)
		{
		GUI.Label (new Rect (Screen.width/2-30, Screen.width/2-100, 200, 100), "Le joueur s'est fait tuer par"+this.transform.parent.tag);
		Application.LoadLevel(0);	
		}
	
		
   }
	
	
	public void OnTriggerEnter(Collider col) 
	{
		Debug.Log ("Tadaaaaa Trigger ok");
		//Si le Layer est un Brick
		if(col.gameObject.layer == LayerMask.NameToLayer("Bricks"))
		{
			Destroy(col.gameObject);
			Debug.Log ("Il y a un mur destructible.");
		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			IsDead = true;
			Destroy(col.gameObject);
			Debug.Log ("Il y a un joueur.");
		}
		if(col.gameObject.layer == LayerMask.NameToLayer("Walls"))
		{
			Debug.Log ("Il y a un mur indestructible.");
		}
	}	
}
