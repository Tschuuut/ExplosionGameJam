﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombManager : MonoBehaviour {

	private List<GameObject> bombs = new List<GameObject>();
	private GameObject bombToDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bombToDrop == null) {
			return;
		}

		Vector3 mousePos = Input.mousePosition;
		bombToDrop.transform.position = new Vector3(
			Camera.main.ScreenToWorldPoint(mousePos).x,
			Camera.main.ScreenToWorldPoint(mousePos).y, 0
		);

		// Place bomb on click
		if (Input.GetMouseButtonDown(0))
		{
			bombToDrop.GetComponent<Bomb>().SetTransparent (false);
			bombToDrop = null;
		}
	}

	public void SelectBomb(GameObject bombPrefab) {
		bombToDrop = Instantiate (bombPrefab);
		bombToDrop.GetComponent<Bomb> ().SetTransparent (true);

		// Enum in list
		bombs.Add (bombToDrop);
		this.UpdateBombEnumeration ();
	}

	private void UpdateBombEnumeration() {
		int i = 1;
		foreach (GameObject bomb in this.bombs) {
			Debug.Log ("Bomb: " + i);
			i++;
		}
	}
}