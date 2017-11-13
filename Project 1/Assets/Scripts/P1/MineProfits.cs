using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProfits : MonoBehaviour {

	public string OreName;
	public int OreValue;
	public Color HighlightColor; 
	public Material PrimaryMaterial; 
	public bool Highlight;
	public int PlayerScore; 

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

	void OnMouseDown() {
		PlayerScore += OreValue; 
		print (OreName + ": " + PlayerScore);
		Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
