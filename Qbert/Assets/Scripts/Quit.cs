using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour 
{


	public void startGame()
	{
		SceneManager.LoadScene("Main");
        Time.timeScale = 1;
	}
	public void BackToReality() 
	{
		Application.Quit();
	}
	public void goToScores()
	{
		SceneManager.LoadScene("Scores");
	}
	public void goToMainMenu()
	{
		SceneManager.LoadScene("Menu");
	}

}

