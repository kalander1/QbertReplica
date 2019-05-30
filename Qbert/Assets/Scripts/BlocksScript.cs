using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksScript : GameManager {
	public GameObject BetterBlock;
	bool first = false;
	static int blockCounter = 0;
	static bool useless = false;
	public GameObject victoryBlock;
	public GameObject spawnPoint;
	public EdgeCollider2D beGone;
	public AudioSource clown;

	public GameObject Win;
	// Use this for initialization
	void Start () {
		useless = false;
		blockCounter = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "Qbert"&& !first && useless) {
			Instantiate(BetterBlock, transform.position,transform.rotation);
			first = true;
			blockCounter++;
			score+= 25;
			beGone.enabled = false;
			Invoke ("victory", .4f);
		}
		if (other.gameObject.name == "Qbert" && this.gameObject.name == "CandyCubeS")
		{
			useless = true;
		}
	
	}
	public void victory(){
		if (blockCounter == 28) 
		{
			clown.Play ();
			Invoke ("congratz", 2.5f);
			Instantiate (victoryBlock, spawnPoint.transform.position, spawnPoint.transform.rotation);
			score+=1000;
			if(diskCounter<= 0)
			{
				diskCounter = 0;
			}
			score=(diskCounter*100)+score;
			gameOver = true;
			gmMover = false;
		}
	}
	public void congratz(){
		Time.timeScale = 0;
		Win.SetActive (true);
	}
}
