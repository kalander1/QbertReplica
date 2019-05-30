using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStuff : GameManager {
	public Text[] HighScoreText;

	private int[] hightScoreValue;

	private static ScoreStuff instance = null;

	// Use this for initialization
	void Start () {
		hightScoreValue = new int[HighScoreText.Length];
		for (int x = 0; x < HighScoreText.Length; x++)
		{
			hightScoreValue [x] = PlayerPrefs.GetInt ("HighScoreText" + x);
		}
		DrawScores ();
	}
	void SaveScore()
	{
		for (int x = 0; x < HighScoreText.Length; x++)
		{
			PlayerPrefs.SetInt ("HighScoreText" + x, hightScoreValue [x]);
		}
	}
	public void CheckForHighScore(int value)
	{
		for (int x = 0; x < HighScoreText.Length; x++) {
			if (value > hightScoreValue [x]) {
				for (int y = HighScoreText.Length - 1; y > x; y--) {
					hightScoreValue [y] = hightScoreValue [y - 1];
				}
				hightScoreValue [x] = value;
				DrawScores ();
				SaveScore ();
				break;
			}
		}
	}
	void DrawScores()
	{
		for (int x = 0; x < HighScoreText.Length; x++) {
			HighScoreText [x].text = hightScoreValue [x].ToString ();
		}
	}
	// Update is called once per frame
	void Update () {
		if (gameOver)
		{
			gameOver = false;
			CheckForHighScore (score);
		}
	}
	private ScoreStuff()
	{
		Debug.Log ("Game manager is here");
	}

	public static ScoreStuff Instance {
		get {
			if (instance == null) {
				instance = new ScoreStuff ();
			}
			return instance;
		}
	}
}
