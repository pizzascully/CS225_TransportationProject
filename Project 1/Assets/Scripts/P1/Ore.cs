using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//System.Serializable makes my public Classes editable in the Inspector
[System.Serializable] 
public class Ore : MonoBehaviour {
		
	public string name; 
	public int OreSupply;		
	public float MiningSpeed;
	public bool TimetoMine;
	public GameObject PlayerOre;
	public Color HighlightColor;
	public Material PrimaryMaterial; 
	public bool Highlight = false; 
	public List <GameObject> RareOre;

	float xPosition;
	Vector3 orePosition;

	// At Start: Set TimetoMine to False to keep it under player control and set up xPosition
	void Start () {
		
		TimetoMine = false;

		xPosition = 0f;

	}
	//These are the functions that allow the mouse to hover over and highlight the rock.
	void OnMouseEnter () {
		Highlight = true;
		if (Highlight == true) {
			//This sets a color when the mouse hovers by fetching the renderer and then setting the color of the material to whatever.
			GetComponent<Renderer> ().material.SetColor ("_Color", HighlightColor); 
		}
	}

	void OnMouseExit () {
		Highlight = false;
		if (Highlight == false) {
			//This fetches the renderer and changes the material of the object back to its origional material or whatever is plugged into the prefab. 
			GetComponent<Renderer> ().material.CopyPropertiesFromMaterial (PrimaryMaterial);
	}
	}
	//During the Update we tell the game to check if the OreSupply is at or below 0,
	//If it is below 0 we destroy the object to represent that the ore is mined and to end our script. 
	void Update () {
		
		if (OreSupply <= 0) { 
			Destroy (gameObject); 
		}
		//When TimetoMine is switched on we begin the mining coroutine.
		if (TimetoMine == true) {
			StartCoroutine ("MineOre");
		// When the coroutine is completed we start it again.
		}
			

	}
	//This allows the player to toggle between it being TimetoMine and TimetoMine = False
	void OnMouseUp () {
		if (TimetoMine == false) {
			TimetoMine = true;
		} else if (TimetoMine == true) {
			TimetoMine = false;
		}
	}
	//IEnumerator is the function type we need in order to Use WaitforSeconds so that we can space out our spawns independantly of time.time
	IEnumerator MineOre () {
			//YIELD = iterate, RETURN = stop, NEW = Separate.
			// WaitForSeconds maintains the above for the alotted time which in this case == MiningSpeed 
		yield return new WaitForSeconds (MiningSpeed); {
				OreSupply -= 1;
				}
		//After subtracting the Ore, it resets the xPosition -> instantiates a specified object -> and Stops the Coroutine
		orePosition = new Vector3 (xPosition, 0f, 0f); 
		Instantiate (PlayerOre, orePosition, Quaternion.identity); 
		xPosition += 2;
		StopCoroutine ("MineOre");  
		//The Coroutine will start again if TimetoMine is still true
}
	}
