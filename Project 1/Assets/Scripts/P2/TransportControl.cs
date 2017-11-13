using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportControl : MonoBehaviour {

	//Sky Instantiation
	public GameObject sky;
	GameObject selectedSky;
	public GameObject [,] grid;
	int gridX, gridY;
	Vector3 skyPosition; 
	//Airplane Behav
	bool activePlane;
	int planeX, planeY, airPortX, airPortY;
	//Turn
	float turnLength, turnTimer;
	//Depot Location 
	int depotX, depotY;
	//Cargo
	int planeCapacity, planeCargo;
	int cargoRate;
	int score;


	// Use this for initialization
	void Start () {

	

		//Airplane Cargo Var
		planeCapacity = 90;
		planeCargo = 0;
		cargoRate = 10;
		score = 0;

		//Set the Turn Var
		turnLength = 1.5f;
		turnTimer = turnLength;

		//Grid Dimensions
		gridX = 16;
		gridY = 9;

		grid = new GameObject[gridX, gridY]; 

		//For Loops that Generate the Grid which the dimensions of are represented above
		for (int y = 0; y < gridY; y++) {

			for (int x = 0; x < gridX; x++) {
				//Sets the position of the objects in the scene and spaces them correctly upon cloning
				skyPosition = new Vector3 (x * 2, y * 2, 0);
				{
					//instantiates the game objects in space according to where they are in the loop
					grid [x, y] = Instantiate (sky, skyPosition, Quaternion.identity);
					grid [x, y].GetComponent<CubeBehav> ().x = x;
					grid [x, y].GetComponent<CubeBehav> ().y = y;

				
				}
			}

		}
		//plane starts in upper left
		airPortX = 0;
		airPortY = gridY - 1;
		planeX = airPortX;
		planeY = airPortY; 
		grid [planeX, planeY].GetComponent<Renderer> ().material.color = Color.red;
		activePlane = false;
		//Depot Starts in lower right
		depotX = gridX - 1;
		depotY = 0;
		grid [depotX, depotY].GetComponent<Renderer> ().material.color = Color.black;

	}



	public void ProcessClick (GameObject clickedSky, int x, int y) { 

		if (x == planeX && y == planeY) {
			if (!activePlane) {
				activePlane = true;
				clickedSky.transform.localScale *= (1.5f);
			} else {
				activePlane = false;
				clickedSky.transform.localScale /= (1.5f);
					
			}
		}
		//if an airplane was not clicked
		else {
			if (activePlane) { 
				//if depot set to black, otherwise set to white
				if (planeX == depotX && planeY == depotY) {
					grid [depotX, depotY].GetComponent<Renderer> ().material.color = Color.black;
				} else {
					grid [planeX, planeY].GetComponent<Renderer> ().material.color = Color.white;

				}
				grid [planeX, planeY].transform.localScale /= (1.5f);


				//place airplane in new position 
				planeX = x;
				planeY = y; 
				grid [x,y].GetComponent<Renderer> ().material.color = Color.red;
				grid [x,y].transform.localScale *= (1.5f);
			}
		}
			
		/*if (selectedSky != null) { 
			selectedSky.GetComponent<Renderer> ().material.color = Color.white;
		}
		clickedSky.GetComponent<Renderer> ().material.color = Color.red;
		selectedSky  = clickedSky; */
	}

	//if click processed start turn

	void LoadCargo () {
		if (planeX == airPortX && planeY == airPortY) {
			planeCargo += cargoRate;
			planeCargo = Math.Min (planeCargo, planeCapacity);
		}
	}

	void DeliverCargo () {
		if (planeX == depotX && planeY == depotY) {
			score += planeCargo;
			planeCargo = 0;
		}
	}
	// Update is called once per frame
	void Update () {
		
		if (Time.time > turnTimer) {

			LoadCargo (); 
			DeliverCargo ();
			print ("Cargo: " + planeCargo + " Score: " + score);

			turnTimer += turnLength; 

		}
}

}
