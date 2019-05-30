using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : GameManager {
	public GameObject red;
	public GameObject green;
	public GameObject purple;
	public static bool isPurajThere = false;
	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("spawnRed", 5.0f, 5.0f);
		InvokeRepeating ("spawnGreen", 18.0f, 18.0f);
		InvokeRepeating ("spawnKatty", 8.0f,8.0f);
		
	}
	// Update is called once per frame
	void Update () {

	}
	void spawnRed(){
		if(gmMover){
		Instantiate (red, this.transform.position, this.transform.rotation);
		}
	}
	void spawnGreen(){
		if(gmMover){
		Instantiate (green, this.transform.position, this.transform.rotation);
		}
	}
	void spawnKatty()
	{
		if(gmMover){
		if (!isPurajThere) {
			isPurajThere = true;
			Instantiate (purple, this.transform.position, this.transform.rotation);
		}
	}
	}
}
