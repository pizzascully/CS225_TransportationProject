using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

	float time; 
	int myScore; 
	bool printedMessage; 

	// Use this for initialization
	void Start () {
		print ("I am real gay");

		printedMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 3 && printedMessage == false ) {
			print ("I have been gay for 3 seconds");
			printedMessage = true; 
		}
	}
}
