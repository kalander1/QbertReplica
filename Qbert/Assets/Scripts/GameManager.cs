using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static bool gmMover = true;
	public static bool purajAlive = true;
	public Text textScore;
	public static int score;
	public float textSize = .5f;
	public static int diskCounter = 2;
	public static int[] arry;
	public static bool gameOver;

	// Use this for initialization
	void Start () {
		score = 0;	
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		textScore.text=score.ToString();
		if (!gmMover) 
		{
			Invoke ("backToLife", 5.0f);
		}
		if(!purajAlive)
		{
			Invoke("ripPuraj",5.0f);
		}
	}
	public void backToLife()
	{
		gmMover = true;
	}
	public void ripPuraj(){
		purajAlive = true;
	}


}
