﻿using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour {
	
	
	
	private GameObject instantiated;
	
	[SerializeField]
	private GameObject ExplosionLvl1;
	
	
	private string _playerName;
	
	public string PlayerName{
		get {
			return _playerName;
		}
		set {
			_playerName = value;
		}
	}
	
	
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

	public void makeExplosion()
	{
		instantiated = (GameObject)Instantiate(ExplosionLvl1, transform.position, transform.rotation);
		instantiated.tag = PlayerName;
	}

	
}
