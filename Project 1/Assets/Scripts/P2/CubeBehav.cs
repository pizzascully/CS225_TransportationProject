using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehav : MonoBehaviour {

	TransportControl myGameController;
	public int x; 
	public int y; 

	// Use this for initialization
	void Start () {
		
		myGameController = GameObject.Find ("GameControl").GetComponent<TransportControl> ();
	}

	void OnMouseDown () {
	myGameController.ProcessClick (gameObject, x, y); 
	}

	// Update is called once per frame
	void Update () {
		
	}
}
