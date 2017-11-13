using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportCube : MonoBehaviour
{

	public GameObject cubePrefab;
	Vector3 cubePosition;
	public static GameObject SelectedCube;
	public GameObject [,] grid; 
	int gridX, gridY;
	public static int planeX, planeY;
	bool activePlane;

	// Use this for initialization
	void Start ()
	{

		gridX = 16;
		gridY = 9;

		grid = new GameObject[gridX, gridY];

		for (int y = 0; y < gridY; y++) {
			
			for (int x = 0; x < gridX; x++) {
				cubePosition = new Vector3 (x * 2, y * 2, 0);
				grid [x, y] = Instantiate (cubePrefab, cubePosition, Quaternion.identity);

				}
			}

			planeX = 0; 
			planeY = 8; 
		grid[planeX, planeY].GetComponent<Renderer> ().material.color = Color.red; 
		}




	public static void ProcessClick (GameObject clickedCube, int x, int y)
	{
		if (x == planeX && y == planeY) {
			  
	}
		if (SelectedCube != null) { 
			SelectedCube.GetComponent<Renderer> ().material.color = Color.white;
		}
		clickedCube.GetComponent<Renderer> ().material.color = Color.red;
		SelectedCube = clickedCube; 
	}
 
	//Update is called once per frame
	void Update ()
	{


	}
}
