using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	private bool isPaused = true;
	public GameObject stuffHolder;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
		if (isPaused)
			{
				Time.timeScale = 0;
				stuffHolder.SetActive (true);
				isPaused = false;	
			}
		else 
			{
				Time.timeScale = 1; 
				stuffHolder.SetActive (false);
				isPaused = true;
			}
		}
		
	}

	public void resumeLife()
	{
		Time.timeScale = 1; 
		isPaused = true;
		stuffHolder.SetActive (false);
	}
	public void goToMainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
