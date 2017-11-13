using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {
	public int bronzeSupply;
	public int silverSupply;
	public int playerSilver;
	public int playerBronze;
	public int timeToMine;
	public int miningSpeed;
	float xPosition; 


	public GameObject silverOre;
	public GameObject bronzeOre;
	Vector3 orePosition; 

	// Use this for initialization
void Start () {
		bronzeSupply = 3;
		silverSupply = 2;
		playerSilver = 0;
		playerBronze = 0;

		timeToMine = 2;
		miningSpeed = 2;


		print ("Bronze Deposit " + bronzeSupply); 
		print ("Silver Deposit " + silverSupply); 
		print ("Player Bronze " + playerBronze);
		print ("Player Silver " + playerSilver); 

		xPosition = 0f; 
			
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToMine) {

			if (bronzeSupply > 0) {
				bronzeSupply -= 1;
				playerBronze += 1; 

				orePosition = new Vector3 (xPosition, 0f, 0f); 
				Instantiate (bronzeOre, orePosition, Quaternion.identity); 
				xPosition += 2;
		
			} else if (bronzeSupply == 0 && silverSupply > 0) {
				silverSupply -= 1;
				playerSilver += 1;

				orePosition = new Vector3 (xPosition, 0f, 0f); 
				Instantiate (silverOre, orePosition, Quaternion.identity);
				xPosition += 2;
			}
			print ("Bronze Deposit " + bronzeSupply
			+ "...Silver Deposit " + silverSupply
			+ "...Player Bronze " + playerBronze
			+ "...Player Silver " + playerSilver);
		

			timeToMine += miningSpeed;
		}
	}
}