using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : GameManager {
	public Vector3 currPos;
	public Vector3 dest;
	public Vector3 direction;
	private float speed = 2.0f;
	private bool left = false;
	private bool right = false;
	private bool up = false;
	private bool down = false;
	private bool pressed = true;
	private bool onElev = false;
	public int col = 7;
	public int row = 1;
	public Rigidbody2D hardLife;
	public CapsuleCollider2D andreIsAnoob;
	private Vector3 restPlace;
	public Sprite goingTopLeft;
	public Sprite goingBotLeft;
	public Sprite goingTopRight;
	public Sprite goingBotRight;
	private SpriteRenderer qbertSprite;
	private bool notDead = true;
	private bool justBecause = true;
	private bool qbertAliveAgain = true;
	public GameObject swear;
	public GameObject live;
	public GameObject live2;
	private int livesCounter = 3;

	public GameObject LeaderBoard;

	public AudioSource clown;
	public AudioClip[] clips;

	public GameObject done;
	// Use this for initialization
	void Start () {
		andreIsAnoob.enabled = true;
		qbertSprite= gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (left) {
			movementMagic ();
		}
		if (right) {
			movementMagic ();
		}
		if (up) {
			movementMagic ();
		}
		if (down) {
			movementMagic ();
		}
		if (onElev) {
			movementMagic ();
		}
		if(qbertAliveAgain)
		{
		if (Input.GetKeyDown (KeyCode.Keypad7)&& pressed || Input.GetKeyDown (KeyCode.LeftArrow) && pressed) 
		{
			clown.clip = clips [0];
			clown.Play ();
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (-0.6f, 0.98f, 0.0f);
			dest = currPos + sucksToBeMe;
			left = true;
			pressed = false;
			row --;
			col --;

			qbertSprite.sprite = goingTopLeft;
		}
		if (Input.GetKeyDown (KeyCode.Keypad3)&& pressed || Input.GetKeyDown (KeyCode.RightArrow)&& pressed) 
		{
			clown.clip = clips [0];
			clown.Play ();
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (0.6f, -0.98f, 0.0f);
			dest = currPos + sucksToBeMe;
			right = true;
			pressed = false;
			row ++;
			col ++;
			qbertSprite.sprite = goingBotRight;
	
		}
		if (Input.GetKeyDown (KeyCode.Keypad1)&& pressed || Input.GetKeyDown (KeyCode.DownArrow)&& pressed) 
		{
			clown.clip = clips [0];
			clown.Play ();
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
			dest = currPos + sucksToBeMe;
			down = true;
			pressed = false;
			col--;
			row++;
			qbertSprite.sprite = goingBotLeft;
		}
		if (Input.GetKeyDown (KeyCode.Keypad9)&& pressed || Input.GetKeyDown (KeyCode.UpArrow)&& pressed) 
		{
			clown.clip = clips [0];
			clown.Play ();
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (0.6f, 0.98f, 0.0f);
			dest = currPos + sucksToBeMe;
			up = true;
			pressed = false;
			row--;
			col++;
			qbertSprite.sprite = goingTopRight;
		}

		//death Check
		if (row == 0 && col == 8 || row == 0 && col == 6 || row == 1 && col == 5 || row == 1 && col == 9 || row == 2 && col == 10 || row == 2 && col == 4 ||
		   row == 3 && col == 3 || row == 3 && col == 11 || row == 5 && col == 1 || row == 5 && col == 13 || row == 6 && col == 14 || row == 6 && col == 0 ||
		   row == 8) 
		{
			
			death ();
			clown.clip = clips [2];
			clown.Play ();
		}
		}

	}
	void movementMagic()
	{
	//	Debug.Log (Vector3.Distance (currPos, dest));
		
		if (Vector3.Distance(currPos,dest) <= 0.08f) 
		{
			this.transform.position = dest;
			left = false;
			right = false;
			up = false;
			down = false;
			onElev = false;
			pressed = true;
			return;
		}
		currPos = this.transform.position;
		direction = dest - currPos;
		direction.Normalize ();
		direction = direction * speed * Time.deltaTime;
		this.transform.Translate (direction);	
	}






	//Elev stuff
	public void onLeftDisc()
	{
		clown.clip = clips [1];
		clown.Play ();

		pressed = false;
		justBecause = false;
		currPos = this.transform.position;
		Vector3 sucksToBeMe = new Vector3 (-3.0f, 4.0f, 0.0f);
		dest = currPos + sucksToBeMe;
		
		Invoke ("goingDown", 2.5f);
		diskCounter--;
		Debug.Log(diskCounter);

	}
	public void onRightDisc()
	{
		clown.clip = clips [1];
		clown.Play ();


		pressed = false;
		justBecause = false;
		currPos = this.transform.position;
		Vector3 sucksToBeMe = new Vector3 (3.0f, 4.0f, 0.0f);
		dest = currPos + sucksToBeMe;
		
		Invoke ("goingDown", 2.5f);
		diskCounter--;
		Debug.Log(diskCounter);
	}
	public void goingDown()
	{
		onElev = true;
		if (!justBecause)
		{
			justBecause = true;
			qbertSprite.sprite = goingBotRight;
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (0.0f, 0.6f, -9.0f);
			dest = sucksToBeMe;
            col = 7;
            row = 1;
			pressed = false;
		}
	}
	public void death()
	{
		if (notDead) {
			//hardLife.gravityScale = 1;
			qbertAliveAgain = false;
			purajAlive = false;
			currPos = this.transform.position;
			restPlace = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (0.0f, -10.0f, 0.0f);
			dest = sucksToBeMe +currPos;
			speed = 8;
			qbertSprite.sortingOrder = 0;
			andreIsAnoob.enabled = false;
			notDead = false;
			Invoke ("respawn", 3.0f);
			clown.clip = clips [2];
			clown.Play ();
			if(livesCounter==3)
			{
				Destroy(live2.gameObject);
				livesCounter--;
			}
			else if(livesCounter==2)
			{
				Destroy(live.gameObject);
				livesCounter--;
			}
			else if(livesCounter==1)
			{
				Debug.Log("END GAME");
				gameOver = true;
				Invoke ("youSuck", 1);
			}

		}
	}
	public void respawn()
	{
		col = 7;
		row = 1;
		speed = 2;
		hardLife.gravityScale = 0;
		qbertSprite.sortingOrder = 3;
		andreIsAnoob.enabled = true;
		Vector3 resPlace = new Vector3(0.0f, 0.6f,-9.0f);
		this.transform.position =resPlace;
		dest = resPlace;
		notDead = true;
		qbertSprite.sprite = goingBotRight;
		qbertAliveAgain = true;
	}
	public void deathByEnemy()
	{
		clown.clip = clips [3];
		clown.Play ();
		//qbertSprite.sortingOrder = 0;
		andreIsAnoob.enabled = false;
		qbertAliveAgain = false;
		notDead = false;
		swear.SetActive(true);
		Invoke ("respawnE", 3.0f);
		purajAlive = false;
		if(livesCounter==3)
		{
			Destroy(live2.gameObject);
			livesCounter--;
		}
		else if(livesCounter==2)
		{
			Destroy(live.gameObject);
			livesCounter--;
		}
		else if(livesCounter==1)
		{
			Debug.Log("END GAME");
			gameOver = true;
			Invoke ("youSuck", 1);
		}

	}
	public void respawnE()
	{
		qbertSprite.sortingOrder = 3;
		andreIsAnoob.enabled = true;
		notDead = true;
		qbertSprite.sprite = goingBotRight;
		qbertAliveAgain = true;
		swear.SetActive(false);
	}
	public void youSuck(){
		done.SetActive (true);
		Time.timeScale = 0;
	}
}
